using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class ControllerSettings : MonoBehaviour {

	[SerializeField] Text lightPunchButton;
	[SerializeField] Text lightKickButton;
	[SerializeField] Text heavyPunchButton;
	[SerializeField] Text heavyKickButton;
	[SerializeField] Text assist1Button;
	[SerializeField] Text assist2Button;
	[SerializeField] Text upButton;
	[SerializeField] Text downButton;
	[SerializeField] Text leftButton;
	[SerializeField] Text rightButton;

	KeyCode tempKeyCode;
	private bool waitForInput = false;
	private string buttonToChange;
	private GameObject currentButtonSelected;
	private SoundEffectPlayer soundEffect;

	public void ChangeButton(string key){
		buttonToChange = key;
		currentButtonSelected = EventSystem.current.currentSelectedGameObject;
		currentButtonSelected.GetComponent<Button>().interactable = false;
		typeof(GameConstants).GetField(buttonToChange).SetValue(null, null);
		waitForInput = true;
		ShowButtons();
	}

	private void ResetControls(){
		typeof(GameConstants).GetField("LP").SetValue(null, KeyCode.A);
		typeof(GameConstants).GetField("LK").SetValue(null, KeyCode.Z);
		typeof(GameConstants).GetField("HP").SetValue(null, KeyCode.S);
		typeof(GameConstants).GetField("HK").SetValue(null, KeyCode.X);
		typeof(GameConstants).GetField("A1").SetValue(null, KeyCode.D);
		typeof(GameConstants).GetField("A2").SetValue(null, KeyCode.C);
		typeof(GameConstants).GetField("U").SetValue(null, KeyCode.UpArrow);
		typeof(GameConstants).GetField("D").SetValue(null, KeyCode.DownArrow);
		typeof(GameConstants).GetField("L").SetValue(null, KeyCode.LeftArrow);
		typeof(GameConstants).GetField("R").SetValue(null, KeyCode.RightArrow);
	}

	 

	private void ShowButtons(){
		lightPunchButton.text = GameConstants.LP.ToString();
		lightKickButton.text = GameConstants.LK.ToString();
		heavyPunchButton.text = GameConstants.HP.ToString();
		heavyKickButton.text = GameConstants.HK.ToString();
		assist1Button.text = GameConstants.A1.ToString();
		assist2Button.text = GameConstants.A2.ToString();
		upButton.text = GameConstants.U.ToString();
		downButton.text = GameConstants.D.ToString();
		leftButton.text = GameConstants.L.ToString();
		rightButton.text = GameConstants.R.ToString();
	}

	void OnGUI(){
        Event e = Event.current;
		if (e.isKey && waitForInput && e.keyCode != KeyCode.Return && e.keyCode != KeyCode.Escape && e.keyCode != KeyCode.None){  //None must be checked because when the key is lifted, it sends a None event.//
			bool buttonAssigned;
			buttonAssigned = GameConstants.CheckButtonExists(e.keyCode);
			if (buttonAssigned == false){
				soundEffect.PlaySoundEffect("Confirm");
				typeof(GameConstants).GetField(buttonToChange).SetValue(null, e.keyCode);
				GameConstants.ReloadButtonsAsigned();
				currentButtonSelected.GetComponent<Button>().interactable = true;
				EventSystem.current.SetSelectedGameObject(currentButtonSelected);
				waitForInput = false;
				ShowButtons();
			}
			if (e.type == EventType.KeyUp && waitForInput)   /////Has to be played when key up, otherwise it replays the sound effect constantly while pressed
			{
				soundEffect.PlaySoundEffect("Wrong");
			}
		}
    }


	// Use this for initialization
	void Start () {
		ShowButtons();
		soundEffect = GameObject.Find("SoundEffects").GetComponent<SoundEffectPlayer>();
	}
	
	// Update is called once per frame
	void Update () {
		/*if (Input.GetKeyDown(GameConstants.BACK)){
			ResetControls();
		}*/
	}
}
