using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Texts : MonoBehaviour {
	[SerializeField] string key;

	public void SetText(){
		this.GetComponent<Text>().text = Language.GetText(key);
	}

	// Use this for initialization
	void Start () {
		Language.ReadCSV();  //////////
		SetText();
	}
}
