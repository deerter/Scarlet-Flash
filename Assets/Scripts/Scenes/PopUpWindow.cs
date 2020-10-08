using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PopUpWindow : MonoBehaviour {

    public GameObject popUpWindow;
    EventSystem myEventSystem;

    public void PopUp(string objectName)
    {
        popUpWindow.SetActive(true);
        myEventSystem = EventSystem.current;
        myEventSystem.SetSelectedGameObject(GameObject.Find(objectName));
    }
}
