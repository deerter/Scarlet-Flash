using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Point character Health: > 40% || (point character Health: < 40 % ; pointCharacter > secondCharacter; pointCharacter > thirdCharacter)
public class FirstRuleSwapCharacter : RulesInterface
{
    bool RulesInterface.condition(AIConditions conditions)
    {
        /*return ((conditions & AIConditions.leavePointCharacter) != 0)
            && ((conditions & AIConditions.changeSecondCharacter) == 0)
            && ((conditions & AIConditions.changeThirdCharacter) == 0);*/
        return false;
    }

    string RulesInterface.action()
    {
        /*string actionToTake = "";
        float randomValue = Random.value;
        if (randomValue < 0.01)
        {
            Debug.Log(randomValue);
            actionToTake = "SwapCharacter2";
        }
        else if (randomValue > 0.01 && randomValue < 0.02)
        {
            Debug.Log(randomValue);
            actionToTake = "SwapCharacter3";
        }

        return actionToTake;*/
        return "";
    }
}

/// Point character Health: < 40% ; pointCharacter < secondCharacter; secondCharacter > thirdCharacter
public class SecondRuleSwapCharacter : RulesInterface
{
    bool RulesInterface.condition(AIConditions conditions)
    {
        return ((conditions & AIConditions.leavePointCharacter) == 0)
            && ((conditions & AIConditions.changeSecondCharacter) != 0)
            && ((conditions & AIConditions.changeThirdCharacter) == 0);
    }

    string RulesInterface.action()
    {
        Debug.Log("fuuuuuck");
        string actionToTake = "";
        float randomValue = Random.value;
        if (randomValue < 0.8)
        {
            actionToTake = "SwapCharacter2";
        }
        else if (randomValue > 0.8 && randomValue < 0.9)
        {
            actionToTake = "SwapCharacter3";
        }

        return actionToTake;
    }
}

/// Point character Health: < 40% ; pointCharacter < secondCharacter; secondCharacter < thirdCharacter
public class ThirdRuleSwapCharacter : RulesInterface
{
    bool RulesInterface.condition(AIConditions conditions)
    {
        return ((conditions & AIConditions.leavePointCharacter) == 0)
            && ((conditions & AIConditions.changeSecondCharacter) == 0)
            && ((conditions & AIConditions.changeThirdCharacter) != 0);
    }

    string RulesInterface.action()
    {
        string actionToTake = "";
        float randomValue = Random.value;
        if (randomValue < 0.8)
        {
            actionToTake = "SwapCharacter3";
        }
        else if (randomValue > 0.8 && randomValue < 0.9)
        {
            actionToTake = "SwapCharacter2";
        }

        return actionToTake;
    }
}