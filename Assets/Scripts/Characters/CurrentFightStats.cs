using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CurrentFightStats{

	private static string[] selectedCharacters = new string[6];

	public static string GetSelectedCharacter(int characterNumber){
		return selectedCharacters[characterNumber];
	}

	public static void SetSelectedCharacter(string character, int characterNumber){
		selectedCharacters[characterNumber] = character;
	}

}
