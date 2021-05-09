using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnnouncerVoice : MonoBehaviour {
	public static AnnouncerVoice instance;
	private AudioSource currentAnnouncer;

	// Use this for initialization
	void Start () {
		MakeSingleton();
		currentAnnouncer = this.GetComponent<AudioSource>();
	}

	private void MakeSingleton(){
		if(instance!=null && instance!=this)
        {
			Destroy(gameObject);
        }else{
			instance = this;
		}
	}

	public void PlayAnnouncer(string announcer){
		currentAnnouncer.clip = Resources.Load<AudioClip>("Sound/Announcer/" + announcer);
		currentAnnouncer.Play();
	}

	public bool AnnouncerIsPlaying(){
		return currentAnnouncer.isPlaying;
	}
	
}
