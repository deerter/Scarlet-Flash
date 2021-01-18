using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour{

	[SerializeField] Text counter;
	Coroutine decreaseCoroutine;

	private bool coroutineStarted = false;

	private static int timer;

	public void DecreaseTimer(){
		if (!coroutineStarted){
			decreaseCoroutine = StartCoroutine(Decreaser(timer));
		}		
	}

	public void StopTimer(){
		StopCoroutine(decreaseCoroutine);
	}

	IEnumerator Decreaser(int timeLeft){
		while(timeLeft > 0){
			coroutineStarted = true;
			UpdateTimer();
			counter.text = timer.ToString();
			yield return new WaitForSeconds(2);
			coroutineStarted = false;
		}
	}

	private void UpdateTimer(){
		timer--;
	}

	public int GetTimer(){
		return timer;
	}

	void Start(){
		if (CurrentFightStats.GetTimerActive()){
			timer = 100;
			counter.text = timer.ToString();
		}else{
			timer = -1;
			counter.fontSize = 100;
			counter.text = "\u221E";  //Infinity symbol
		}
	}
}
