using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetVersusScreen : MonoBehaviour {
	[SerializeField] private GameObject portraitsPlayer1;
	[SerializeField] private GameObject portraitsPlayer2;

	// Use this for initialization
	void Start () {
		GameObject music = GameObject.Find("Music");
		music.GetComponent<MusicPlayer>().PlayMusic("Versus");  ////Plays versus screen music
		music.GetComponent<AudioSource>().loop=false;   /////Prevents music from looping
		SetVsPortraits(portraitsPlayer1);
		SetVsPortraits(portraitsPlayer2);
	}

	private void SetVsPortraits(GameObject portraits){
		int portraitNumber = 0;
		foreach (Transform portrait in portraits.transform){
			string charName = CurrentFightStats.GetSelectedCharacter(portraitNumber, portrait.tag);
			string characterSeries = CharacterSelectionMapping.GetCharacterSeries(charName);
			portrait.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures_and_Sprites/Menus/Interface/CharacterSelectionMenu/CharacterProfile/"
                    + characterSeries + "/" + charName + "/" + "Chosen" + charName + "Background");
			portraitNumber++;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
