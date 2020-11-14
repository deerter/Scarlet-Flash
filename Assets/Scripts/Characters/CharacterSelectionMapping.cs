using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectionMapping {

    public string GetCharacterSeries(string characterName){
        switch (characterName){
            // SF = Street Fighter //
            case "Ryu":
            case "Ken":
            case "Sakura":
                return "SF";

            // KOF = King Of Fighters //
            case "Leona":
                return "KOF";

            // N = Naruto //
            case "Naruto":
                return "N";

            // B = Bleach //
            case "Ichigo":
            case "Rukia":
                return "B";

            // OP = One Piece //
            case "Luffy":
                return "OP";

            // DS = Darkstalkers //
            case "Morrigan":
                return "DS";

            // YGO = Yu-Gi-Oh //
            case "Yugi":
            case "Kaiba":
                return "YGO";

            // MB = Medaka Box //
            case "Medaka":
                return "MB";

            // DC = Dino Crisis //
            case "Regina":
                return "DC";

            // SL = Slayers //
            case "Lina":
            case "Naga":
                return "SL";

            // JDI = Jungle De Ikou //
            case "Mii":
                return "JDI";
        }
        return " ";
    }
}
