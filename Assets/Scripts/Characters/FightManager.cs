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

	[SerializeField] GameObject restartScreen;

	[SerializeField] GameObject timerCounter;

	private CharacterFeatures player1Features;
	private CharacterFeatures player2Features;

	private bool fightEnded = false;
	private bool restartPrompt = false;

	IEnumerator PopUpRestartFight(){
		restartPrompt = true;
		yield return new WaitForSeconds(10);
		restartScreen.GetComponent<PopUpWindow>().PopUp();
	}

	private void TimeUpVictory(){
		int lifeRemainingPlayer1 = player1Features.GetHealthBar().getMaxHP() - player1Features.GetHealthBar().getHP();
		int lifeRemainingPlayer2 = player2Features.GetHealthBar().getMaxHP() - player2Features.GetHealthBar().getHP();

		if (lifeRemainingPlayer1 > lifeRemainingPlayer2){
			player1Features.SetIsWinner();
		} else if (lifeRemainingPlayer1 == lifeRemainingPlayer2){
			print("DRAW");
		} else{
			player2Features.SetIsWinner();
		}
	}

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
	}

	void Update(){
		//Declares a winner if a healthBar has been depleted
		if (player1Features.GetHealthBar().getHP() == 0 && !fightEnded){
			player2Features.SetIsWinner(); 
			fightEnded=true;
		}
		if (player2Features.GetHealthBar().getHP() == 0 && !fightEnded){
			player1Features.SetIsWinner();
			fightEnded=true;
		}

		//Prompts the restart fight screen and stops the timer
		if (fightEnded && !restartPrompt){
			timerCounter.GetComponent<Timer>().StopTimer();
			StartCoroutine(PopUpRestartFight());
		}

		//Counts down the time
		if (timerCounter.GetComponent<Timer>().GetTimer() > 0 && !fightEnded){
			timerCounter.GetComponent<Timer>().DecreaseTimer();
		}
		if (timerCounter.GetComponent<Timer>().GetTimer() == 0 && !fightEnded){
			fightEnded = true;
			TimeUpVictory();
		}

	}

	


}
