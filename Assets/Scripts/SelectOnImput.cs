using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectOnImput : MonoBehaviour {
	public EventSystem eventSystem;
	public GameObject firstObject;
	public GameObject selectedObject;
	private bool buttonSelected;


	// Use this for initialization
	void Start () {
		selectObject ();
		//eventSystem.SetSelectedGameObject (firstObject);
	}
	
	// Update is called once per frame
	void Update () {
		/*if (Input.GetAxisRaw ("Vertical") != 0 && buttonSelected == false) {
			eventSystem.SetSelectedGameObject (selectedObject);
			buttonSelected = true;
		}*/
	}

	public void selectObject (){
		eventSystem.SetSelectedGameObject (firstObject);
	}

	/*private void OnDisable(){
		buttonSelected = false;
	}*/
}
