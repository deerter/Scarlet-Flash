using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAssist : MonoBehaviour {

	private bool swapped;  //Used to check if the player swapped their characters recently.
	private CharacterFeatures currentCharacter;


	void Start () {
		swapped = false;
		currentCharacter = this.GetComponent<CharacterFeatures>();
	}

	IEnumerator SwappingTimeout(){
		swapped = true;
		yield return new WaitForSeconds(5);
		swapped = false;
	}

	private void Swap(){
		if (SwapAvailable()){
			StartCoroutine(SwappingTimeout());
		}
	}

	private bool SwapAvailable(){
		return (swapped==false && !currentCharacter.GetIsJumping() && !currentCharacter.GetIsCrouching() && !currentCharacter.IsAnimationPlaying());
	}
	

	void Update () {
		if (Input.GetKeyDown(GameConstants.A1)){  ///Swap for first assist character
			/////Executes only one command, one function checks if the swap is available and performs it if so
			Swap();
			
		}

		if (Input.GetKeyDown(GameConstants.A2)){  ///Swap for second assist character
			Swap();
		}
		
	}
}
