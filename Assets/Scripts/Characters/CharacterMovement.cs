using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {
	
	
	[SerializeField] private LayerMask groundLayerMask;
	public GameObject rivalCharacter;
	private CharacterFeatures currentCharacter;
	private Animator animator;
	private Rigidbody2D rigidBody;
	private BoxCollider2D boxCollider;
	private BoxCollider2D rivalBoxCollider;


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
		float extraHeightText = 1.0f;
		/*if ((Physics2D.Raycast(boxCollider.bounds.center, Vector2.down, boxCollider.bounds.extents.y + extraHeightText, groundLayerMask).collider) != null){  
			currentCharacter.EndAnimation(AnimationStates.STANDING);
			currentCharacter.SetIsJumping(false);
		}*/
		///Check if character collider is touching another collider
		if ((Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, extraHeightText, groundLayerMask).collider) != null){
			currentCharacter.EndAnimation(AnimationStates.LANDING);
			currentCharacter.SetIsJumping(false);
			Physics2D.IgnoreCollision(rivalBoxCollider, boxCollider, false);   //In the case the character collisions with its rival during jumping, the collision is ignored. This sets collisions as not ignored again.
		}
		/*Debug.DrawRay(boxCollider.bounds.center + new Vector3(boxCollider.bounds.extents.x, 0), Vector2.down * (boxCollider.bounds.extents.y + extraHeightText));
		Debug.DrawRay(boxCollider.bounds.center - new Vector3(boxCollider.bounds.extents.x, boxCollider.bounds.extents.y + extraHeightText), Vector2.right * (boxCollider.bounds.extents.y));*/  ////Debug to check if the boxcast touches the ground
	}

	public void SetCoordinatesWhenLanding(){ ///Sets the Y on the character to the one it has when standing. If this isn't done, the character phases through the ground as the box collider changes shape between animations.
		transform.position = new Vector3(transform.position.x, 19.21687f, transform.position.z);
	}

	private void JumpingOverCharacter(Collision2D col){
		currentCharacter.EndAnimation(AnimationStates.JUMPING_DOWN);

		rivalBoxCollider = col.gameObject.GetComponent<BoxCollider2D>();  
		Rigidbody2D rivalRigidBody = col.gameObject.GetComponent<Rigidbody2D>();
		Vector3 contactPoint = col.contacts[0].point;
        Vector3 center = col.collider.bounds.center;
		//Vector3 sides = col.collider.bounds.extents;
		if (contactPoint.x > center.x){
			print("cobrar");

		}else {
			float distance = col.collider.bounds.size.x/2;

			

			Vector2 rivalToPosition = new Vector2(col.gameObject.transform.position.x + distance,col.gameObject.transform.position.y);
			Vector2 toPosition = new Vector2(gameObject.transform.position.x,gameObject.transform.position.y);


			StartCoroutine(LerpPosition(col.gameObject.transform.position, rivalToPosition, 0.17f, rivalRigidBody));

			//rigidBody.MovePosition (Vector2.Lerp(gameObject.transform.position,toPosition,Time.fixedDeltaTime * 40));  //37
			//rivalRigidBody.MovePosition (Vector2.Lerp(col.gameObject.transform.position,rivalToPosition,Time.fixedDeltaTime * 40));
			Physics2D.IgnoreCollision(rivalBoxCollider, boxCollider, true);
		}
		//currentCharacter.EndAnimation(AnimationStates.JUMPING_DOWN);   
	}

	IEnumerator LerpPosition(Vector2 startPosition, Vector2 toPosition, float duration, Rigidbody2D rigidBody){

		float time = 0;
		while (time < duration){
			rigidBody.MovePosition (Vector2.Lerp(startPosition, toPosition, time / duration));
			time += Time.deltaTime;
			yield return null;
		}
	}



	void OnCollisionEnter2D(Collision2D col) {
		if (currentCharacter.GetIsJumping()){
			if (col.gameObject.tag == "Player1" || col.gameObject.tag == "Player2"){
				JumpingOverCharacter(col);
			}
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
				rigidBody.MovePosition(rigidBody.position + horizontal * Time.fixedDeltaTime * 70f);   ///Uses MovePosition because both transform and rb.position makes the character phase through when pushing the rival on the edge of the screen.
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
			rigidBody.velocity = Vector2.up * 180f;   ///Force necessary to break free from gravity
			if (Input.GetKey(GameConstants.R)){
				rigidBody.velocity += Vector2.right * 70f;
				currentCharacter.SetAnimationStatus(AnimationStates.JUMPING_FORWARDS);
				currentCharacter.PlayAnimation(AnimationStates.JUMPING_FORWARDS);
			}
			else if(Input.GetKey(GameConstants.L)){
				rigidBody.velocity += Vector2.left * 70f;
				currentCharacter.SetAnimationStatus(AnimationStates.JUMPING_BACKWARDS);
				currentCharacter.PlayAnimation(AnimationStates.JUMPING_BACKWARDS);
			}
			else{
				currentCharacter.SetAnimationStatus(AnimationStates.JUMPING_UP);
				currentCharacter.PlayAnimation(AnimationStates.JUMPING_UP);
			}	
			currentCharacter.SetAnimationPlaying(false);
		}
	}

}
