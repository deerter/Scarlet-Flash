using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

	public static MusicPlayer instance;
	private AudioSource currentMusic;

	// Use this for initialization
	void Start () {
		MakeSingleton();
		currentMusic = this.GetComponent<AudioSource>();
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
	
	public void PlayMusic(string currentSong){
		currentMusic.clip = Resources.Load<AudioClip>("Sound/Music/" + currentSong);
		currentMusic.Play();
	}

	public void StopMusic(){
		currentMusic.Stop();
	}

	public string CurrentMusic(){
		if (currentMusic.clip==null){
			return "Start";
		}
		return currentMusic.clip.name;
	}
}
