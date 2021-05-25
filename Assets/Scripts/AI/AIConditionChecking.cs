using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AIConditionChecking
{

    private static AIConditions conditions;

    public static AIConditions GetConditions()
    {
        return conditions;
    }

    public static void CheckTimer(int timer)
    {
        if (timer >= 20 || timer == -1)
        {
            conditions &= ~AIConditions.timer;
        }
        else
        {
            conditions |= AIConditions.timer;
        }
    }


}
