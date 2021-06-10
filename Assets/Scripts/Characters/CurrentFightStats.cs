using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CurrentFightStats
{
    private static int numCharactersPlayer1 = 3;
    private static int numCharactersPlayer2 = 3;

    private static string[] selectedCharactersPlayer1 = new string[numCharactersPlayer1];   //////Set number of characters
    private static string[] selectedCharactersPlayer2 = new string[numCharactersPlayer2];

    private static bool player1AI = false;
    private static bool player2AI = true;

    private static float damage = 1;

    private static float timer = 100;

    /*public static string GetSelectedCharacterPlayer1(int characterNumber){
		return selectedCharactersPlayer1[characterNumber];
	}

	public static string GetSelectedCharacterPlayer2(int characterNumber){
		return selectedCharactersPlayer2[characterNumber];
	}*/

    public static string GetSelectedCharacter(int characterNumber, string player)
    {

        selectedCharactersPlayer2[0] = "Sakura";
        selectedCharactersPlayer2[1] = "Ken";
        selectedCharactersPlayer2[2] = "Leona";


        string charName = "";
        switch (player)
        {
            case "Player1": charName = selectedCharactersPlayer1[characterNumber]; break;
            case "Player2": charName = selectedCharactersPlayer2[characterNumber]; break;
        }
        return charName;
    }

    public static void SetSelectedCharacterPlayer1(string character, int characterNumber)
    {
        selectedCharactersPlayer1[characterNumber] = character;
    }

    public static void SetSelectedCharacterPlayer2(string character, int characterNumber)
    {
        selectedCharactersPlayer2[characterNumber] = character;
    }

    public static float GetTimer()
    {
        return timer;
    }

    public static void SetTimer(float newTimer)
    {
        timer = newTimer;
    }

    public static void SetAI(bool p1AI, bool p2AI)
    {
        player1AI = p1AI;
        player2AI = p2AI;
    }

    public static bool GetAI(string player)
    {
        switch (player)
        {
            case "Player1": return player1AI;
            case "Player2": return player2AI;
        }
        return false;
    }

    public static void SetDamage(float newDamage)
    {
        damage = newDamage;
    }

    public static float GetDamage()
    {
        return damage;
    }

    /*public static void SetTimer(bool timeLimit){
		timer = timeLimit ? 100 : -1;
	}*/

    /*public static void UpdateTimer(){
		timer--;
	}*/



}
