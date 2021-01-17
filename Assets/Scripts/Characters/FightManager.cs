using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FightManager : MonoBehaviour {

	//[SerializeField] GameObject health;
    [SerializeField] GameObject hyper;
    [SerializeField] GameObject special;

	[SerializeField] GameObject player1;
	[SerializeField] GameObject player2;

	public static int numCharactersPlayer1 = 3;
	public static int numCharactersPlayer2 = 3;

	private CharacterFeatures player1Features;
	private CharacterFeatures player2Features;


	/*private Character InitiliazeCharacter (string characterName){
		var type = Type.GetType(characterName);
		return (Character)Activator.CreateInstance(type);
	}*/

	/*public Character GetCharacter(string player, int character){
		return player=="Player1" ? selectedCharactersPlayer1[character] : selectedCharactersPlayer2[character];
	} 

	public HealthBar GetHealthBar(string player, int character){
		return player=="Player1" ? healthBarsPlayer1[character] : healthBarsPlayer2[character];
	} */

	// Use this for initialization
	void Start () {
		player1Features = player1.GetComponent<CharacterFeatures>();
		player2Features = player2.GetComponent<CharacterFeatures>();
		//Initiliaze characters
		/*for (int i=0; i < selectedCharacters.Length; i++){
			InitiliazeCharacter(selectedCharactersPlayer1[i], i);
			healthBars[i] = new HealthBar(health.transform.GetChild(i+1).gameObject, selectedCharacters[i].GetHealth());
		}*/
		/*for (int i=0; i < selectedCharacters.Length; i++){
			InitiliazeCharacter(selectedCharactersPlayer2[i], i);
			healthBars[i] = new HealthBar(health.transform.GetChild(i+1).gameObject, selectedCharacters[i].GetHealth());
		}*/

		/////////////////ESTO BORRAMELO////////////////////
		/*selectedCharactersPlayer1[0] = new Sakura();
		//selectedCharactersPlayer2[0] = new Sakura();
		//InitiliazeCharacter(selectedCharactersPlayer2[0], 2);
		//selectedCharactersPlayer2[0] = InitiliazeCharacter("Sakura");

		healthBarsPlayer1[0] = new HealthBar(health.transform.GetChild(0).gameObject, selectedCharactersPlayer1[0].GetHealth());
		healthBarsPlayer2[0] = new HealthBar(health.transform.GetChild(3).gameObject, selectedCharactersPlayer2[0].GetHealth());*/
	}

	void Update(){
		if (player1Features.GetHealthBar().getHP() == 0) player2Features.SetIsWinner();
		if (player2Features.GetHealthBar().getHP() == 0) player1Features.SetIsWinner();
		/*if (Input.GetKeyDown(GameConstants.LP))
        {
			print("entrando");
            healthBars[3].TakeDamage(45000);
        }*/

	}

	


}
