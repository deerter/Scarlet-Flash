using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///
public class FirstRuleRivalAttacks : RulesInterface
{
    private AIConditions conditions; // field

    public AIConditions Conditions   // property
    {
        get { return conditions; }   // get method
        set
        {
            conditions = value;
            if (conditions == (AIConditions.timer & AIConditions.characterStates))
            {

            }
        }  // set method
    }

    bool RulesInterface.condition(AIConditions conditions)
    {

        return false;
    }

    void RulesInterface.action()
    {

    }
}

public class SecondRuleRivalAttacks : RulesInterface
{

    bool RulesInterface.condition(bool isJumping)
    {
        return false;
    }

    void RulesInterface.action()
    {

    }
}

public class ThirdRuleRivalAttacks : RulesInterface
{

    bool RulesInterface.condition(bool isJumping)
    {
        return false;
    }

    void RulesInterface.action()
    {

    }
}

public class FourthRuleRivalAttacks : RulesInterface
{

    bool RulesInterface.condition(bool isJumping)
    {
        return false;
    }

    void RulesInterface.action()
    {

    }
}

public class FifthRuleRivalAttacks : RulesInterface
{

    bool RulesInterface.condition(bool isJumping)
    {
        return false;
    }

    void RulesInterface.action()
    {

    }
}

public class SixthRuleRivalAttacks : RulesInterface
{

    bool RulesInterface.condition(bool isJumping)
    {
        return false;
    }

    void RulesInterface.action()
    {

    }
}

public class SeventhRuleRivalAttacks : RulesInterface
{

    bool RulesInterface.condition(bool isJumping)
    {
        return false;
    }

    void RulesInterface.action()
    {

    }
}

public class EighthRuleRivalAttacks : RulesInterface
{

    bool RulesInterface.condition(bool isJumping)
    {
        return false;
    }

    void RulesInterface.action()
    {

    }
}

public class NinthRuleRivalAttacks : RulesInterface
{

    bool RulesInterface.condition(bool isJumping)
    {
        return false;
    }

    void RulesInterface.action()
    {

    }
}

public class TenthRuleRivalAttacks : RulesInterface
{

    bool RulesInterface.condition(bool isJumping)
    {
        return false;
    }

    void RulesInterface.action()
    {

    }
}

public class EleventhRuleRivalAttacks : RulesInterface
{

    bool RulesInterface.condition(bool isJumping)
    {
        return false;
    }

    void RulesInterface.action()
    {

    }
}

public class TwelfthRuleRivalAttacks : RulesInterface
{

    bool RulesInterface.condition(bool isJumping)
    {
        return false;
    }

    void RulesInterface.action()
    {

    }
}

public class ThirteenthRuleRivalAttacks : RulesInterface
{

    bool RulesInterface.condition(bool isJumping)
    {
        return false;
    }

    void RulesInterface.action()
    {

    }
}

public class FourteenthRuleRivalAttacks : RulesInterface
{

    bool RulesInterface.condition(bool isJumping)
    {
        return false;
    }

    void RulesInterface.action()
    {

    }
}

public class FifteenthRuleRivalAttacks : RulesInterface
{

    bool RulesInterface.condition(bool isJumping)
    {
        return false;
    }

    void RulesInterface.action()
    {

    }
}

public class SixteenthRuleRivalAttacks : RulesInterface
{

    bool RulesInterface.condition(bool isJumping)
    {
        return false;
    }

    void RulesInterface.action()
    {

    }
}


