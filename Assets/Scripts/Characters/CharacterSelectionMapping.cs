using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectionMapping {
    private const int totalCharacterNum = 16;

    public static Dictionary<string, string> characterSeries = new Dictionary<string, string> {
        // SF = Street Fighter //
         {"Ryu", "SF"},
         {"Ken", "SF"},
         {"Sakura", "SF"},
         //// KOF = King Of Fighters //
         {"Leona","KOF"},
         // N = Naruto //
         {"Naruto", "N"},
         // B = Bleach //
         {"Ichigo", "B"},
         {"Rukia", "B"},
         // OP = One Piece //
         {"Luffy","OP"},
         // DS = Darkstalkers //
         {"Morrigan","DS"},
         // YGO = Yu-Gi-Oh //
         {"Yugi","YGO"},
         {"Kaiba","YGO"},
         // MB = Medaka Box //
         {"Medaka","MB"},
         // DC = Dino Crisis //
         {"Regina","DC"},
         // SL = Slayers //
         {"Lina","SL"},
         {"Naga","SL"},
         // JDI = Jungle De Ikou //
         {"Mii","JDI"}
    };

    public static string[] characters = new string[totalCharacterNum]{
        "Ryu", "Ken", "Sakura", "Leona", "Naruto", "Ichigo", "Rukia", "Luffy", "Morrigan", "Yugi", "Kaiba", "Medaka", "Regina", "Lina", "Naga", "Mii"
    };

    public string GetCharacterSeries(string character){
        return characterSeries[character];
    }

    public string GetCharacter(int num){
        return characters[num];
    }
}
