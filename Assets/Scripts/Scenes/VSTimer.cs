using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VSTimer : MonoBehaviour {

	private float timeRemaining = 10;
	private bool timerIsRunning = false;

	private LoadSceneonClick nextScene = new LoadSceneonClick();


	// Use this for initialization
	void Start () {
		timerIsRunning = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (timerIsRunning){
			if (timeRemaining > 0){
				timeRemaining -= Time.deltaTime;
			}else{
				timeRemaining = 0;
				timerIsRunning = false;
				nextScene.LoadByIndex(9);
			}
		}
	}
}
