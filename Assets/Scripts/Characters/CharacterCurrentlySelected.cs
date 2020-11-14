using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterCurrentlySelected : MonoBehaviour {

    public GameObject artwork;
    public GameObject series;
    public GameObject characterName;

    private Text name;

    private CharacterSelectionMapping characterMapping = new CharacterSelectionMapping();

    private void DisplayCharacterSelected(string characterName)
    {
        artwork.GetComponent<Image>().sprite = Resources.Load<Sprite>("Textures_and_Sprites/Menus/Interface/CharacterSelectionMenu/CharacterProfile/" 
            + characterMapping.GetCharacterSeries(characterName) + "/" + characterName + "/" + characterName);
    }

	// Use this for initialization
	void Start () {
        name = characterName.GetComponent<Text>();
        artwork.GetComponent<Image>().sprite = Resources.Load<Sprite>("Textures_and_Sprites/Menus/Interface/CharacterSelectionMenu/CharacterProfile/SF/Ryu/Ryu");
    }
	
	// Update is called once per frame
	void Update () {
        name.text = EventSystem.current.currentSelectedGameObject.name;
        if (Input.GetKeyDown(GameConstants.U)||(Input.GetKeyDown(GameConstants.D))|| Input.GetKeyDown(GameConstants.L)|| Input.GetKeyDown(GameConstants.R))
        {
            DisplayCharacterSelected(name.text);
        }
    }
}
