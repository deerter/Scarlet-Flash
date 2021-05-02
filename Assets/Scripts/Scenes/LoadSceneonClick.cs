using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneonClick : MonoBehaviour {

    private SoundEffectPlayer soundEffect;

    public void LoadByIndex (int sceneIndex){
		SceneManager.LoadScene (sceneIndex);
	}

    void Start(){
        soundEffect = GameObject.Find("SoundEffects").GetComponent<SoundEffectPlayer>();
    }
    
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (Input.GetKeyDown(GameConstants.BACK))
        {
            switch (currentScene.buildIndex)
            {
                case 2: soundEffect.PlaySoundEffect("Back"); LoadByIndex(1); break;             ///Versus
                case 3: case 4: case 5: soundEffect.PlaySoundEffect("Back"); LoadByIndex(2); break;     ///VSCPU, CPUVSCPU, PVP 
            }
        }
    }

}
