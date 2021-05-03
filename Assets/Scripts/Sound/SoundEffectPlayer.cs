using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectPlayer : MonoBehaviour {

	public static SoundEffectPlayer instance;
	private AudioSource currentSoundEffect;

	// Use this for initialization
	void Start () {
		MakeSingleton();
		currentSoundEffect = this.GetComponent<AudioSource>();
	}
	
	private void MakeSingleton(){
		if(instance!=null && instance!=this)
        {
			Destroy(gameObject);
        }else{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}
	
	public void PlaySoundEffect(string currentEffect){
		currentSoundEffect.clip = Resources.Load<AudioClip>("Sound/Effects/" + currentEffect);
		currentSoundEffect.Play();
	}

	public void StopSoundEffect(){
		currentSoundEffect.Stop();
	}

	public bool SoundIsPlaying(){
		return currentSoundEffect.isPlaying;
	}

	public double CurrentTimeElapsed(){
		return (double)currentSoundEffect.timeSamples / currentSoundEffect.clip.frequency;
	}

	public double SoundEffectDuration(){
		return (double)currentSoundEffect.clip.samples / currentSoundEffect.clip.frequency;
	}
}
