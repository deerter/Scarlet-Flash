using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {
	
	
	private CharacterFeatures currentCharacter;
	private Animator animator;
	private Rigidbody2D rigidBody;
	private BoxCollider2D boxCollider;

	void Start(){
		currentCharacter = this.GetComponent<CharacterFeatures>();
		animator = currentCharacter.GetAnimator();
		rigidBody = this.GetComponent<Rigidbody2D>();
		boxCollider = this.GetComponent<BoxCollider2D>();
	}

	/*public void falling(){       ///////JUST IN CASE/////////////Loops last frames of falling animation
		animator.Play(AnimationStates.JUMPING_DOWN,0,0.5f);
	}*/

	public void CharacterIsGrounded(){
		float extraHeightText = 0.01f;
		if ((Physics2D.Raycast(boxCollider.bounds.center, Vector2.down, boxCollider.bounds.extents.y + extraHeightText).collider) != null){  ///Check if character collider is touching another collider
			currentCharacter.EndAnimation(AnimationStates.STANDING);
			currentCharacter.SetIsJumping(false);
		}
	}

	
	
	
	void Update () {

		///Moving
		animator.SetFloat("Horizontal", 0);  //Sets the horizontal back to 0 so that the animator can move from walking to standing (if not, loops the walking animation)
		if ((currentCharacter.GetAnimationStatus() == AnimationStates.STANDING) ||
			 (currentCharacter.GetAnimationStatus() == AnimationStates.WALK_FORWARDS) || 
			 	(currentCharacter.GetAnimationStatus() == AnimationStates.WALK_BACKWARDS)){
			if ((Input.GetKey(GameConstants.R)) || (Input.GetKey(GameConstants.L))){
				animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
				Vector2 horizontal = new Vector2(Input.GetAxis("Horizontal"), 0.0f); 
				rigidBody.MovePosition(rigidBody.position + horizontal * Time.fixedDeltaTime * 50f);   ///Uses MovePosition because both transform and rb.position makes the character phase through when pushing the rival on the edge of the screen.
																						//Uses Time.fixedDeltaTime instead of Time.deltaTime because MovePosition works with physics (as does fixedDeltaTime)
			}
		}

		// Crouching
		if (Input.GetKey(GameConstants.D) && !currentCharacter.IsAnimationPlaying() && !currentCharacter.GetIsCrouching() && !currentCharacter.GetIsJumping()){
			currentCharacter.PlayAnimation(AnimationStates.CROUCH);
			currentCharacter.SetAnimationStatus(AnimationStates.CROUCH);
			currentCharacter.SetIsCrouching(true);
			currentCharacter.SetAnimationPlaying(false);
		}

		if (Input.GetKeyUp(GameConstants.D) && !currentCharacter.GetIsJumping())
        {
			currentCharacter.SetIsCrouching(false);
			if(!currentCharacter.IsAnimationPlaying()){
				currentCharacter.EndAnimation(AnimationStates.STANDING);
			}
        }

		// Jumping
		if (Input.GetKeyDown(GameConstants.U) && !currentCharacter.IsAnimationPlaying() && !currentCharacter.GetIsCrouching() && !currentCharacter.GetIsJumping()){
			currentCharacter.SetIsJumping(true);
			rigidBody.velocity = Vector2.up * 160f;   ///Force necessary to break free from gravity
			if (Input.GetKey(GameConstants.R)){
				rigidBody.velocity += Vector2.right * 50f;
				currentCharacter.SetAnimationStatus(AnimationStates.JUMPING_FORWARDS);
				currentCharacter.PlayAnimation(AnimationStates.JUMPING_FORWARDS);
			}
			else if(Input.GetKey(GameConstants.L)){
				rigidBody.velocity += Vector2.left * 50f;
				currentCharacter.SetAnimationStatus(AnimationStates.JUMPING_BACKWARDS);
				currentCharacter.PlayAnimation(AnimationStates.JUMPING_BACKWARDS);
			}
			else{
				currentCharacter.SetAnimationStatus(AnimationStates.JUMPING_UP);
				currentCharacter.PlayAnimation(AnimationStates.JUMPING_UP);
			}	
		}
		
		
	}

	
}
