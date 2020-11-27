﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectionMapping {
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

    public string GetCharacterSeries(string character){
        return characterSeries[character];
    }
}
