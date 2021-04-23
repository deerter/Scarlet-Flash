using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChooseSetting : MonoBehaviour {
	[SerializeField] private string[] settingOptions;
	[SerializeField] private GameObject settingText;
	[SerializeField] private int optionSelected;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (this.name==EventSystem.current.currentSelectedGameObject.name){
			if (Input.GetKeyDown(GameConstants.L) && (optionSelected != 0)){
				optionSelected--;
				settingText.GetComponent<Texts>().SetText(settingOptions[optionSelected]);
				if (optionSelected==0){
					///Disable left arrow
				}
			}
			if (Input.GetKeyDown(GameConstants.R) && (optionSelected != settingOptions.Length-1)){
				optionSelected++;
				settingText.GetComponent<Texts>().SetText(settingOptions[optionSelected]);
				if (optionSelected==settingOptions.Length+1){
					///Disable right arrow
				}
			}
		}
		
		
	}
}
