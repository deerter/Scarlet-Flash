using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAssist : MonoBehaviour {

	private bool swapped;  //Used to check if the player swapped their characters recently.
	private CharacterFeatures currentCharacter;


	void Start () {
		swapped = false;
		currentCharacter = transform.GetChild(0).gameObject.GetComponent<CharacterFeatures>();
	}

	IEnumerator SwappingTimeout(){
		swapped = true;
		yield return new WaitForSeconds(5);
		print("time passed");
		swapped = false;
	}

	private void Swap(){
		if (SwapAvailable()){
			StartCoroutine(SwappingTimeout());
			//print(transform.parent.GetChild(transform.GetSiblingIndex() + 1).gameObject);
			GameObject characterSwap;
			GameObject pointCharacter;
			foreach(Transform child in transform) {
				if(child.transform.GetSiblingIndex()==0) continue;
				if (!child.gameObject.GetComponent<CharacterFeatures>().GetIsDead()){
					characterSwap = child.gameObject;
					pointCharacter = transform.GetChild(0).gameObject;
					pointCharacter.transform.SetSiblingIndex(child.transform.GetSiblingIndex()); 
					SetCharacterSwapped(characterSwap, pointCharacter);
					UnsetCharacterSwapped(pointCharacter);
					break;
				}
			}
		}
	}

	private bool SwapAvailable(){
		return (swapped==false && !currentCharacter.GetIsJumping() && !currentCharacter.GetIsCrouching() && !currentCharacter.IsAnimationPlaying());
	}

	private void SetCharacterSwapped(GameObject characterSwap, GameObject pointCharacter){
		characterSwap.GetComponent<SpriteRenderer>().enabled=true;
		characterSwap.GetComponent<Animator>().enabled=true;
		characterSwap.GetComponent<BoxCollider2D>().enabled=true;
		characterSwap.GetComponent<CharacterMovement>().enabled=true;
		characterSwap.GetComponent<CharacterCombat>().enabled=true;
		characterSwap.GetComponent<FlipSprite>().enabled=true;
		characterSwap.GetComponent<Rigidbody2D>().simulated=true;
		characterSwap.transform.position = new Vector3(pointCharacter.transform.position.x, pointCharacter.transform.position.y, pointCharacter.transform.position.z);
	}

	private void UnsetCharacterSwapped(GameObject pointCharacter){
		pointCharacter.GetComponent<SpriteRenderer>().enabled=false;
		pointCharacter.GetComponent<BoxCollider2D>().enabled=false;
		pointCharacter.GetComponent<Animator>().enabled=false;
		pointCharacter.GetComponent<CharacterMovement>().enabled=false;
		pointCharacter.GetComponent<CharacterCombat>().enabled=false;
		pointCharacter.GetComponent<FlipSprite>().enabled=false;
		pointCharacter.GetComponent<Rigidbody2D>().simulated=false;
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
