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

	private float characterJumpFinalPosition;  ///Needed to assess the final position of a jump


	void Start(){
		currentCharacter = this.GetComponent<CharacterFeatures>();
		animator = currentCharacter.GetAnimator();
		rigidBody = this.GetComponent<Rigidbody2D>();
		boxCollider = this.GetComponent<BoxCollider2D>();
	}

	/*public void falling(){       ///////JUST IN CASE/////////////Loops last frames of falling animation
		animator.Play(AnimationStates.JUMPING_DOWN,0,0.5f);
	}*/

	///////Character landing////////
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
		transform.position = new Vector3(transform.position.x, -12.58f, transform.position.z);
	}
	/////////////////////////////////

	////Get final position of a jump//////////
	private void CalculateJumpingDestination(float jumpOriginPosition){
		////75.89º is the angle of jump (is in degrees, must be converted to radians)///////
		characterJumpFinalPosition = ((Mathf.Pow(rigidBody.velocity.x, 2)*Mathf.Sin(2*(75.89f * Mathf.PI)/180))/rigidBody.gravityScale) + jumpOriginPosition;
		
	}

	///////Character collision when jumping ////////
	private void JumpingOverCharacter(Collision2D col){
		currentCharacter.EndAnimation(AnimationStates.JUMPING_DOWN);

		rivalBoxCollider = col.gameObject.GetComponent<BoxCollider2D>();
		Rigidbody2D rivalRigidBody = col.gameObject.GetComponent<Rigidbody2D>();
		Vector3 contactPoint = col.contacts[0].point;
        Vector3 center = rivalBoxCollider.bounds.center;
		Vector3 sides = rivalBoxCollider.bounds.extents;
		if (contactPoint.x > (center.x - 4f)){

			print(sides.x);
			//float distance = Mathf.Abs((center.x + sides.x) - (characterJumpFinalPosition - boxCollider.bounds.extents.x));
			float distance = Mathf.Abs(center.x - (characterJumpFinalPosition - boxCollider.bounds.extents.x));
			
			//Vector2 rivalToPosition = new Vector2(col.gameObject.transform.position.x - distance, col.gameObject.transform.position.y);
			Vector2 rivalToPosition = new Vector2(center.x - distance, center.y);

			//StartCoroutine(LerpPosition(col.gameObject.transform.position, rivalToPosition, 0.17f, rivalRigidBody));
			StartCoroutine(LerpPosition(center, rivalToPosition, 0.17f, rivalRigidBody));

			Physics2D.IgnoreCollision(rivalBoxCollider, boxCollider, true);

		}else {
			//float distance = Mathf.Abs((boxCollider.bounds.extents.x + characterJumpFinalPosition) - (center.x - sides.x));
			float distance = Mathf.Abs((boxCollider.bounds.extents.x + characterJumpFinalPosition) - (center.x - sides.x));

			//Vector2 rivalToPosition = new Vector2(col.gameObject.transform.position.x + distance,col.gameObject.transform.position.y);
			Vector2 rivalToPosition = new Vector2(center.x + distance, center.y);
			//Vector2 toPosition = new Vector2(gameObject.transform.position.x,gameObject.transform.position.y);  /////To move the character that jumps as well

			//StartCoroutine(LerpPosition(col.gameObject.transform.position, rivalToPosition, 0.17f, rivalRigidBody));
			StartCoroutine(LerpPosition(center, rivalToPosition, 0.17f, rivalRigidBody));

			Physics2D.IgnoreCollision(rivalBoxCollider, boxCollider, true);
		} 
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
	/////////////////
	
	void Update () {
		if (currentCharacter.IsAnimationPlaying() && !currentCharacter.GetIsJumping() && !currentCharacter.GetIsHit()){ //In case the animation goes from walking to other animation, prevents from sliding behaviour
			rigidBody.velocity = new Vector2(0,0);
		}

		///Moving
		animator.SetFloat("Horizontal", 0);  //Sets the horizontal back to 0 so that the animator can move from walking to standing (if not, loops the walking animation)
		if ((currentCharacter.GetAnimationStatus() == AnimationStates.STANDING) ||
			 (currentCharacter.GetAnimationStatus() == AnimationStates.WALK_FORWARDS) || 
			 	(currentCharacter.GetAnimationStatus() == AnimationStates.WALK_BACKWARDS)){
			if ((Input.GetKey(GameConstants.R)) || (Input.GetKey(GameConstants.L))){
				animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
				Vector2 horizontal = new Vector2(Input.GetAxis("Horizontal"), 0.0f); 
				rigidBody.velocity = horizontal * 3500f * Time.fixedDeltaTime;
				//rigidBody.MovePosition(rigidBody.position + horizontal * Time.fixedDeltaTime * 70f);   ///Uses MovePosition because both transform and rb.position makes the character phase through when pushing the rival on the edge of the screen.
																						//Uses Time.fixedDeltaTime instead of Time.deltaTime because MovePosition works with physics (as does fixedDeltaTime)
			}else{
				rigidBody.velocity = new Vector2(0,0);
			}
		}

		//Blocking
		if (Input.GetKey(GameConstants.L)){
			currentCharacter.SetIsBlocking(true);
		}else{
			currentCharacter.SetIsBlocking(false);
		}

		// Crouching
		if (Input.GetKey(GameConstants.D) && !currentCharacter.IsAnimationPlaying() && !currentCharacter.GetIsCrouching() && !currentCharacter.GetIsJumping()){
			rigidBody.velocity = new Vector2(0,0); //Prevents from sliding
			//SetCoordinatesWhenLanding(); //Prevents from phasing through the ground if the down button is pressed when the character touches the ground after a jump.
			currentCharacter.PlayAnimation(AnimationStates.CROUCH);
			currentCharacter.SetAnimationStatus(AnimationStates.CROUCH);
			currentCharacter.SetIsCrouching(true);
			currentCharacter.SetAnimationPlaying(false);
		}

		if (Input.GetKeyUp(GameConstants.D) && !currentCharacter.GetIsJumping())
        {
			//SetCoordinatesWhenLanding();
			currentCharacter.SetIsCrouching(false);
			if(!currentCharacter.IsAnimationPlaying()){
				currentCharacter.EndAnimation(AnimationStates.STANDING);
			}
        }

		// Jumping
		if (Input.GetKeyDown(GameConstants.U) && !currentCharacter.IsAnimationPlaying() && !currentCharacter.GetIsCrouching() && !currentCharacter.GetIsJumping()){
			currentCharacter.SetIsJumping(true);
			rigidBody.velocity = Vector2.up * 200f;   ///Force necessary to break free from gravity
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
			CalculateJumpingDestination(boxCollider.bounds.center.x);
			currentCharacter.SetAnimationPlaying(false);
		}
	}

}
