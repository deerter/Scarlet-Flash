using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CurrentFightStats{
	private static int numCharactersPlayer1 = 3;
	private static int numCharactersPlayer2 = 3;

	private static string[] selectedCharactersPlayer1 = new string[numCharactersPlayer1];   //////Set number of characters
	private static string[] selectedCharactersPlayer2 = new string[numCharactersPlayer2];

	/*public static string GetSelectedCharacterPlayer1(int characterNumber){
		return selectedCharactersPlayer1[characterNumber];
	}

	public static string GetSelectedCharacterPlayer2(int characterNumber){
		return selectedCharactersPlayer2[characterNumber];
	}*/

	public static string GetSelectedCharacter(int characterNumber, string player){
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

}
