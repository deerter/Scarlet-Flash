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
	
	// Update is called once per frame
	void Update () {
		///Standing Attacks
		if (Input.GetKeyDown(GameConstants.LP) && !currentCharacter.IsAnimationPlaying()){
			currentCharacter.PlayAnimation(AnimationStates.LIGHT_PUNCH);
			currentCharacter.SetAnimationStatus(AnimationStates.LIGHT_PUNCH);
		}

		if (Input.GetKeyDown(GameConstants.LK) && !currentCharacter.IsAnimationPlaying()){
			currentCharacter.PlayAnimation(AnimationStates.LIGHT_KICK);
			currentCharacter.SetAnimationStatus(AnimationStates.LIGHT_KICK);
		}

		if (Input.GetKeyDown(GameConstants.HP) && !currentCharacter.IsAnimationPlaying()){
			currentCharacter.PlayAnimation(AnimationStates.HEAVY_PUNCH);
			currentCharacter.SetAnimationStatus(AnimationStates.HEAVY_PUNCH);
		}

		if (Input.GetKeyDown(GameConstants.HK) && !currentCharacter.IsAnimationPlaying()){
			currentCharacter.PlayAnimation(AnimationStates.HEAVY_KICK);
			currentCharacter.SetAnimationStatus(AnimationStates.HEAVY_KICK);
		}

	}
}
