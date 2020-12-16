using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PopUpWindow : MonoBehaviour {

    public GameObject popUpWindow;
    public GameObject selectedObject;
    public Image image;
    EventSystem myEventSystem;
    static GameObject previouslySelectedObject;

    public void PopUp()
    {
        popUpWindow.SetActive(true);
        myEventSystem = EventSystem.current;
        previouslySelectedObject = myEventSystem.currentSelectedGameObject;
        myEventSystem.SetSelectedGameObject(selectedObject);
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0.6f);
    }

    public void ClosePopUp()
    {
        popUpWindow.SetActive(false);
        myEventSystem = EventSystem.current;
        myEventSystem.SetSelectedGameObject(previouslySelectedObject);
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
    }
}
