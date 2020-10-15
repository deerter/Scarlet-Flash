using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager: MonoBehaviour {

    public static GameManager instance;
    //public ParticleSystem particleSystem;

    private void Awake()
    {
        MakeSingleton();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //particleSystem.Play();
    }

    private void MakeSingleton()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    
}  ////Class
