using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Texts : MonoBehaviour {
	[SerializeField] private string key;

	public void SetText(string givenKey){
		if(givenKey=="reloadText"){
			givenKey=key;
		}
		this.GetComponent<Text>().text = Language.GetText(givenKey);
	}

	public string GetKey(){
		return key;
	}

	// Use this for initialization
	/*void Start () {
		Language.ReadCSV();  //////////
		SetText();
	}*/

	void OnEnable(){
		Language.ReadCSV(); ////////////
		SetText(key);
	}
}
