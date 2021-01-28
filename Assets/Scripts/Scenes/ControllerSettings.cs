using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

	public void changeButton(){
		typeof(GameConstants).GetField("U").SetValue(null, "moon");
		showButtons();
	}

	private void showButtons(){
		lightPunchButton.text = GameConstants.LP;
		lightKickButton.text = GameConstants.LK;
		heavyPunchButton.text = GameConstants.HP;
		heavyKickButton.text = GameConstants.HK;
		assist1Button.text = GameConstants.A1;
		assist2Button.text = GameConstants.A2;
		upButton.text = GameConstants.U;
		downButton.text = GameConstants.D;
		leftButton.text = GameConstants.L;
		rightButton.text = GameConstants.R;
	}


	// Use this for initialization
	void Start () {
		showButtons();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
