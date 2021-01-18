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
    private LoadSceneonClick loadScene = new LoadSceneonClick();
    private PopUpWindow popUp;
    private bool isOnPopUp = false;

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
                + characterSeries + "/" + charName + "/" + "Chosen" + charName + "Background");
                CurrentFightStats.SetSelectedCharacterPlayer1(charName,0);break;
            case 2:
                secondChosenCharacter.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures_and_Sprites/Menus/Interface/CharacterSelectionMenu/CharacterProfile/"
                + characterSeries + "/" + charName + "/" + "Chosen" + charName + "Background");
                CurrentFightStats.SetSelectedCharacterPlayer1(charName,1);break;
            case 3:
                thirdChosenCharacter.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures_and_Sprites/Menus/Interface/CharacterSelectionMenu/CharacterProfile/"
                + characterSeries + "/" + charName + "/" + "Chosen" + charName + "Background");
                CurrentFightStats.SetSelectedCharacterPlayer1(charName,2);
                loadScene.LoadByIndex(8);break;
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
        popUp = this.GetComponent<PopUpWindow>();
        characterSeries = "SF";
        artwork.GetComponent<Image>().sprite = Resources.Load<Sprite>("Textures_and_Sprites/Menus/Interface/CharacterSelectionMenu/CharacterProfile/SF/Ryu/Ryu");
        series.GetComponent<Image>().sprite = Resources.Load<Sprite>("Textures_and_Sprites/Menus/Interface/CharacterSelectionMenu/CharacterProfile/SF/SF_logo");
    }
	
	// Update is called once per frame
	void Update () {
        if (!isOnPopUp){
            name.text = EventSystem.current.currentSelectedGameObject.name;
            if ((Input.GetKeyDown(GameConstants.U)||(Input.GetKeyDown(GameConstants.D))|| Input.GetKeyDown(GameConstants.L)|| Input.GetKeyDown(GameConstants.R)))
            {
                DisplayCharacterSelected(name.text);
            }
            if (Input.GetKeyDown(GameConstants.ACCEPT) && (chosenChars<maxChars))
            {
                ChooseCharacter(name.text);
            }
            if (Input.GetKeyDown(GameConstants.BACK))
            {
                if (chosenChars > 0){
                    UnchooseCharacter();
                }else{
                    popUp.PopUp();
                    isOnPopUp = true;
            }
        }
        }else{
            if (Input.GetKeyDown(GameConstants.ACCEPT)){
                isOnPopUp = false;
            }
        }
    }
}
