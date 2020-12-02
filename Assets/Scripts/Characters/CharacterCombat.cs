using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCombat : MonoBehaviour {

	//private Animator animator;
	private CharacterFeatures currentCharacter;

	// Use this for initialization
	void Start () {
		currentCharacter = this.GetComponent<CharacterFeatures>();
		//animator = currentCharacter.GetAnimator();
	}

	public void IsCharacterStillCrouching(){
		if (currentCharacter.GetIsCrouching()){
			currentCharacter.EndAnimation(AnimationStates.CROUCHING);
		}else{
			currentCharacter.EndAnimation(AnimationStates.STANDING);
		}
	}
	
	// Update is called once per frame
	void Update () {
		///Standing Attacks
		if (Input.GetKeyDown(GameConstants.LP) && !currentCharacter.IsAnimationPlaying() && !currentCharacter.GetIsCrouching()){
			currentCharacter.PlayAnimation(AnimationStates.LIGHT_PUNCH);
			currentCharacter.SetAnimationStatus(AnimationStates.LIGHT_PUNCH);
		}

		if (Input.GetKeyDown(GameConstants.LK) && !currentCharacter.IsAnimationPlaying() && !currentCharacter.GetIsCrouching()){
			currentCharacter.PlayAnimation(AnimationStates.LIGHT_KICK);
			currentCharacter.SetAnimationStatus(AnimationStates.LIGHT_KICK);
		}

		if (Input.GetKeyDown(GameConstants.HP) && !currentCharacter.IsAnimationPlaying() && !currentCharacter.GetIsCrouching()){
			currentCharacter.PlayAnimation(AnimationStates.HEAVY_PUNCH);
			currentCharacter.SetAnimationStatus(AnimationStates.HEAVY_PUNCH);
		}

		if (Input.GetKeyDown(GameConstants.HK) && !currentCharacter.IsAnimationPlaying() && !currentCharacter.GetIsCrouching()){
			currentCharacter.PlayAnimation(AnimationStates.HEAVY_KICK);
			currentCharacter.SetAnimationStatus(AnimationStates.HEAVY_KICK);
		}

		/////Crouching Attacks
		if (Input.GetKeyDown(GameConstants.LP) && currentCharacter.GetIsCrouching() && !currentCharacter.IsAnimationPlaying()){
			currentCharacter.PlayAnimation(AnimationStates.CROUCHING_LIGHT_PUNCH);
			currentCharacter.SetAnimationStatus(AnimationStates.CROUCHING_LIGHT_PUNCH);
		}

		if (Input.GetKeyDown(GameConstants.LK) && currentCharacter.GetIsCrouching() && !currentCharacter.IsAnimationPlaying()){
			currentCharacter.PlayAnimation(AnimationStates.CROUCHING_LIGHT_KICK);
			currentCharacter.SetAnimationStatus(AnimationStates.CROUCHING_LIGHT_KICK);
		}

		if (Input.GetKeyDown(GameConstants.HP) && currentCharacter.GetIsCrouching() && !currentCharacter.IsAnimationPlaying()){
			currentCharacter.PlayAnimation(AnimationStates.CROUCHING_HEAVY_PUNCH);
			currentCharacter.SetAnimationStatus(AnimationStates.CROUCHING_HEAVY_PUNCH);
		}

		if (Input.GetKeyDown(GameConstants.HK) && currentCharacter.GetIsCrouching() && !currentCharacter.IsAnimationPlaying()){
			currentCharacter.PlayAnimation(AnimationStates.CROUCHING_HEAVY_KICK);
			currentCharacter.SetAnimationStatus(AnimationStates.CROUCHING_HEAVY_KICK);
		}


	}
}
