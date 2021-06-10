using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    [SerializeField] Text counter;
    Coroutine decreaseCoroutine;

    private bool coroutineStarted = false;

    private static float timer;

    public void DecreaseTimer()
    {
        if (!coroutineStarted)
        {
            decreaseCoroutine = StartCoroutine(Decreaser(timer));
        }
    }

    public void StopTimer()
    {
        StopCoroutine(decreaseCoroutine);
    }

    IEnumerator Decreaser(float timeLeft)
    {
        while (timeLeft > 0)
        {
            coroutineStarted = true;
            UpdateTimer();
            counter.text = timer.ToString();
            yield return new WaitForSeconds(2);
            coroutineStarted = false;
        }
    }

    private void UpdateTimer()
    {
        timer--;
    }

    public float GetTimer()
    {
        return timer;
    }

    void Start()
    {
        if (CurrentFightStats.GetTimer() > 0)
        {
            //timer = 100;
            timer = CurrentFightStats.GetTimer();
            counter.text = timer.ToString();
        }
        else
        {
            timer = -1;
            counter.fontSize = 100;
            counter.text = "\u221E";  //Infinity symbol
        }
    }
}
