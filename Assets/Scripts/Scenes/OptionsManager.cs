using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OptionsManager : MonoBehaviour {

	private LoadSceneonClick loadScene;
	public enum PopUp {None = 0, Controls = 1, Language = 2, Version = 3};
	public PopUp currentPopUp;
	EventSystem myEventSystem;

	public void PopUpActive (int currentPopUp){
		this.currentPopUp = (PopUp) currentPopUp;
		myEventSystem = EventSystem.current;
	}

	private void PopUpInactive (){
		this.currentPopUp = PopUp.None;
		myEventSystem.currentSelectedGameObject.GetComponent<PopUpWindow>().ClosePopUp();
	}

	// Use this for initialization
	void Start () {
		loadScene = GetComponent<LoadSceneonClick>();
		myEventSystem = EventSystem.current;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(GameConstants.BACK)){
			switch(currentPopUp){
				case PopUp.None: loadScene.LoadByIndex(1); break;
				case PopUp.Controls: case PopUp.Language: case PopUp.Version: PopUpInactive(); break;
			}
		}
	}
}
