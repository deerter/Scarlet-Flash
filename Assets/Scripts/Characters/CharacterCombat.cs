using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCombat : MonoBehaviour {

	private Animator animator;
	private CharacterFeatures currentCharacter;

	// Use this for initialization
	void Start () {
		currentCharacter = this.GetComponent<CharacterFeatures>();
		animator = currentCharacter.GetAnimator();
	}
	
	// Update is called once per frame
	void Update () {
		///Standing Attacks
		if (Input.GetKeyDown(GameConstants.LP) && !currentCharacter.IsAnimationPlaying()){
			animator.SetTrigger("LightPunch");
			currentCharacter.AnimationPlaying();


			string name = animator.GetLayerName(0) + "." + "LightPunch";
			
			int animationFullNameHash = Animator.StringToHash(name);
			
			print(animator.GetCurrentAnimatorStateInfo(0));
		}

		if (Input.GetKeyDown(GameConstants.LK) && !currentCharacter.IsAnimationPlaying()){
			animator.SetTrigger("LightKick");
			currentCharacter.AnimationPlaying();
		}

		if (Input.GetKeyDown(GameConstants.HP) && !currentCharacter.IsAnimationPlaying()){
			animator.SetTrigger("HeavyPunch");
			currentCharacter.AnimationPlaying();
		}

		if (Input.GetKeyDown(GameConstants.HK) && !currentCharacter.IsAnimationPlaying()){
			animator.SetTrigger("HeavyKick");
			currentCharacter.AnimationPlaying();
		}

	}
}
