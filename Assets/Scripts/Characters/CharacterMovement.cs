using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {
	

	public Animator animator;

	public void EndingCurrentAnimation(string action){
		animator.SetBool(action, false);
	}

	public void KeepCrouching (){
		animator.SetBool("Crouching", false);
		animator.SetBool("Crouched", true);
	}
	
	// Update is called once per frame
	void Update () {

		animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
		Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
		transform.position = transform.position + horizontal * ((float)0.8);

		if (Input.GetKeyDown(GameConstants.LP)){
			animator.SetBool("LightPunch", true);
		}

		if (Input.GetKeyDown(GameConstants.LK)){
			animator.SetBool("LightKick", true);
		}

		if (Input.GetKeyDown(GameConstants.HP)){
			animator.SetBool("HeavyPunch", true);
		}

		if (Input.GetKeyDown(GameConstants.HK)){
			animator.SetBool("HeavyKick", true);
		}

		if (Input.GetKey(GameConstants.D) && !(animator.GetBool("Crouched"))){
			animator.SetBool("Crouching", true);
		}

		if (Input.GetKeyUp(GameConstants.D) && (animator.GetBool("Crouched")))
        {
            animator.SetBool("Crouched", false);
        }
		
	}
}
