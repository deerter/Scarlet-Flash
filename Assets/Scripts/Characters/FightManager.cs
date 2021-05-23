using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class FightManager : MonoBehaviour {

	//[SerializeField] GameObject health;
    [SerializeField] GameObject hyper;
    [SerializeField] GameObject special;

	[SerializeField] GameObject player1;
	[SerializeField] GameObject player2;

	[SerializeField] GameObject restartScreen;

	[SerializeField] GameObject timerCounter;

	[SerializeField] GameObject AnnouncerTexts;

	private GameObject music;
	private GameObject announcer;
	private Image announcerText;
	private bool fightEnded = false;
	private bool restartPrompt = false;
	private bool fightStarted = false;
	private bool introEnded = false;
	private bool swappingCharacter = false;

	IEnumerator PopUpRestartFight(){
		restartPrompt = true;
		yield return new WaitForSeconds(10);
		restartScreen.GetComponent<PopUpWindow>().PopUp();
	}

	IEnumerator FightStart(){
		yield return new WaitUntil(() => announcer.GetComponent<AnnouncerVoice>().AnnouncerIsPlaying()==false);
		yield return new WaitForSeconds(0.5f);
		announcerText.sprite = Resources.Load<Sprite>("Textures_and_Sprites/Menus/Interface/Fight/Texts/Fight");
		announcer.GetComponent<AnnouncerVoice>().PlayAnnouncer("Fight");
		yield return new WaitForSeconds(0.2f);
		fightStarted = true;
		player1.transform.GetChild(0).GetComponent<CharacterFeatures>().SetIsBlocked(false);
		player1.transform.GetChild(0).GetComponent<CharacterFeatures>().SetIsBlocked(false);
		announcerText.GetComponent<Image>().color = new Color(announcerText.color.r, announcerText.color.g, announcerText.color.b, 0f);
		//music = GameObject.Find("Music");
		//music.GetComponent<MusicPlayer>().PlayMusic(CurrentFightStats.GetSelectedCharacter(0,"Player1"));
		//music.GetComponent<AudioSource>().loop=true;
	}

	IEnumerator SwapCharacterWhenDead(GameObject playerCharacter){
		CharacterFeatures character = playerCharacter.transform.GetChild(0).GetComponent<CharacterFeatures>();
		if (character.GetIsDead() && !character.GetAnimator().enabled && !swappingCharacter){
			swappingCharacter = true;
			yield return new WaitForSeconds(0.5f);
			playerCharacter.GetComponent<CharacterAssist>().Swap("Assist1", true);
			swappingCharacter = false;
		}
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

	private void AnnounceFight(){
		if (!introEnded &&
			player1.transform.GetChild(0).GetComponent<CharacterFeatures>().GetAnimationStatus()=="Standing" &&
			player2.transform.GetChild(0).GetComponent<CharacterFeatures>().GetAnimationStatus()=="Standing")
			{
			introEnded = true;
			int randomReadyAnnounce = UnityEngine.Random.Range(1,3);
			announcerText.sprite = Resources.Load<Sprite>("Textures_and_Sprites/Menus/Interface/Fight/Texts/Ready");
			announcerText.GetComponent<Image>().color = new Color(announcerText.color.r, announcerText.color.g, announcerText.color.b, 1f);
			announcer.GetComponent<AnnouncerVoice>().PlayAnnouncer("Ready" + randomReadyAnnounce);
			StartCoroutine(FightStart());
			
		}
	}

	// Use this for initialization
	void Start () {
		announcer = GameObject.Find("Announcer");
		announcerText = AnnouncerTexts.GetComponent<Image>();
		player1.transform.GetChild(0).GetComponent<CharacterFeatures>().FightIntroduction();
		player2.transform.GetChild(0).GetComponent<CharacterFeatures>().FightIntroduction();
	}

	void Update(){
		if (!fightStarted){
			AnnounceFight();
		}
		if (fightStarted){
			StartCoroutine(SwapCharacterWhenDead(player1));
			StartCoroutine(SwapCharacterWhenDead(player2));
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
