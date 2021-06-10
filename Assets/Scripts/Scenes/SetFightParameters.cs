using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFightParameters : MonoBehaviour
{

    public void SetDifficultyParameter(int childNumber)
    {
        ChooseSetting difficultySetting = this.transform.GetChild(childNumber).GetComponent<ChooseSetting>();

    }

    public void SetDifficulty2Parameter(int childNumber)
    { ////// Difficulty for CPU 2
        ChooseSetting difficulty2Setting = this.transform.GetChild(childNumber).GetComponent<ChooseSetting>();

    }

    public void SetTimerParameter(int childNumber)
    {
        ChooseSetting timerSetting = this.transform.GetChild(childNumber).GetComponent<ChooseSetting>();
        CurrentFightStats.SetTimer(timerSetting.GetValueOption());
    }


    public void SetDamageParameter(int childNumber)
    {
        ChooseSetting damageSetting = this.transform.GetChild(childNumber).GetComponent<ChooseSetting>();
        CurrentFightStats.SetDamage(damageSetting.GetValueOption());
    }

    // Use this for initialization
    void Start()
    {
        ////Set AIs depending on scene////
    }

    // Update is called once per frame
    void Update()
    {

    }
}
