using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OptionsManager : MonoBehaviour {

	private LoadSceneonClick loadScene;
	public enum PopUp {None = 0, Controls = 1, Language = 2, Version = 3};
	public PopUp currentPopUp;
	private GameObject optionPressed;
	private SoundEffectPlayer soundEffect;

	public void PopUpActive (int currentPopUp){
		this.currentPopUp = (PopUp) currentPopUp;
		optionPressed = EventSystem.current.currentSelectedGameObject;
	}

	private void PopUpInactive (){
		this.currentPopUp = PopUp.None;
		optionPressed.GetComponent<PopUpWindow>().ClosePopUp();
	}

	// Use this for initialization
	void Start () {
		loadScene = GetComponent<LoadSceneonClick>();
		soundEffect = GameObject.Find("SoundEffects").GetComponent<SoundEffectPlayer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(GameConstants.BACK)){
			print(currentPopUp);
			switch(currentPopUp){
				case PopUp.None: soundEffect.PlaySoundEffect("Back"); loadScene.LoadByIndex(1); break;
				case PopUp.Controls: case PopUp.Language: case PopUp.Version: PopUpInactive(); break;
			}
		}
	}
}
