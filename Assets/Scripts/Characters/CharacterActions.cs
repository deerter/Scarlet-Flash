using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterActions : MonoBehaviour
{
    [SerializeField] private GameObject characterSoundEffectPlayer;
    [SerializeField] private GameObject rivalCharacters;
    [SerializeField] private LayerMask groundLayerMask;
    private CharacterFeatures currentCharacter;
    private CharacterSoundEffect characterSoundEffect;
    private BoxCollider2D boxCollider;
    private BoxCollider2D rivalBoxCollider;
    private GameObject rivalCharacter;
    private Rigidbody2D rigidBody;
    private float characterJumpFinalPosition;
    private string screenDistance;
    private Vector3 characterSides;  ///Refers to 1/2 the width of the current character's box collider. Used to calculate collisions when jumping over rival.

    //// Plays the animation of the given attack and its sound effect
    public void PerformAttack(string attack)
    {
        if (!currentCharacter.GetIsJumping())
        {
            rigidBody.velocity = new Vector2(0, 0);
        }
        characterSoundEffect.PlayCharacterSoundEffect("Attack");
        currentCharacter.PlayAnimation(attack);
        currentCharacter.SetAnimationStatus(attack);
    }

    /// Moves the character forwards or backwards
    public void Walk(Rigidbody2D rigidBody, Animator animator, string direction)
    {
        if ((currentCharacter.GetAnimationStatus() == AnimationStates.STANDING) ||
            (currentCharacter.GetAnimationStatus() == AnimationStates.WALK_FORWARDS) ||
                (currentCharacter.GetAnimationStatus() == AnimationStates.WALK_BACKWARDS))
        {
            Vector2 horizontal = new Vector2(0, 0);
            if (direction == AnimationStates.WALK_FORWARDS)
            {
                switch (currentCharacter.GetIsFlipped())
                {
                    case true: animator.SetFloat("Horizontal", 1); horizontal = new Vector2(-animator.GetFloat("Horizontal"), 0.0f); break;
                    case false: animator.SetFloat("Horizontal", 1); horizontal = new Vector2(animator.GetFloat("Horizontal"), 0.0f); break;
                }
            }
            else if (direction == AnimationStates.WALK_BACKWARDS)
            {
                switch (currentCharacter.GetIsFlipped())
                {
                    case true: animator.SetFloat("Horizontal", -1); horizontal = new Vector2(-animator.GetFloat("Horizontal"), 0.0f); break;
                    case false: animator.SetFloat("Horizontal", -1); horizontal = new Vector2(animator.GetFloat("Horizontal"), 0.0f); break;
                }
            }

            rigidBody.velocity = horizontal * 3000f * Time.fixedDeltaTime;
            //Uses Time.fixedDeltaTime instead of Time.deltaTime because MovePosition works with physics (as does fixedDeltaTime)
        }
    }

    /// Makes the character jump upwards, forwards or backwards depending on the direction given
    public void Jump(Rigidbody2D rigidBody, string direction)
    {
        screenDistance = GetPositionBetweenCharacters();
        /// If rival is not in the air and screen distance is close (and not on corners), disable collision system
        if ((screenDistance == "In-close" || screenDistance == "Poke-range")
            && (rivalCharacter.transform.position.x > ScreenDistances.SCREEN_LEFT && rivalCharacter.transform.position.x < ScreenDistances.SCREEN_RIGHT)
            && !(rivalCharacter.GetComponent<CharacterFeatures>().GetIsJumping()))
        {
            Physics2D.IgnoreCollision(rivalBoxCollider, boxCollider, true);
        }
        /// If rival is already in the air, turn on the collision system
        if (rivalCharacter.GetComponent<CharacterFeatures>().GetIsJumping())
        {
            Physics2D.IgnoreCollision(rivalBoxCollider, boxCollider, false);
        }
        currentCharacter.SetIsJumping(true);
        rigidBody.velocity = Vector2.up * 200f;   ///Force necessary to break free from gravity
        switch (direction)
        {
            case "JumpingRight":
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
                break;
            case "JumpingLeft":
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
                break;
            case "JumpingUp":
                currentCharacter.SetAnimationStatus(AnimationStates.JUMPING_UP);
                currentCharacter.PlayAnimation(AnimationStates.JUMPING_UP);
                break;
        }
        characterSoundEffect.PlayCharacterSoundEffect("Jump");
        CalculateJumpingDestination(rigidBody, boxCollider.bounds.center.x);

        currentCharacter.SetAnimationPlaying(false);
    }

    /// Character is blocking 
    public void Block()
    {
        if ((currentCharacter.GetAnimationStatus() == AnimationStates.WALK_BACKWARDS)
            || ((currentCharacter.GetIsCrouching() || currentCharacter.GetIsJumping()) && !currentCharacter.IsAnimationPlaying()))
        {
            currentCharacter.SetIsBlocking(true);
        }
    }

    /// Character stops blocking
    public void StopBlocking()
    {
        currentCharacter.SetIsBlocking(false);
    }

    ////Get final position of a jump//////////
    private void CalculateJumpingDestination(Rigidbody2D rigidBody, float jumpOriginPosition)
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


    ///////Character collision when jumping over other character
    private void JumpingOverCharacter(Collision2D col)
    {
        currentCharacter.EndAnimation(AnimationStates.JUMPING_DOWN);
        GameObject rivalCharacter = rivalCharacters.transform.GetChild(0).gameObject;
        Rigidbody2D rivalRigidBody = col.gameObject.GetComponent<Rigidbody2D>();
        ContactPoint2D[] contacts = new ContactPoint2D[10];
        col.GetContacts(contacts);
        //Vector3 contactPoint = col.contacts[0].point;
        Vector3 contactPoint = contacts[0].point;
        Vector3 center = rivalBoxCollider.bounds.center;
        Vector3 sides = rivalBoxCollider.bounds.extents;
        Vector2 rivalOriginalPosition = new Vector2(center.x, rivalCharacter.transform.position.y);
        float offsetDistance = 5f;
        //float bottomSide = center.y - sides.y;

        if (screenDistance != "In-close" && screenDistance != "Poke-range")
        {
            switch (currentCharacter.GetIsFlipped())
            {
                case true:
                    if (contactPoint.x < (center.x + 4f))
                    {
                        float distance = Mathf.Abs((characterSides.x + characterJumpFinalPosition) - (center.x - sides.x)) + offsetDistance;
                        Vector2 rivalToPosition = new Vector2(center.x + distance, rivalCharacter.transform.position.y); ///center.y
                        StartCoroutine(LerpPosition(rivalOriginalPosition, rivalToPosition, 0.17f, rivalRigidBody));
                        Physics2D.IgnoreCollision(rivalBoxCollider, boxCollider, true);

                    }
                    else
                    {
                        if (screenDistance == "Mid-screen" && rivalCharacter.transform.position.x < ScreenDistances.SCREEN_LEFT)
                        { /// Behaviour when rival character is against the left wall
                            Vector2 characterOriginalPosition = new Vector2(this.transform.position.x, this.transform.position.y);
                            Vector2 characterToPosition = new Vector2(boxCollider.bounds.center.x, rivalCharacter.transform.position.y);
                            StartCoroutine(LerpPosition(characterOriginalPosition, characterToPosition, 0.15f, rigidBody));
                            Physics2D.IgnoreCollision(rivalBoxCollider, boxCollider, true);
                        }
                        else
                        {                                                                                                   ////Normal behaviour
                            float distance = Mathf.Abs((center.x + sides.x) - (characterJumpFinalPosition - characterSides.x)) + offsetDistance;
                            Vector2 rivalToPosition = new Vector2(center.x - distance, rivalCharacter.transform.position.y);
                            StartCoroutine(LerpPosition(rivalOriginalPosition, rivalToPosition, 0.17f, rivalRigidBody));
                            Physics2D.IgnoreCollision(rivalBoxCollider, boxCollider, true);
                        }
                    }
                    break;

                case false:
                    if (contactPoint.x > (center.x - 4f))
                    {
                        float distance = Mathf.Abs((center.x + sides.x) - (characterJumpFinalPosition - characterSides.x)) + offsetDistance;
                        Vector2 rivalToPosition = new Vector2(center.x - distance, rivalCharacter.transform.position.y);
                        StartCoroutine(LerpPosition(rivalOriginalPosition, rivalToPosition, 0.17f, rivalRigidBody));
                        Physics2D.IgnoreCollision(rivalBoxCollider, boxCollider, true);

                    }
                    else
                    {
                        if (screenDistance == "Mid-screen" && rivalCharacter.transform.position.x > ScreenDistances.SCREEN_RIGHT)
                        { /// Behaviour when rival character is against the right wall
                            Vector2 characterOriginalPosition = new Vector2(this.transform.position.x, this.transform.position.y);
                            Vector2 characterToPosition = new Vector2(boxCollider.bounds.center.x, rivalCharacter.transform.position.y);
                            StartCoroutine(LerpPosition(characterOriginalPosition, characterToPosition, 0.15f, rigidBody));
                            Physics2D.IgnoreCollision(rivalBoxCollider, boxCollider, true);
                        }
                        else
                        {                                                                                           ////Normal behaviour
                            float distance = Mathf.Abs((characterSides.x + characterJumpFinalPosition) - (center.x - sides.x)) + offsetDistance;
                            Vector2 rivalToPosition = new Vector2(center.x + distance, rivalCharacter.transform.position.y);
                            StartCoroutine(LerpPosition(rivalOriginalPosition, rivalToPosition, 0.17f, rivalRigidBody));
                            Physics2D.IgnoreCollision(rivalBoxCollider, boxCollider, true);
                        }
                    }
                    break;
            }
        }
        else
        {
            float offset = 5f;
            Vector2 rivalToPosition;
            switch (rivalCharacter.transform.GetComponent<CharacterFeatures>().GetIsFlipped())
            {
                case true:
                    rivalToPosition = new Vector2(rivalCharacter.transform.position.x + sides.x + offset, rivalCharacter.transform.position.y);
                    StartCoroutine(LerpPosition(rivalOriginalPosition, rivalToPosition, 0.02f, rivalRigidBody));
                    Physics2D.IgnoreCollision(rivalBoxCollider, boxCollider, true);
                    break;
                case false:
                    rivalToPosition = new Vector2(rivalCharacter.transform.position.x - sides.x - offset, rivalCharacter.transform.position.y);
                    StartCoroutine(LerpPosition(rivalOriginalPosition, rivalToPosition, 0.02f, rivalRigidBody));
                    Physics2D.IgnoreCollision(rivalBoxCollider, boxCollider, true);
                    break;
            }
        }

    }



    ///// Move character to new position
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


    ///// Executes when there's a collision between the characters
    void OnCollisionEnter2D(Collision2D col)
    {
        if (currentCharacter.GetIsJumping() && !rivalCharacter.GetComponent<CharacterFeatures>().GetIsJumping())
        {
            if (col.gameObject.tag == "Player1" || col.gameObject.tag == "Player2")
            {
                JumpingOverCharacter(col);
            }
        }
        if (rivalCharacter.GetComponent<CharacterFeatures>().GetIsJumping() && currentCharacter.GetIsJumping())
        {
            switch (currentCharacter.GetIsFlipped())
            {
                case true: rigidBody.AddForce(Vector2.right * 400f, ForceMode2D.Impulse); break;
                case false: rigidBody.AddForce(Vector2.left * 400f, ForceMode2D.Impulse); break;
            }
        }
    }

    ////// Check if characters are on top of each other
    void CheckOnTopJumping()
    {
        if (!currentCharacter.GetIsJumping() && (rivalCharacter.GetComponent<CharacterFeatures>().GetAnimationStatus() == AnimationStates.JUMPING_UP))
        /*|| (rivalCharacter.GetComponent<CharacterFeatures>().GetAnimationStatus() == AnimationStates.JUMPING_BACKWARDS && (
            rivalCharacter.transform.position.x >= ScreenDistances.SCREEN_RIGHT || rivalCharacter.transform.position.x >= ScreenDistances.SCREEN_LEFT))))*/
        {
            switch (currentCharacter.GetIsFlipped())
            {
                case true:
                    if (rivalCharacter.transform.position.x >= this.transform.position.x - characterSides.x)
                    {
                        Physics2D.IgnoreCollision(rivalBoxCollider, boxCollider, false);
                    }
                    break;
                case false:
                    if (rivalCharacter.transform.position.x <= this.transform.position.x + characterSides.x)
                    {
                        Physics2D.IgnoreCollision(rivalBoxCollider, boxCollider, false);
                    }
                    break;
            }
        }
    }

    //// Checks if character is still crouching after performing a crouching attack so that it doesn't go to Crouching by default
    public void IsCharacterStillCrouching()
    {
        if (currentCharacter.GetIsCrouching())
        {
            currentCharacter.EndAnimation(AnimationStates.CROUCHING);
        }
        else
        {
            currentCharacter.EndAnimation(AnimationStates.STANDING);
        }
    }

    //// Checks if character has touched the ground, if so, changes the animation to landing.
    public void CharacterIsGrounded()
    {
        BoxCollider2D boxCollider = currentCharacter.GetComponent<BoxCollider2D>();
        float extraHeightText = 1.0f;
        ///Check if character collider is touching another collider
        if ((Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, extraHeightText, groundLayerMask).collider) != null)
        {
            characterSoundEffect.PlayCharacterSoundEffect("Landing");
            currentCharacter.EndAnimation(AnimationStates.LANDING);
        }
    }

    ///Sets the Y on the character to the one it has when standing. If this isn't done, the character phases through the ground as the box collider changes shape between animations.
    public void SetCoordinatesWhenLanding()
    {
        if (currentCharacter.GetAnimationStatus() == AnimationStates.BLOCKING_JUMPING || currentCharacter.GetAnimationStatus() == AnimationStates.TAKING_DAMAGE_JUMPING)
        {
            currentCharacter.HitEnding();
        }
        transform.position = new Vector3(transform.position.x, -12.58f, transform.position.z);
        currentCharacter.SetIsJumping(false);
        Physics2D.IgnoreCollision(rivalBoxCollider, boxCollider, false);   //In the case the character collisions with its rival during jumping, the collision is ignored. This sets collisions as not ignored again.
    }

    ////Get the screen distance between the two characters//////
    public string GetPositionBetweenCharacters()
    {
        if (Mathf.Abs(this.transform.position.x - rivalCharacter.transform.position.x) > ScreenDistances.IN_CLOSE
            && Mathf.Abs(this.transform.position.x - rivalCharacter.transform.position.x) < ScreenDistances.POKE_RANGE)
        {
            return "In-close";
        }
        else if (Mathf.Abs(this.transform.position.x - rivalCharacter.transform.position.x) > ScreenDistances.POKE_RANGE
            && Mathf.Abs(this.transform.position.x - rivalCharacter.transform.position.x) < ScreenDistances.MID_SCREEN)
        {
            return "Poke-range";
        }
        else if (Mathf.Abs(this.transform.position.x - rivalCharacter.transform.position.x) > ScreenDistances.MID_SCREEN
            && Mathf.Abs(this.transform.position.x - rivalCharacter.transform.position.x) < ScreenDistances.FULL_SCREEN)
        {
            return "Mid-screen";
        }
        else
        {
            return "Full-screen";
        }
    }


    // Use this for initialization
    void Start()
    {
        currentCharacter = this.GetComponent<CharacterFeatures>();
        rivalCharacter = rivalCharacters.transform.GetChild(0).gameObject;
        characterSoundEffect = characterSoundEffectPlayer.GetComponent<CharacterSoundEffect>();
        boxCollider = this.GetComponent<BoxCollider2D>();
        characterSides = boxCollider.bounds.extents;
        rigidBody = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rivalCharacter = rivalCharacters.transform.GetChild(0).gameObject;  //Has to be done constantly in case it changes
        rivalBoxCollider = rivalCharacters.transform.GetChild(0).GetComponent<BoxCollider2D>();
        CheckOnTopJumping();
    }

}
