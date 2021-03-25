using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CurrentFightStats{
	private static int numCharactersPlayer1 = 3;
	private static int numCharactersPlayer2 = 3;

	private static string[] selectedCharactersPlayer1 = new string[numCharactersPlayer1];   //////Set number of characters
	private static string[] selectedCharactersPlayer2 = new string[numCharactersPlayer2];

	private static bool timerActive = true;

	/*public static string GetSelectedCharacterPlayer1(int characterNumber){
		return selectedCharactersPlayer1[characterNumber];
	}

	public static string GetSelectedCharacterPlayer2(int characterNumber){
		return selectedCharactersPlayer2[characterNumber];
	}*/
	
	public static string GetSelectedCharacter(int characterNumber, string player){
		selectedCharactersPlayer1[0] = "Ken";  ////////Get rid of these lines after testing
		selectedCharactersPlayer1[1] = "Sakura";
		selectedCharactersPlayer1[2] = "Ken";

		selectedCharactersPlayer2[0] = "Sakura";
		selectedCharactersPlayer1[1] = "Ken";
		selectedCharactersPlayer1[2] = "Sakura";
		

		string charName = "";
		switch(player){
			case "Player1": charName = selectedCharactersPlayer1[characterNumber];break;
			case "Player2": charName = selectedCharactersPlayer2[characterNumber];break;
		}
		return charName;
	}

	public static void SetSelectedCharacterPlayer1(string character, int characterNumber){
		selectedCharactersPlayer1[characterNumber] = character;
	}

	public static void SetSelectedCharacterPlayer2(string character, int characterNumber){
		selectedCharactersPlayer2[characterNumber] = character;
	}

	public static bool GetTimerActive(){
		return timerActive;
	}

	/*public static void SetTimer(bool timeLimit){
		timer = timeLimit ? 100 : -1;
	}*/

	/*public static void UpdateTimer(){
		timer--;
	}*/



}
