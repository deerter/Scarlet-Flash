using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{


    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private GameObject CharacterSoundEffectPlayer;
    public GameObject rivalCharacter;
    private CharacterFeatures currentCharacter;
    private CharacterActions characterActions;
    private Animator animator;
    private Rigidbody2D rigidBody;
    private BoxCollider2D boxCollider;
    private BoxCollider2D rivalBoxCollider;
    private CharacterSoundEffect characterSoundEffect;

    private float characterJumpFinalPosition;  ///Needed to assess the final position of a jump
	private string screenDistance;
    private Vector3 characterSides;  ///Refers to 1/2 the width of the current character's box collider. Used to calculate collisions when jumping over rival.



    void Start()
    {
        currentCharacter = this.GetComponent<CharacterFeatures>();
        characterActions = this.GetComponent<CharacterActions>();
        animator = currentCharacter.GetAnimator();
        rigidBody = this.GetComponent<Rigidbody2D>();
        boxCollider = this.GetComponent<BoxCollider2D>();
        characterSides = boxCollider.bounds.extents;
        rivalBoxCollider = rivalCharacter.GetComponent<BoxCollider2D>();
        characterSoundEffect = CharacterSoundEffectPlayer.GetComponent<CharacterSoundEffect>();
    }

    /*public void falling(){       ///////JUST IN CASE/////////////Loops last frames of falling animation
		animator.Play(AnimationStates.JUMPING_DOWN,0,0.5f);
	}*/

    ///////Character landing////////
    public void CharacterIsGrounded()
    {
        float extraHeightText = 1.0f;
        /*if ((Physics2D.Raycast(boxCollider.bounds.center, Vector2.down, boxCollider.bounds.extents.y + extraHeightText, groundLayerMask).collider) != null){  
			currentCharacter.EndAnimation(AnimationStates.STANDING);
			currentCharacter.SetIsJumping(false);
		}*/
        ///Check if character collider is touching another collider
        if ((Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, extraHeightText, groundLayerMask).collider) != null)
        {
            characterSoundEffect.PlayCharacterSoundEffect("Landing");
            currentCharacter.EndAnimation(AnimationStates.LANDING);
            currentCharacter.SetIsJumping(false);
            Physics2D.IgnoreCollision(rivalBoxCollider, boxCollider, false);   //In the case the character collisions with its rival during jumping, the collision is ignored. This sets collisions as not ignored again.
        }
        /*Debug.DrawRay(boxCollider.bounds.center + new Vector3(boxCollider.bounds.extents.x, 0), Vector2.down * (boxCollider.bounds.extents.y + extraHeightText));
		Debug.DrawRay(boxCollider.bounds.center - new Vector3(boxCollider.bounds.extents.x, boxCollider.bounds.extents.y + extraHeightText), Vector2.right * (boxCollider.bounds.extents.y));*/  ////Debug to check if the boxcast touches the ground
    }

    public void SetCoordinatesWhenLanding()
    { ///Sets the Y on the character to the one it has when standing. If this isn't done, the character phases through the ground as the box collider changes shape between animations.

        transform.position = new Vector3(transform.position.x, -12.58f, transform.position.z);
    }
    /////////////////////////////////

    ////Get final position of a jump//////////
    private void CalculateJumpingDestination(float jumpOriginPosition)
    {
        ////75.89º is the angle of jump (is in degrees, must be converted to radians)///////
        switch (currentCharacter.GetIsFlipped())
        {
            case true:
                characterJumpFinalPosition = ((Mathf.Pow(rigidBody.velocity.x, 2) * Mathf.Sin(2 * (75.89f * Mathf.PI) / 180)) / rigidBody.gravityScale) + jumpOriginPosition;
                float distanceJump = Mathf.Abs(characterJumpFinalPosition - jumpOriginPosition);
                characterJumpFinalPosition = jumpOriginPosition - distanceJump;
                break;

            case false:
                characterJumpFinalPosition = ((Mathf.Pow(rigidBody.velocity.x, 2) * Mathf.Sin(2 * (75.89f * Mathf.PI) / 180)) / rigidBody.gravityScale) + jumpOriginPosition;
                break;
        }


    }

    ///////Character collision when jumping ////////
    private void JumpingOverCharacter(Collision2D col)
    {
        currentCharacter.EndAnimation(AnimationStates.JUMPING_DOWN);
        Rigidbody2D rivalRigidBody = col.gameObject.GetComponent<Rigidbody2D>();
        Vector3 contactPoint = col.contacts[0].point;
        Vector3 center = rivalBoxCollider.bounds.center;
        Vector3 sides = rivalBoxCollider.bounds.extents;
        Vector2 rivalOriginalPosition = new Vector2(center.x, rivalCharacter.transform.position.y);
        //float bottomSide = center.y - sides.y;

        if (screenDistance != "In-close" && screenDistance != "Poke-range")
        {
            switch (currentCharacter.GetIsFlipped())
            {
                case true:
                    if (contactPoint.x < (center.x + 4f))
                    {
                        float distance = Mathf.Abs((characterSides.x + characterJumpFinalPosition) - (center.x - sides.x));
                        Vector2 rivalToPosition = new Vector2(center.x + distance, rivalCharacter.transform.position.y); ///center.y
                        StartCoroutine(LerpPosition(rivalOriginalPosition, rivalToPosition, 0.17f, rivalRigidBody));
                        Physics2D.IgnoreCollision(rivalBoxCollider, boxCollider, true);

                    }
                    else
                    {
                        if (screenDistance == "Mid-screen" && rivalCharacter.transform.position.x < ScreenDistances.SCREEN_LEFT)
                        { /// Behaviour when rival character is against the left wall
                            float distance = Mathf.Abs((characterJumpFinalPosition - characterSides.x) - (center.x + sides.x));
                            Vector2 characterToPosition = new Vector2(boxCollider.bounds.center.x + distance, rivalCharacter.transform.position.y);
                            StartCoroutine(LerpPosition(rivalOriginalPosition, characterToPosition, 0.07f, rigidBody));
                            Physics2D.IgnoreCollision(rivalBoxCollider, boxCollider, true);
                        }
                        else
                        {                                                                                                   ////Normal beahaviour
                            float distance = Mathf.Abs((center.x + sides.x) - (characterJumpFinalPosition - characterSides.x));
                            Vector2 rivalToPosition = new Vector2(center.x - distance, rivalCharacter.transform.position.y);
                            StartCoroutine(LerpPosition(rivalOriginalPosition, rivalToPosition, 0.17f, rivalRigidBody));
                            Physics2D.IgnoreCollision(rivalBoxCollider, boxCollider, true);
                        }
                    }
                    break;

                case false:
                    if (contactPoint.x > (center.x - 4f))
                    {
                        float distance = Mathf.Abs((center.x + sides.x) - (characterJumpFinalPosition - characterSides.x));
                        Vector2 rivalToPosition = new Vector2(center.x - distance, rivalCharacter.transform.position.y);
                        StartCoroutine(LerpPosition(rivalOriginalPosition, rivalToPosition, 0.17f, rivalRigidBody));
                        Physics2D.IgnoreCollision(rivalBoxCollider, boxCollider, true);

                    }
                    else
                    {
                        if (screenDistance == "Mid-screen" && rivalCharacter.transform.position.x > ScreenDistances.SCREEN_RIGHT)
                        { /// Behaviour when rival character is against the right wall
                            float distance = Mathf.Abs((characterJumpFinalPosition + characterSides.x) - (center.x - sides.x));

                            Vector2 characterToPosition = new Vector2(boxCollider.bounds.center.x - distance, rivalCharacter.transform.position.y);
                            StartCoroutine(LerpPosition(rivalOriginalPosition, characterToPosition, 0.07f, rigidBody));
                            Physics2D.IgnoreCollision(rivalBoxCollider, boxCollider, true);
                        }
                        else
                        {                                                                                           ////Normal behaviour
                            float distance = Mathf.Abs((characterSides.x + characterJumpFinalPosition) - (center.x - sides.x));
                            Vector2 rivalToPosition = new Vector2(center.x + distance, rivalCharacter.transform.position.y);
                            StartCoroutine(LerpPosition(rivalOriginalPosition, rivalToPosition, 0.17f, rivalRigidBody));
                            Physics2D.IgnoreCollision(rivalBoxCollider, boxCollider, true);
                        }
                    }
                    break;
            }
        }


    }

    IEnumerator LerpPosition(Vector2 startPosition, Vector2 toPosition, float duration, Rigidbody2D rigidBody)
    {
        float time = 0;
        while (time < duration)
        {
            rigidBody.MovePosition(Vector2.Lerp(startPosition, toPosition, time / duration));
            time += Time.deltaTime;
            yield return null;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (currentCharacter.GetIsJumping())
        {
            if (col.gameObject.tag == "Player1" || col.gameObject.tag == "Player2")
            {
                JumpingOverCharacter(col);
            }
        }
    }
    /////////////////

    void Update()
    {
        if ((currentCharacter.IsAnimationPlaying() && !currentCharacter.GetIsJumping() && !currentCharacter.GetIsHit())
                || currentCharacter.GetAnimationStatus() == AnimationStates.STANDING)
        { //In case the animation goes from walking to other animation, prevents from sliding behaviour
            rigidBody.velocity = new Vector2(0, 0);
        }

        if (!currentCharacter.GetIsBlocked())
        {
            ///Moving
            animator.SetFloat("Horizontal", 0);  //Sets the horizontal back to 0 so that the animator can move from walking to standing (if not, loops the walking animation)


            if ((Input.GetKey(GameConstants.R)) || (Input.GetKey(GameConstants.L)))
            {
                characterActions.Walk(rigidBody, animator);
            }

            //Blocking
            if ((Input.GetKey(GameConstants.R)) && currentCharacter.GetIsFlipped() || (Input.GetKey(GameConstants.L)) && !currentCharacter.GetIsFlipped())
            {
                characterActions.Block();
            }


            // Crouching
            if (Input.GetKey(GameConstants.D) && !currentCharacter.IsAnimationPlaying() && !currentCharacter.GetIsCrouching() && !currentCharacter.GetIsJumping())
            {
                rigidBody.velocity = new Vector2(0, 0); //Prevents from sliding
                SetCoordinatesWhenLanding(); //Prevents from phasing through the ground if the down button is pressed when the character touches the ground after a jump.
                currentCharacter.PlayAnimation(AnimationStates.CROUCH);
                currentCharacter.SetAnimationStatus(AnimationStates.CROUCH);
                currentCharacter.SetIsCrouching(true);
                currentCharacter.SetAnimationPlaying(false);
            }

            if (Input.GetKeyUp(GameConstants.D) && !currentCharacter.GetIsJumping())
            {
                //SetCoordinatesWhenLanding();
                currentCharacter.SetIsCrouching(false);
                if (!currentCharacter.IsAnimationPlaying())
                {
                    currentCharacter.EndAnimation(AnimationStates.STANDING);
                }
            }

            // Jumping
            if (Input.GetKeyDown(GameConstants.U) && !currentCharacter.IsAnimationPlaying() && !currentCharacter.GetIsCrouching() && !currentCharacter.GetIsJumping())
            {
                screenDistance = characterActions.GetPositionBetweenCharacters();
                if ((screenDistance == "In-close" || screenDistance == "Poke-range")
                    && (rivalCharacter.transform.position.x > ScreenDistances.SCREEN_LEFT && rivalCharacter.transform.position.x < ScreenDistances.SCREEN_RIGHT))
                {
                    Physics2D.IgnoreCollision(rivalBoxCollider, boxCollider, true);

                }
                currentCharacter.SetIsJumping(true);
                rigidBody.velocity = Vector2.up * 200f;   ///Force necessary to break free from gravity
				if (Input.GetKey(GameConstants.R))
                {
                    rigidBody.velocity += Vector2.right * 70f;
                    switch (currentCharacter.GetIsFlipped())
                    {
                        case true:
                            currentCharacter.SetAnimationStatus(AnimationStates.JUMPING_BACKWARDS);
                            currentCharacter.PlayAnimation(AnimationStates.JUMPING_BACKWARDS);
                            break;
                        case false:
                            currentCharacter.SetAnimationStatus(AnimationStates.JUMPING_FORWARDS);
                            currentCharacter.PlayAnimation(AnimationStates.JUMPING_FORWARDS);
                            break;
                    }
                }
                else if (Input.GetKey(GameConstants.L))
                {
                    rigidBody.velocity += Vector2.left * 70f;
                    switch (currentCharacter.GetIsFlipped())
                    {
                        case true:
                            currentCharacter.SetAnimationStatus(AnimationStates.JUMPING_FORWARDS);
                            currentCharacter.PlayAnimation(AnimationStates.JUMPING_FORWARDS);
                            break;
                        case false:
                            currentCharacter.SetAnimationStatus(AnimationStates.JUMPING_BACKWARDS);
                            currentCharacter.PlayAnimation(AnimationStates.JUMPING_BACKWARDS);
                            break;
                    }
                }
                else
                {
                    currentCharacter.SetAnimationStatus(AnimationStates.JUMPING_UP);
                    currentCharacter.PlayAnimation(AnimationStates.JUMPING_UP);
                }
                characterSoundEffect.PlayCharacterSoundEffect("Jump");
                CalculateJumpingDestination(boxCollider.bounds.center.x);

                currentCharacter.SetAnimationPlaying(false);
            }
        }
    }

}
