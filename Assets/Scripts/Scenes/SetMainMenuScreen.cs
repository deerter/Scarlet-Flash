using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMainMenuScreen : MonoBehaviour {

	// Use this for initialization
	void Start(){
		MusicPlayer music = GameObject.Find("Music").GetComponent<MusicPlayer>();
		if(music.CurrentMusic()=="None" || music.CurrentMusic()!="Main"){
			music.PlayMusic("Main");						////Plays main menu screen music
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
