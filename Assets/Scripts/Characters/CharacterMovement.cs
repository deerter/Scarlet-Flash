﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {
	

	private Animator animator;
	private CharacterFeatures currentCharacter;
	private Rigidbody2D rb;

	void Start(){
		rb = this.GetComponent<Rigidbody2D>();
		currentCharacter = this.GetComponent<CharacterFeatures>();
		animator = currentCharacter.GetAnimator();
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
				rb.MovePosition(rb.position + horizontal * Time.fixedDeltaTime * 50f);   ///Uses MovePosition because both transform and rb.position makes the character phase through when pushing the rival on the edge of the screen.
																						//Uses Time.fixedDeltaTime instead of Time.deltaTime because MovePosition works with physics (as does fixedDeltaTime)
			}
		}

		// Crouching
		if (Input.GetKey(GameConstants.D) && !currentCharacter.IsAnimationPlaying() && !(currentCharacter.GetIsCrouching())){
			currentCharacter.PlayAnimation(AnimationStates.CROUCH);
			currentCharacter.SetAnimationStatus(AnimationStates.CROUCH);
			currentCharacter.SetIsCrouching(true);
			currentCharacter.SetAnimationPlaying(false);
		}

		if (Input.GetKeyUp(GameConstants.D))
        {
			currentCharacter.SetIsCrouching(false);
			if(!currentCharacter.IsAnimationPlaying()){
				currentCharacter.EndAnimation(AnimationStates.STANDING);
			}
        }

		
		
		
	}

	
}
