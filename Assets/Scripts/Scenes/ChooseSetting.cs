using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChooseSetting : MonoBehaviour {
	[SerializeField] private string[] settingOptions;
	[SerializeField] private GameObject settingText;
	[SerializeField] private GameObject leftArrow;
	[SerializeField] private GameObject rightArrow;
	[SerializeField] private int optionSelected;

	private void SetArrows(){
		rightArrow.transform.localPosition = new Vector2(settingText.transform.localPosition.x + (settingText.GetComponent<Text>().preferredWidth/2) + 30, rightArrow.transform.localPosition.y);
		leftArrow.transform.localPosition = new Vector2(settingText.transform.localPosition.x - (settingText.GetComponent<Text>().preferredWidth/2) - 30, rightArrow.transform.localPosition.y);
	}

	// Use this for initialization
	void Start () {
		//Sets the position of both arrows//
		SetArrows();
	}
	
	// Update is called once per frame
	void Update () {
		if (this.name==EventSystem.current.currentSelectedGameObject.name){
			if (Input.GetKeyDown(GameConstants.L) && (optionSelected != 0)){
				optionSelected--;
				settingText.GetComponent<Texts>().SetText(settingOptions[optionSelected]);
				if (optionSelected==0){
					leftArrow.SetActive(false);
				}
				rightArrow.SetActive(true);
				SetArrows();
			}
			if (Input.GetKeyDown(GameConstants.R) && (optionSelected != settingOptions.Length-1)){
				optionSelected++;
				settingText.GetComponent<Texts>().SetText(settingOptions[optionSelected]);
				if (optionSelected==settingOptions.Length-1){
					rightArrow.SetActive(false);
				}
				leftArrow.SetActive(true);
				SetArrows();
			}
		}
		
		
	}
}
