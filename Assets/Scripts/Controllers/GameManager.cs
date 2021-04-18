using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager: MonoBehaviour {

    public static GameManager instance;

    private void Awake()
    {
        MakeSingleton();
        Language.ReadCSV();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void MakeSingleton()
    {
        if(instance!=null && instance!=this)
        {
            Destroy(gameObject);  //Same as this.gameObject
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    
}  ////Class
