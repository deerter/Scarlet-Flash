using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar
{

    private GameObject health;
    private int maxHealth;
    private float currentHealth;
    private float currentRedHealth;

    public HealthBar(GameObject health, int maxHealth, string characterName)
    {
        this.health = health;
        this.maxHealth = maxHealth;
        this.currentHealth = maxHealth;
        this.currentRedHealth = maxHealth;
        health.transform.Find("CharacterName").GetComponent<Text>().text = characterName;
    }

    public int getMaxHP()
    {
        return this.maxHealth;
    }

    public float getHP()
    {
        return this.currentHealth;
    }

    public void SetHP(float hpNormalized)
    {
        health.transform.GetChild(2).localScale = new Vector3(hpNormalized, 1f);
    }

    public void SetRedHealth(float redHealthNormalized)
    {
        health.transform.GetChild(1).localScale = new Vector3(redHealthNormalized, 1f);
    }

    public bool Deplete(float attackValue)
    {
        currentHealth -= attackValue / 2;
        currentRedHealth -= attackValue / 4;


        if (currentHealth <= 0)
        {
            this.currentHealth = 0;
            SetHP(0);
            SetRedHealth(0);
            return true;
        }
        SetHP((float)currentHealth / maxHealth);
        SetRedHealth((float)currentRedHealth / maxHealth);
        return false;
    }
}
