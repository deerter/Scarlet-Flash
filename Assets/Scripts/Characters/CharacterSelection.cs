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
    private LoadSceneonClick loadScene;
    private PopUpWindow popUp;
    private bool isOnPopUp = false;

    private void DisplayCharacterSelected(string charName)
    {
        characterSeries = characterMapping.GetCharacterSeries(charName);
        artwork.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures_and_Sprites/Menus/Interface/CharacterSelectionMenu/CharacterProfile/" 
            + characterSeries + "/" + charName + "/" + charName + "PortraitSelection");
        series.GetComponent<Image>().sprite = Resources.Load<Sprite>("Textures_and_Sprites/Menus/Interface/CharacterSelectionMenu/CharacterProfile/"
            + characterSeries + "/" + characterSeries + "_logo");
    }

    private void DisplayRandom(){
        artwork.GetComponent<SpriteRenderer>().sprite = null;
        series.GetComponent<Image>().sprite = null;
    }

    private bool CharacterAlreadyChosen(string charName){
        for (int i = 0; i < chosenChars; i++){
            if (charName == CurrentFightStats.GetSelectedCharacter(i, "Player1")){
                return true;
            }
        }
        return false;
    }

    private bool ChooseCharacter(string charName)
    {
        if (!CharacterAlreadyChosen(charName)){
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
            return true;
        }
        return false;
    }

    private void ChooseRandom(string randomType){
        switch(randomType){
            case "Random": ChooseOneRandom();break;
            case "Random3": ChooseThreeRandom();break;
        }
    }

    private void ChooseOneRandom (){
        string charName = "";
        do{
            charName = characterMapping.GetCharacter(Random.Range(0,4));
            characterSeries = characterMapping.GetCharacterSeries(charName);
        }
        while(!ChooseCharacter(charName));
    }

    private void ChooseThreeRandom(){
        int randomSelection = 3;
        while (randomSelection > 0){
            ChooseOneRandom();
            randomSelection--;
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
        artwork.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures_and_Sprites/Menus/Interface/CharacterSelectionMenu/CharacterProfile/SF/Ryu/RyuPortraitSelection");
        series.GetComponent<Image>().sprite = Resources.Load<Sprite>("Textures_and_Sprites/Menus/Interface/CharacterSelectionMenu/CharacterProfile/SF/SF_logo");

        loadScene = EventSystem.current.GetComponent<LoadSceneonClick>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!isOnPopUp){
            name.text = EventSystem.current.currentSelectedGameObject.name;
            if ((Input.GetKey(GameConstants.U)||(Input.GetKey(GameConstants.D))|| Input.GetKey(GameConstants.L)|| Input.GetKey(GameConstants.R)))
            {
                if (name.text != "Random" && name.text != "Random3"){
                    DisplayCharacterSelected(name.text);
                }else{
                    DisplayRandom();
                }
            }
            if (Input.GetKeyDown(GameConstants.ACCEPT) && (chosenChars<maxChars))
            {
                if (name.text != "Random" && name.text != "Random3"){
                    ChooseCharacter(name.text);
                }else{
                    ChooseRandom(name.text);
                }
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
