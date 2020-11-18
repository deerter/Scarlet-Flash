using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {
	

	public Animator animator;

	//bool jump = false;
	bool onAnimation = false;   ///Used to not enter other animations when the current one has finished and a button has been pressed during this one.

	public void EndingCurrentAnimation(string action){
		animator.SetBool(action, false);
		onAnimation = false;
	}

	public void KeepCrouching(){
		if (animator.GetBool("Crouching")){
			animator.speed=0.7f;  //Decrease speed of animation
			animator.Play("Crouching",0,0.29f);  //Loop from 3rd frame of animation
		}
	}
	
	// Update is called once per frame
	void Update () {

		///Directional Pad
		animator.SetFloat("Horizontal", 0);  //Sets the horizontal back to 0 so that the animator can move from walking to standing (if not, loops the walking animation)
		if ((animator.GetCurrentAnimatorStateInfo(0).IsName("Standing")) ||
			 (animator.GetCurrentAnimatorStateInfo(0).IsName("WalkForwards")) || 
			 	(animator.GetCurrentAnimatorStateInfo(0).IsName("WalkBackwards"))){
			if ((Input.GetKey(GameConstants.R)) || (Input.GetKey(GameConstants.L))){
				animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
				Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
				transform.position = transform.position + horizontal * (0.9f);
			}
		}

		if (Input.GetKey(GameConstants.D) && onAnimation==false){
			animator.SetBool("Crouching", true);
			onAnimation = true;
		}

		if (Input.GetKeyUp(GameConstants.D) && (animator.GetBool("Crouching")))
        {
			animator.SetBool("Crouching", false);
			onAnimation = false;
			animator.speed = 1;
        }

		///Attacks
		if (Input.GetKeyDown(GameConstants.LP) && onAnimation==false){
			animator.SetBool("LightPunch", true);
			onAnimation = true;
		}

		if (Input.GetKeyDown(GameConstants.LK) && onAnimation==false){
			animator.SetBool("LightKick", true);
			onAnimation = true;
		}

		if (Input.GetKeyDown(GameConstants.HP) && onAnimation==false){
			animator.SetBool("HeavyPunch", true);
			onAnimation = true;
		}

		if (Input.GetKeyDown(GameConstants.HK) && onAnimation==false){
			animator.SetBool("HeavyKick", true);
			onAnimation = true;
		}

		
		
	}

	
}
