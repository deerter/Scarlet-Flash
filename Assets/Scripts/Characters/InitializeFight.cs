using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeFight : MonoBehaviour {
	// First 3 -> Player 1, Second 3 -> Player 2
	private static Character[] selectedCharacters = new Character[6];

	//All bars
	private Bars bars;


	private void InitiliazeCharacter (Character character, int characterNumber){
		switch (CurrentFightStats.GetSelectedCharacter(characterNumber)){
			case "ryu":	character = new Ryu();break;
			case "sakura": character = new Sakura();break;
			case "ken": character = new Ken();break;
			case "leona": character = new Leona();break;
		}
	}

	// Use this for initialization
	void Start () {

		//Initiliaze characters
		for (int i=0; i < selectedCharacters.Length; i++){
			InitiliazeCharacter(selectedCharacters[i], i);
		}

		//Initiliaze health bars and such
		
	}

	


}
