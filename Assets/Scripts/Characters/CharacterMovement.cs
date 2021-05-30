using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{


    private CharacterFeatures currentCharacter;
    private CharacterActions characterActions;
    private Animator animator;
    private Rigidbody2D rigidBody;

    private float characterJumpFinalPosition;  ///Needed to assess the final position of a jump




    void Start()
    {
        currentCharacter = this.GetComponent<CharacterFeatures>();
        characterActions = this.GetComponent<CharacterActions>();
        animator = currentCharacter.GetAnimator();
        rigidBody = this.GetComponent<Rigidbody2D>();


    }

    /*public void falling(){       ///////JUST IN CASE/////////////Loops last frames of falling animation
		animator.Play(AnimationStates.JUMPING_DOWN,0,0.5f);
	}*/

    /////////////////

    void Update()
    {
        if ((currentCharacter.IsAnimationPlaying() && !currentCharacter.GetIsJumping() && !currentCharacter.GetIsHit()))
        { //In case the animation goes from walking to other animation, prevents from sliding behaviour
            rigidBody.velocity = new Vector2(0, 0);
        }

        if (!currentCharacter.GetIsBlocked())
        {
            ///Moving
            animator.SetFloat("Horizontal", 0);  //Sets the horizontal back to 0 so that the animator can move from walking to standing (if not, loops the walking animation)

            // When character moves right (depending on side of the field)
            if ((Input.GetKey(GameConstants.R)))
            {
                switch (currentCharacter.GetIsFlipped())
                {
                    case true: characterActions.Walk(rigidBody, animator, AnimationStates.WALK_BACKWARDS); break;
                    case false: characterActions.Walk(rigidBody, animator, AnimationStates.WALK_FORWARDS); break;
                }

            }
            // When character moves left (depending on side of the field)
            else if ((Input.GetKey(GameConstants.L)))
            {
                switch (currentCharacter.GetIsFlipped())
                {
                    case true: characterActions.Walk(rigidBody, animator, AnimationStates.WALK_FORWARDS); break;
                    case false: characterActions.Walk(rigidBody, animator, AnimationStates.WALK_BACKWARDS); break;
                }
            }

            if (Input.GetKeyUp(GameConstants.L) || Input.GetKeyUp(GameConstants.R))
            {
                characterActions.StopBlocking();
                if (currentCharacter.GetAnimationStatus() == AnimationStates.WALK_BACKWARDS || currentCharacter.GetAnimationStatus() == AnimationStates.WALK_FORWARDS)
                {
                    rigidBody.velocity = new Vector2(0, 0);
                }
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
                characterActions.SetCoordinatesWhenLanding(); //Prevents from phasing through the ground if the down button is pressed when the character touches the ground after a jump.
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

                if (Input.GetKey(GameConstants.R))
                {
                    characterActions.Jump(rigidBody, "JumpingRight");
                }
                else if (Input.GetKey(GameConstants.L))
                {
                    characterActions.Jump(rigidBody, "JumpingLeft");
                }
                else
                {
                    characterActions.Jump(rigidBody, "JumpingUp");
                }

            }
        }
    }

}
