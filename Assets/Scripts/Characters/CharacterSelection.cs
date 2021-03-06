﻿using System.Collections;
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

    private LoadSceneonClick loadScene;
    private PopUpWindow popUp;
    private bool isOnPopUp = false;

    private SoundEffectPlayer soundEffect;

    private void DisplayCharacterSelected(string charName)
    {
        artwork.GetComponent<SpriteRenderer>().flipX = true;
        characterSeries = CharacterSelectionMapping.GetCharacterSeries(charName);
        artwork.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures_and_Sprites/Menus/Interface/CharacterSelectionMenu/CharacterProfile/" 
            + characterSeries + "/" + charName + "/" + charName + "PortraitSelection");
        series.GetComponent<Image>().sprite = Resources.Load<Sprite>("Textures_and_Sprites/Menus/Interface/CharacterSelectionMenu/CharacterProfile/"
            + characterSeries + "/" + characterSeries + "_logo");
        series.GetComponent<Image>().color = new Color(series.GetComponent<Image>().color.r, series.GetComponent<Image>().color.g, series.GetComponent<Image>().color.b, 1f);
    }

    private void DisplayRandom(){
        artwork.GetComponent<SpriteRenderer>().flipX = false;
        artwork.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures_and_Sprites/Menus/Interface/CharacterSelectionMenu/CharacterProfile/Random" 
            + "/" + name.text + "PortraitSelection");
        //series.GetComponent<Image>().sprite = null;
        series.GetComponent<Image>().color = new Color(series.GetComponent<Image>().color.r, series.GetComponent<Image>().color.g, series.GetComponent<Image>().color.b, 0f);
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
            soundEffect.PlaySoundEffect("ConfirmCharSel");
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
        soundEffect.PlaySoundEffect("Wrong");
        return false;
    }

    private void ChooseRandom(string randomType){
        soundEffect.PlaySoundEffect("ConfirmCharSel");
        switch(randomType){
            case "Random": ChooseOneRandom();break;
            case "Random3": ChooseThreeRandom();break;
        }
    }

    private void ChooseOneRandom (){
        string charName = "";
        do{
            charName = CharacterSelectionMapping.GetCharacter(Random.Range(0,4));
            characterSeries = CharacterSelectionMapping.GetCharacterSeries(charName);
        }
        while(!ChooseCharacter(charName));
    }

    private void ChooseThreeRandom(){
        while (chosenChars < 3){
            ChooseOneRandom();
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
        GameObject.Find("Music").GetComponent<MusicPlayer>().PlayMusic("Selection");  ////Plays character selection music
        soundEffect = GameObject.Find("SoundEffects").GetComponent<SoundEffectPlayer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!isOnPopUp){
            name.text = EventSystem.current.currentSelectedGameObject.name;
            if (Input.GetKey(GameConstants.U)||Input.GetKey(GameConstants.D)|| Input.GetKey(GameConstants.L)|| Input.GetKey(GameConstants.R))
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
                soundEffect.PlaySoundEffect("Back");
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
