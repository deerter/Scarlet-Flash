using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterFeatures : MonoBehaviour {
	[SerializeField] public GameObject health;
	[SerializeField] private Animator animator;
	private Character character;
	private HealthBar healthBar;
	private bool animationPlaying = false;   //Character is currently on an animation other than standing ///Used to not enter other animations when the current one has finished and a button has been pressed during the execution.
	private string animationStatus;
	private bool isCrouching = false;
	private bool isJumping = false;
	private bool isBlocking = false;
	private bool isHit = false;
	private bool isWinner = false;


	public Character GetCharacter() {
		return character;
	}

	public HealthBar GetHealthBar (){
		return healthBar;
	}

	public Animator GetAnimator(){
		return animator;
	}

	public bool IsAnimationPlaying(){
		return animationPlaying;
	}

	public void SetAnimationPlaying(bool animationPlaying){
		this.animationPlaying = animationPlaying;
	}

	public void PlayAnimation(string animation){
		animator.Play(animation);
		animationPlaying = true;
	}

	public void EndAnimation(string animation){
		animator.Play(animation);
		animationPlaying = false;
	}

	public void SetAnimationStatus (string animationStatus){
		this.animationStatus = animationStatus;
	}

	public string GetAnimationStatus(){
		return animationStatus;
	}



	public bool GetIsCrouching(){
		return isCrouching;
	}

	public void SetIsCrouching(bool isCrouching){
		this.isCrouching = isCrouching;
	}

	

	public bool GetIsJumping(){
		return isJumping;
	}

	public void SetIsJumping(bool isJumping){
		this.isJumping = isJumping;
	}


	public bool GetIsBlocking(){
		return isBlocking;
	}

	public void SetIsBlocking(bool isBlocking){
		this.isBlocking = isBlocking;
	}


	public bool GetIsHit(){
		return isHit;
	}

	public void HitDone(){
		this.isHit = true;
	}

	public void HitEnding (){
		this.isHit = false;
	}



	public void SetIsWinner(){
		isWinner = true;
	}


	public void CharacterIsDead(){
		gameObject.GetComponent<Animator>().enabled = false;
	}



	public void TakeDamage(int attackValue){
		healthBar.Deplete(attackValue);
	}

	public int DoDamage(){
		return character.GetAttackOutput(animationStatus);
	}

	IEnumerator VictoryDance(){
		yield return new WaitForSeconds(5);
		SetAnimationStatus(AnimationStates.VICTORY);
		PlayAnimation(AnimationStates.VICTORY);
	}

	// Use this for initialization
	void Start () {
		//string characterName = CurrentFightStats.GetSelectedCharacter(transform.GetSiblingIndex(), gameObject.tag);     ESTA ES LA FORMA ADECUADA
		string characterName = "Sakura";
		var type = Type.GetType(characterName);
		character = (Character)Activator.CreateInstance(type);
		healthBar = new HealthBar (health.transform.GetChild(transform.GetSiblingIndex()).gameObject, character.GetHealth());
		animator.runtimeAnimatorController = Resources.Load("Animation/Characters/" + characterName + "/" + characterName) as RuntimeAnimatorController;
	}
	
	// Update is called once per frame
	void Update () {
		if (healthBar.getHP() == 0 && !GetIsJumping()){
			//GetComponent<CharacterMovement>().enabled = false;  /////Use these commands if the rival character is not AI
			//GetComponent<CharacterCombat>().enabled = false;

			/*GetComponent<Rigidbody2D>().isKinematic = true;
			GetComponent<Rigidbody2D>().MovePosition(GetComponent<Rigidbody2D>().position);
			GetComponent<BoxCollider2D>().enabled = false;*/
			PlayAnimation(AnimationStates.KO);
		}
		if (isWinner && !GetIsJumping()){
			StartCoroutine(VictoryDance());
		}
		
	}
}
