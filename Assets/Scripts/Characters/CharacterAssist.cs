using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAssist : MonoBehaviour {

	[SerializeField] private GameObject lifeBars;

	private bool swapped;  //Used to check if the player swapped their characters recently.
	private CharacterFeatures currentCharacter;


	void Start () {
		swapped = false;
		currentCharacter = transform.GetChild(0).gameObject.GetComponent<CharacterFeatures>();
	}

	IEnumerator SwappingTimeout(){
		swapped = true;
		yield return new WaitForSeconds(2); //5
		print("time passed");
		swapped = false;
	}

	private void Swap(string assist){
		if (SwapAvailable()){
			StartCoroutine(SwappingTimeout());
			GameObject characterSwap;
			GameObject pointCharacter = transform.GetChild(0).gameObject;
			bool assistFound = false;
			switch (assist){
				case "Assist1": for(int i = 1; i < transform.childCount && !assistFound; i++) { 
									if (!transform.GetChild(i).gameObject.GetComponent<CharacterFeatures>().GetIsDead()){
										assistFound = true;
										characterSwap = transform.GetChild(i).gameObject;
										pointCharacter.transform.SetSiblingIndex(transform.GetChild(i).transform.GetSiblingIndex());
										characterSwap.transform.SetSiblingIndex(0);
										SwapLifeBars(characterSwap, pointCharacter, i);
										SetCharacterSwapped(characterSwap, pointCharacter);
										UnsetCharacterSwapped(pointCharacter);
									}
								}break;
				case "Assist2": for (int i = transform.childCount-1; i > 0 & !assistFound; i--){
								if (!transform.GetChild(i).gameObject.GetComponent<CharacterFeatures>().GetIsDead()){
										assistFound = true;
										characterSwap = transform.GetChild(i).gameObject;
										pointCharacter.transform.SetSiblingIndex(transform.GetChild(i).transform.GetSiblingIndex()); 
										characterSwap.transform.SetSiblingIndex(0);
										SwapLifeBars(characterSwap, pointCharacter, i);
										SetCharacterSwapped(characterSwap, pointCharacter);
										UnsetCharacterSwapped(pointCharacter);
									}
								}break;
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

	private void SwapLifeBars(GameObject characterSwap, GameObject pointCharacter, int index){

		Transform pointCharacterLifeBar = lifeBars.transform.GetChild(pointCharacter.transform.GetSiblingIndex());
		Transform characterSwapLifeBar = lifeBars.transform.GetChild(characterSwap.transform.GetSiblingIndex());

		Vector3 pointCharacterLifeBarPosition = pointCharacterLifeBar.position;
		Vector3 characterSwapLifeBarPosition = characterSwapLifeBar.position;

		Vector2 pointCharacterLifeBarSize = pointCharacterLifeBar.GetComponent<RectTransform>().sizeDelta;
		Vector2 characterSwapLifeBarSize = characterSwapLifeBar.GetComponent<RectTransform>().sizeDelta;

		pointCharacterLifeBar.gameObject.transform.SetSiblingIndex(0);
		characterSwapLifeBar.gameObject.transform.SetSiblingIndex(index);

		pointCharacterLifeBar.position = characterSwapLifeBarPosition;
		characterSwapLifeBar.position = pointCharacterLifeBarPosition;

		pointCharacterLifeBar.GetComponent<RectTransform>().sizeDelta = characterSwapLifeBarSize;
		characterSwapLifeBar.GetComponent<RectTransform>().sizeDelta = pointCharacterLifeBarSize;
	}
	

	void Update () {
		if (Input.GetKeyDown(GameConstants.A1)){  ///Swap for first assist character
			/////Executes only one command, one function checks if the swap is available and performs it if so
			Swap("Assist1");
		}

		if (Input.GetKeyDown(GameConstants.A2)){  ///Swap for second assist character
			Swap("Assist2");
		}
		
	}
}
