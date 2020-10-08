using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectOnInput : MonoBehaviour {
	public EventSystem eventSystem;
    public GameObject lastObject;
	private bool buttonSelected;
	private double lastInputTime;
	string sequenceQCF = "D DR R LP ";   //Needs a last space character
    string sequenceShoryuken = "R D R DR R LP ";  //Needs a last space character
    string sequence = "";
	int i = 0;
	double acceptableTime = 0.4;

    
	/*void Start () {
		selectObject ();
		eventSystem.SetSelectedGameObject (firstObject);
	}
	
	private void Update () {
        if (eventSystem.currentSelectedGameObject == lastObject)   //Para saber el objeto actualmente seleccionado
        addToString();
		specialMoveQCF ();
        shoryuken();
		if (Input.GetKeyDown("up")) {
			eventSystem.SetSelectedGameObject (selectedObject);
		}
		if (Input.GetKey ("right") && Input.GetKey ("down")) {
			Hadoken ();
			buttonPressedTime = Time.time;
			print (buttonPressedTime);
		}
		if (Input.GetAxisRaw ("Vertical") != 0 && buttonSelected == false) {
			eventSystem.SetSelectedGameObject (selectedObject);
			buttonSelected = true;
		}
	}

	private void addToString(){
        if (sequence == "" || Time.time - lastInputTime < acceptableTime)
        {
            if (Input.GetKeyDown(GameConstants.D))
            {
                sequence = sequence + "D ";
                //print("1 " + sequence);
                lastInputTime = Time.time;
            }
            else if (Input.GetKey(GameConstants.D) && Input.GetKeyDown(GameConstants.R))
            {
                sequence = sequence + "DR ";
                //print("1 " + sequence);
                lastInputTime = Time.time;
            }
            else if (Input.GetKeyDown(GameConstants.R) || Input.GetKeyUp(GameConstants.R))
            {
                sequence = sequence + "R ";
                //print("1 " + sequence);
                lastInputTime = Time.time;
            }
            else if (Input.GetKeyDown(GameConstants.LP))
            {
                sequence = sequence + "LP ";
                //print("1 " + sequence);
                lastInputTime = Time.time;
            }
            
        }
        else
        {
            sequence = "";
            //print("2 " + sequence);
        }

	}

	private void specialMoveQCF (){
        print(sequence);
		if (sequence == sequenceQCF)
        {
            print("Hadoooooken");
        }

		if (i == 0 || Time.time - lastInputTime < acceptableTime) {
		if (Input.GetKey (sequenceQCF [i])) {
				i++;
				lastInputTime = Time.time;
				if (i == sequenceQCF.Length) {
					print ("Hadooooken");
					i = 0;
				}
			}
		} else {
			i = 0;
		}
	}

    private void shoryuken()
    {
        print(sequence);
        if (sequence == sequenceShoryuken)
        {
            print("Shooooryuken");
        }
    }

	private void OnDisable(){
		buttonSelected = false;
	}*/
}
