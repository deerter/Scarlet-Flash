using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class ButtonSoundEffects : MonoBehaviour {
	private SoundEffectPlayer soundEffect;
	

	// Use this for initialization
	void Start () {
		soundEffect = GameObject.Find("SoundEffects").GetComponent<SoundEffectPlayer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (EventSystem.current.currentSelectedGameObject==gameObject){
			if(Input.GetKeyDown(GameConstants.D) || Input.GetKeyDown(GameConstants.U)){
				PlayButtonSoundEffect("Cursor");
			}
		}
	}

	public void PlayButtonSoundEffect(string currentSoundEffect){
		soundEffect.PlaySoundEffect(currentSoundEffect);
	}
}
