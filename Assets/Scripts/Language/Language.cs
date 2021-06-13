using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class Language
{
    public enum language { Spanish = 0, English = 1 };
    public static Dictionary<string, string> gameTexts = new Dictionary<string, string> { };
    public static language currentLanguage = language.English;


    public static void ChangeLanguage(int changedLanguage)
    {
        currentLanguage = (language)changedLanguage;
        ReadCSV();
        ///Reload the texts of menu where language was changed
        var Texts = GameObject.FindGameObjectsWithTag("Texts");
        foreach (var Text in Texts)
        {
            Text.GetComponent<Texts>().SetText("reloadText");
        }
    }

    public static int GetLanguage()
    {
        return (int)currentLanguage;
    }

    public static void ReadCSV()
    {
        bool firstLine = true;
        int languageKey = 0;
        //TextAsset reader = Resources.Load<TextAsset>("Language/Language.csv");
        gameTexts.Clear();
        //"Assets/Resources/Language/Language.csv"
        using (var reader = new StreamReader(Application.streamingAssetsPath + "/Language/Language.csv"))
        {
            while (!reader.EndOfStream)
            {
                var splits = reader.ReadLine().Split(';');
                if (firstLine)
                {
                    firstLine = false;
                    int i = 0;
                    while (languageKey == 0 || i == splits.Length - 1)
                    {
                        if (splits[i] == currentLanguage.ToString())
                        {
                            languageKey = i;
                        }
                        i++;
                    }
                    continue;
                }
                gameTexts.Add(splits[0], splits[languageKey]);
            }
        }
    }

    public static string GetText(string key)
    {
        return gameTexts[key];
    }



}
