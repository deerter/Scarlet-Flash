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

        if (Input.GetKeyDown("escape"))
        {
            switch (currentScene.buildIndex)
            {
                case 2: case 6: LoadByIndex(1); break;
                case 3: case 4: case 5: LoadByIndex(2); break;
                case 7: LoadByIndex(2);break;
                
            }
        }
    }

}
