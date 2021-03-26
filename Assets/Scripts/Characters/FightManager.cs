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

	private bool fightEnded = false;
	private bool restartPrompt = false;
	private bool fightStarted = false;

	IEnumerator PopUpRestartFight(){
		restartPrompt = true;
		yield return new WaitForSeconds(10);
		restartScreen.GetComponent<PopUpWindow>().PopUp();
	}

	IEnumerator FightStart(){
		yield return new WaitForSeconds(5);
		fightStarted = true;
	}

	private void TimeUpVictory(){
		///// Revise the code for 3 vs 3 (or others) variant //////
		/*int lifeRemainingPlayer1 = player1Features.GetHealthBar().getMaxHP() - player1Features.GetHealthBar().getHP();
		int lifeRemainingPlayer2 = player2Features.GetHealthBar().getMaxHP() - player2Features.GetHealthBar().getHP();

		if (lifeRemainingPlayer1 > lifeRemainingPlayer2){
			player1Features.SetIsWinner();
		} else if (lifeRemainingPlayer1 == lifeRemainingPlayer2){
			print("DRAW");
		} else{
			player2Features.SetIsWinner();
		}*/
	}

	private bool CheckLifeBars(GameObject currentPlayer){
		foreach(Transform child in currentPlayer.transform){
			if(!child.gameObject.GetComponent<CharacterFeatures>().GetIsDead()){
				return false;
			}
		}
		return true;
	}

	private void SetWinner(GameObject currentPlayer){
		foreach(Transform child in currentPlayer.transform){
			child.gameObject.GetComponent<CharacterFeatures>().SetIsWinner();
		}
	}

	// Use this for initialization
	void Start () {
		StartCoroutine(FightStart());
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
		if (fightStarted){
			//Declares a winner if all healthBars has been depleted
			if (CheckLifeBars(player1) && !fightEnded){
				SetWinner(player2);
				fightEnded=true;
			}
			if (CheckLifeBars(player2) && !fightEnded){
				SetWinner(player1);
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

	


}
