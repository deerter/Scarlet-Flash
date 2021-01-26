using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneonClick : MonoBehaviour {

    public void LoadByIndex (int sceneIndex){
		SceneManager.LoadScene (sceneIndex);
	}
    
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (Input.GetKeyDown(GameConstants.BACK))
        {
            switch (currentScene.buildIndex)
            {
                case 2: LoadByIndex(1); break;             ///Versus and Options
                case 3: case 4: case 5: LoadByIndex(2); break;     ///VSCPU, CPUVSCPU, PVP 
            }
        }
    }

}
