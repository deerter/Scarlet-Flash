using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterCurrentlySelected : MonoBehaviour {

    public GameObject artwork;
    public GameObject series;
    public GameObject characterName;

    private Text name;

	// Use this for initialization
	void Start () {
        name = characterName.GetComponent<Text>();
        artwork.GetComponent<Image>().sprite = Resources.Load<Sprite>("Ryu");   //////Aqui carga la imagen
    }
	
	// Update is called once per frame
	void Update () {
        name.text = EventSystem.current.currentSelectedGameObject.name;
        //artwork.GetComponent<Image>().sprite = Resources.Load<Sprite>("Ryu art");
    }
}
