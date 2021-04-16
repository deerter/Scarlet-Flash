using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class LanguageSelection : MonoBehaviour {

	[SerializeField] GameObject checkMark;

	public void SelectLanguage(int changedLanguage){
		Language.ChangeLanguage(changedLanguage);
		print(Language.prueba);
		checkMark.transform.position = new Vector3 (checkMark.transform.position.x, EventSystem.current.currentSelectedGameObject.transform.position.y, checkMark.transform.position.z);
	}

	// Use this for initialization
	void Start () {
		GameObject currentLanguageButton = gameObject.transform.GetChild(Language.GetLanguage()+1).gameObject;  // + 1 because the first child object is the dark background image //
		///Set the check mark to the correct language according to the one set in the global class///
		checkMark.transform.position = new Vector3 (checkMark.transform.position.x, currentLanguageButton.transform.position.y, checkMark.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
