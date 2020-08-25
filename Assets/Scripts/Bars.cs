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
    int hyperLevel = 1;
    int currentHyper = 0;
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
        currentHealth -= attackValue / 2;
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

    /// Hyper Bar Functions ///

    private bool changeColorHyperBar(GameObject newHyperBar)
    {
        Color currentColor = newHyperBar.GetComponent<Image>().color;
        float maxColor = (float) 150 / 255;
        float minColor = (float) 85 / 255;
        int randomNumber = Random.Range(150, 180);
        if ((currentColor.b > maxColor) && (currentColor.r < minColor) && (currentColor.g < minColor))
        {
            newHyperBar.GetComponent<Image>().color = new Color(currentColor.r, currentColor.g + randomNumber/255f,currentColor.b, 1);
            return true;
        }
        else if ((currentColor.b > maxColor) && (currentColor.r < minColor) && (currentColor.g > maxColor))
        {
            newHyperBar.GetComponent<Image>().color = new Color(currentColor.r, currentColor.g , currentColor.b - randomNumber / 255f, 1);
            return true;
        }
        else if ((currentColor.b < minColor) && (currentColor.r < minColor) && (currentColor.g > maxColor))
        {
            newHyperBar.GetComponent<Image>().color = new Color(currentColor.r + randomNumber / 255f + 0.20f, currentColor.g, currentColor.b, 1);
            return true;
        }
        else if ((currentColor.b < minColor) && (currentColor.r > maxColor) && (currentColor.g > maxColor))
        {
            newHyperBar.GetComponent<Image>().color = new Color(currentColor.r, currentColor.g - randomNumber / 255f, currentColor.b, 1);
            return true;
        }
        else if ((currentColor.b < minColor) && (currentColor.r > maxColor) && (currentColor.g < minColor))
        {
            newHyperBar.GetComponent<Image>().color = new Color(currentColor.r, currentColor.g, currentColor.b + randomNumber / 255f, 1);
            return true;
        }
        else if ((currentColor.b > maxColor) && (currentColor.r > maxColor) && (currentColor.g < minColor))
        {
            newHyperBar.GetComponent<Image>().color = new Color(currentColor.r - randomNumber / 255f - 0.20f, currentColor.g, currentColor.b , 1);
            return true;
        }
        
        return false;
    }

    public bool increaseHyperBar(int attackValue)
    {
        if (hyper.transform.childCount < 6)
        {

            GameObject newHyperBar = Instantiate(hyper.transform.GetChild(hyperLevel).gameObject);
            newHyperBar.transform.localScale = new Vector3(0.82f,1f);
            newHyperBar.transform.SetParent(hyper.transform, false);
            newHyperBar.name = "HyperBarFullLevel" + (hyperLevel+1);
            //newHyperBar.transform.localPosition = new Vector3(newHyperBar.transform.localPosition.x, newHyperBar.transform.localPosition.y, newHyperBar.transform.localPosition.z);  //Para visualizarlo, luego se debe borrar
            changeColorHyperBar(newHyperBar);
            hyperLevel++;
        }

        return false;
    }

    public bool decreaseHyperBar(int hyperAttackLevel)
    {

        return false;
    }

    /// Special bar functions ///

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
