using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterVoice : MonoBehaviour {

	private AudioSource currentCharacterVoice;

	// Use this for initialization
	void Start () {
		currentCharacterVoice = this.GetComponent<AudioSource>();
	}
	
	public void PlayCharacterVoice(string characterVoice, string characterSeries, string characterName){
		currentCharacterVoice.clip = Resources.Load<AudioClip>("Sound/Characters/Voices/" + characterSeries + "/" + characterName + "/" + characterVoice);
		currentCharacterVoice.Play();
	}
}
