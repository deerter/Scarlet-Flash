using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {
	

	private Animator animator;
	private CharacterFeatures currentCharacter;
	private Rigidbody2D rb;


	public void KeepCrouching(){
		if (currentCharacter.GetIsCrouching()){
			animator.speed=0.7f;  //Decrease speed of animation
			animator.Play("Crouching",0,0.29f);  //Loop from 3rd frame of animation
		}
	}

	void Start(){
		rb = this.GetComponent<Rigidbody2D>();
		currentCharacter = this.GetComponent<CharacterFeatures>();
		animator = currentCharacter.GetAnimator();
	}
	
	
	void Update () {

		///Directional Pad
		animator.SetFloat("Horizontal", 0);  //Sets the horizontal back to 0 so that the animator can move from walking to standing (if not, loops the walking animation)
		if ((currentCharacter.GetAnimationStatus() == AnimationStates.STANDING) ||
			 (currentCharacter.GetAnimationStatus() == AnimationStates.WALK_FORWARDS) || 
			 	(currentCharacter.GetAnimationStatus() == AnimationStates.WALK_BACKWARDS)){
			if ((Input.GetKey(GameConstants.R)) || (Input.GetKey(GameConstants.L))){
				animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
				Vector2 horizontal = new Vector2(Input.GetAxis("Horizontal"), 0.0f); 
				rb.MovePosition(rb.position + horizontal * Time.fixedDeltaTime * 50f);   ///Uses MovePosition because both transform and rb.position makes the character phase through when pushing the rival on the edge of the screen.
																						//Uses Time.fixedDeltaTime instead of Time.deltaTime because MovePosition works with physics (as does fixedDeltaTime)
			}
		}

		if (Input.GetKey(GameConstants.D) && !currentCharacter.IsAnimationPlaying()){
			currentCharacter.PlayAnimation(AnimationStates.CROUCHING);
			currentCharacter.SetAnimationStatus(AnimationStates.CROUCHING);
			currentCharacter.SetIsCrouching(true);
		}

		if (Input.GetKeyUp(GameConstants.D) && (currentCharacter.GetIsCrouching()))
        {
			currentCharacter.SetIsCrouching(false);
			currentCharacter.EndAnimation(AnimationStates.STANDING);
			animator.speed = 1;
        }

		
		
		
	}

	
}
