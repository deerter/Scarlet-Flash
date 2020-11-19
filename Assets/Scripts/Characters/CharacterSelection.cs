using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour {

    public GameObject artwork;
    public GameObject series;
    public GameObject characterName;

    public GameObject firstChosenCharacter;
    public GameObject secondChosenCharacter;
    public GameObject thirdChosenCharacter;

    private Text name;
    private string characterSeries;

    private const int maxChars = 3;
    private int chosenChars = 0;

    private CharacterSelectionMapping characterMapping = new CharacterSelectionMapping();
    private LoadSceneonClick nextScene = new LoadSceneonClick();

    private void DisplayCharacterSelected(string charName)
    {
        characterSeries = characterMapping.GetCharacterSeries(charName);
        artwork.GetComponent<Image>().sprite = Resources.Load<Sprite>("Textures_and_Sprites/Menus/Interface/CharacterSelectionMenu/CharacterProfile/" 
            + characterSeries + "/" + charName + "/" + charName);
        series.GetComponent<Image>().sprite = Resources.Load<Sprite>("Textures_and_Sprites/Menus/Interface/CharacterSelectionMenu/CharacterProfile/"
            + characterSeries + "/" + characterSeries + "_logo");
    }

    private void ChooseCharacter(string charName)
    {
        chosenChars++;
        switch (chosenChars)
        {
            case 1:
                firstChosenCharacter.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures_and_Sprites/Menus/Interface/CharacterSelectionMenu/CharacterProfile/"
                + characterSeries + "/" + charName + "/" + charName);
                CurrentFightStats.SetSelectedCharacter(charName,0);break;
            case 2:
                secondChosenCharacter.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures_and_Sprites/Menus/Interface/CharacterSelectionMenu/CharacterProfile/"
                + characterSeries + "/" + charName + "/" + charName);
                CurrentFightStats.SetSelectedCharacter(charName,1);break;
            case 3:
                thirdChosenCharacter.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures_and_Sprites/Menus/Interface/CharacterSelectionMenu/CharacterProfile/"
                + characterSeries + "/" + charName + "/" + charName);
                CurrentFightStats.SetSelectedCharacter(charName,2);
                nextScene.LoadByIndex(8);break;
        }
    }

    private void UnchooseCharacter()
    {
        switch (chosenChars)
        {
            case 1:
                firstChosenCharacter.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures_and_Sprites/Menus/Interface/CharacterSelectionMenu/CharacterProfile/ChosenCharacterBackground");break;
            case 2:
                secondChosenCharacter.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures_and_Sprites/Menus/Interface/CharacterSelectionMenu/CharacterProfile/ChosenCharacterBackground");break;
            case 3:
                thirdChosenCharacter.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures_and_Sprites/Menus/Interface/CharacterSelectionMenu/CharacterProfile/ChosenCharacterBackground");break;
        }
        chosenChars--;
    }

	// Use this for initialization
	void Start () {
        //First character selected
        name = characterName.GetComponent<Text>();
        characterSeries = "SF";
        artwork.GetComponent<Image>().sprite = Resources.Load<Sprite>("Textures_and_Sprites/Menus/Interface/CharacterSelectionMenu/CharacterProfile/SF/Ryu/Ryu");
        series.GetComponent<Image>().sprite = Resources.Load<Sprite>("Textures_and_Sprites/Menus/Interface/CharacterSelectionMenu/CharacterProfile/SF/SF_logo");
    }
	
	// Update is called once per frame
	void Update () {
        name.text = EventSystem.current.currentSelectedGameObject.name;
        if (Input.GetKeyDown(GameConstants.U)||(Input.GetKeyDown(GameConstants.D))|| Input.GetKeyDown(GameConstants.L)|| Input.GetKeyDown(GameConstants.R))
        {
            DisplayCharacterSelected(name.text);
        }
        if (Input.GetKeyDown(GameConstants.ACCEPT) && (chosenChars<maxChars))
        {
            ChooseCharacter(name.text);
        }
        if (Input.GetKeyDown(GameConstants.BACK) && (chosenChars > 0))
        {
            UnchooseCharacter();
        }
    }
}
