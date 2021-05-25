using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///
public class FirstRuleRivalAttacks : RulesInterface
{

    bool RulesInterface.condition(AIConditions conditions)
    {
        return ((conditions & AIConditions.timer) != 0);
        //&& ((conditions & AIConditions.characterHealth) != 0);
    }

    string RulesInterface.action()
    {
        string animationToPlay;
        float randomValue = Random.value;
        if (randomValue > 0.5)
        {
            animationToPlay = AnimationStates.HEAVY_KICK;
        }
        else
        {
            animationToPlay = AnimationStates.HEAVY_PUNCH;
        }

        return animationToPlay;
    }
}

public class SecondRuleRivalAttacks : RulesInterface
{

    bool RulesInterface.condition(AIConditions conditions)
    {
        return false;
    }

    string RulesInterface.action()
    {
        return "";
    }
}

public class ThirdRuleRivalAttacks : RulesInterface
{

    bool RulesInterface.condition(AIConditions conditions)
    {
        return false;
    }

    string RulesInterface.action()
    {
        return "";
    }
}

public class FourthRuleRivalAttacks : RulesInterface
{

    bool RulesInterface.condition(AIConditions conditions)
    {
        return false;
    }

    string RulesInterface.action()
    {
        return "";
    }
}

public class FifthRuleRivalAttacks : RulesInterface
{

    bool RulesInterface.condition(AIConditions conditions)
    {
        return false;
    }

    string RulesInterface.action()
    {
        return "";
    }
}

public class SixthRuleRivalAttacks : RulesInterface
{

    bool RulesInterface.condition(AIConditions conditions)
    {
        return false;
    }

    string RulesInterface.action()
    {
        return "";
    }
}

public class SeventhRuleRivalAttacks : RulesInterface
{

    bool RulesInterface.condition(AIConditions conditions)
    {
        return false;
    }

    string RulesInterface.action()
    {
        return "";
    }
}

public class EighthRuleRivalAttacks : RulesInterface
{

    bool RulesInterface.condition(AIConditions conditions)
    {
        return false;
    }

    string RulesInterface.action()
    {
        return "";
    }
}

public class NinthRuleRivalAttacks : RulesInterface
{

    bool RulesInterface.condition(AIConditions conditions)
    {
        return false;
    }

    string RulesInterface.action()
    {
        return "";
    }
}

public class TenthRuleRivalAttacks : RulesInterface
{

    bool RulesInterface.condition(AIConditions conditions)
    {
        return false;
    }

    string RulesInterface.action()
    {
        return "";
    }
}

public class EleventhRuleRivalAttacks : RulesInterface
{

    bool RulesInterface.condition(AIConditions conditions)
    {
        return false;
    }

    string RulesInterface.action()
    {
        return "";
    }
}

public class TwelfthRuleRivalAttacks : RulesInterface
{

    bool RulesInterface.condition(AIConditions conditions)
    {
        return false;
    }

    string RulesInterface.action()
    {
        return "";
    }
}

public class ThirteenthRuleRivalAttacks : RulesInterface
{

    bool RulesInterface.condition(AIConditions conditions)
    {
        return false;
    }

    string RulesInterface.action()
    {
        return "";
    }
}

public class FourteenthRuleRivalAttacks : RulesInterface
{

    bool RulesInterface.condition(AIConditions conditions)
    {
        return false;
    }

    string RulesInterface.action()
    {
        return "";
    }
}

public class FifteenthRuleRivalAttacks : RulesInterface
{

    bool RulesInterface.condition(AIConditions conditions)
    {
        return false;
    }

    string RulesInterface.action()
    {
        return "";
    }
}

public class SixteenthRuleRivalAttacks : RulesInterface
{

    bool RulesInterface.condition(AIConditions conditions)
    {
        return false;
    }

    string RulesInterface.action()
    {
        return "";
    }
}


