using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class LanguageSelection : MonoBehaviour {

	////Needs a global class which knows the language currently chosen.//////

	[SerializeField] GameObject checkMark;

	public void SelectLanguage(){
		//Changes the current language in a global class
		checkMark.transform.position = new Vector3 (checkMark.transform.position.x, EventSystem.current.currentSelectedGameObject.transform.position.y, checkMark.transform.position.z);
	}

	// Use this for initialization
	void Start () {
		///Set the check mark to the correct language according to the one set in the global class///
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
