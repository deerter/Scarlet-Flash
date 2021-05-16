using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSoundEffect : MonoBehaviour {

	private AudioSource currentCharacterSoundEffect;

	// Use this for initialization
	void Start () {
		currentCharacterSoundEffect = this.GetComponent<AudioSource>();
	}
	
	public void PlayCharacterSoundEffect(string characterSoundEffect){
		currentCharacterSoundEffect.clip = Resources.Load<AudioClip>("Sound/Characters/SoundEffects/" + characterSoundEffect);
		currentCharacterSoundEffect.Play(); 
	}
}
