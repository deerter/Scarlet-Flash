using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CurrentFightStats{
	private static string[] player1Characters = new string[3];
	private static string[] player2Characters = new string[3];

	public static string GetFirstCharacter(){
		return player1Characters[0];
	}

	public static void SetFirstCharacter(string character){
		player1Characters[0] = character;
	}

	public static string GetSecondCharacter(){
		return player1Characters[1];
	}

	public static void SetSecondCharacter(string character){
		player1Characters[1] = character;
	}

	public static string GetThirdCharacter(){
		return player1Characters[2];
	}

	public static void SetThirdCharacter(string character){
		player1Characters[2] = character;
	}

	public static string GetFourhtCharacter(){
		return player2Characters[0];
	}

	public static void SetFourthCharacter(string character){
		player2Characters[0] = character;
	}

	public static string GetFifthCharacter(){
		return player2Characters[1];
	}

	public static void SetFifthCharacter(string character){
		player2Characters[1] = character;
	}

	public static string GetSixthCharacter(){
		return player2Characters[2];
	}

	public static void SetSixthCharacter(string character){
		player2Characters[2] = character;
	}

}
