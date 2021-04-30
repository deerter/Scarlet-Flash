using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetVersusScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject music = GameObject.Find("Music");
		music.GetComponent<MusicPlayer>().PlayMusic("Versus");  ////Plays versus screen music
		music.GetComponent<AudioSource>().loop=false;   /////Prevents music from looping
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
