using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bars : MonoBehaviour
{

    [SerializeField] GameObject health;
    [SerializeField] GameObject hyper;
    [SerializeField] GameObject special;
    static int maxHealth = 1000000;
    static int maxHyper = 1000000;
    int currentHealth = maxHealth;
    int currentRedHealth = maxHealth;
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
        health.transform.GetChild(2).localScale = new Vector3(hpNormalized, 1f);
    }

    public void SetRedHealth(float redHealthNormalized)
    {
        health.transform.GetChild(1).localScale = new Vector3(redHealthNormalized, 1f);
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
        currentRedHealth -= attackValue / 4;
        

        if (currentHealth <= 0)
        {
            SetHP(0);
            SetRedHealth(0);
            return true;
        }
        SetHP((float)currentHealth / maxHealth);
        SetRedHealth((float)currentRedHealth / maxHealth);
        return false;
    }

    public bool increaseHyperBar(int attackValue)
    {
        //var newHyperBar = Instantiate(hyper, hyper.transform.position, hyper.transform.rotation, hyper.transform);
        GameObject newHyperBar = Instantiate(hyper.transform.GetChild(1).gameObject);
        newHyperBar.transform.SetParent(hyper.transform);
        newHyperBar.transform.localScale = hyper.transform.GetChild(1).localScale;
        newHyperBar.transform.localPosition = hyper.transform.GetChild(1).localPosition;

        newHyperBar.name = "HyperBarFullLevel2";
        //newHyperBar.transform.position = new Vector3(newHyperBar.transform.position.x,newHyperBar.transform.position.y + 50,newHyperBar.transform.position.z);
        //print(newHyperBar.transform.position);
        //newHyperBar.GetComponent<Image>().color = new Color(31, 186, 208);


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
            increaseHyperBar(45000);
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
