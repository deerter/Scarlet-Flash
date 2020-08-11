using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bars : MonoBehaviour
{

    [SerializeField] GameObject health;
    [SerializeField] GameObject hyper;
    [SerializeField] GameObject special;
    static int maxHealth = 1000000;
    int currentHealth = maxHealth;
    static int maxSpecialTime = 5000;
    int currentSpecialTime = maxSpecialTime;
    Coroutine coroutineSpecial;
    bool specialActive = false;

    /*private void Start()
    {
        health.transform.localScale = new Vector3(0.5f, 1f);
        hyper.transform.localScale = new Vector3(1f, 1f);
        special.transform.localScale = new Vector3(0.15f, 1f);
    }*/

    public void SetHP(float hpNormalized)
    {
        health.transform.GetChild(1).localScale = new Vector3(hpNormalized, 1f);
    }

    public void SetHyper(float hyperNormalized)
    {
        hyper.transform.GetChild(1).localScale = new Vector3(hyperNormalized, 1f);
    }

    public void SetSpecial(float specialNormalized)
    {
        special.transform.GetChild(1).localScale = new Vector3(specialNormalized, 1f);
    }

    public bool TakeDamage(int attackValue)
    {
        currentHealth -= attackValue / 2;  //Half is red health
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            SetHP((float)currentHealth / maxHealth);
            return true;
        }
        SetHP((float)currentHealth / maxHealth);
        return false;
    }

    IEnumerator ConsumeSpecialBar(int rateDecrease)
    {
        while (currentSpecialTime > 0)
        {
            currentSpecialTime -= rateDecrease;
            SetSpecial((float)currentSpecialTime / maxSpecialTime);
            yield return false;
        }
        special.SetActive(false);
        currentSpecialTime = maxSpecialTime;
        specialActive = false;
        yield return true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(GameConstants.LP))
        {
            TakeDamage(45000);
        }

        if (Input.GetKeyDown(GameConstants.HP))
        {
            if (specialActive == false)
            {
                specialActive = true;
                special.SetActive(true);
                coroutineSpecial = StartCoroutine(ConsumeSpecialBar(10));
            }
        }

        if (Input.GetKeyDown(GameConstants.LK))
        {
            StopCoroutine(coroutineSpecial);
            specialActive = false;
        }
    }

}
