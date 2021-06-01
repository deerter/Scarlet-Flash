using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Timer > 20 || infinite ; Distance: Close ; Characer health: Full ; Character State: Ground
public class FirstRuleRivalIdle : RulesInterface
{
    bool RulesInterface.condition(AIConditions conditions)
    {
        return ((conditions & AIConditions.timer) == 0)
            && ((conditions & AIConditions.distance) != 0)
            && ((conditions & AIConditions.characterHealth) == 0)
            && ((conditions & AIConditions.characterStateAir) == 0);
    }

    string RulesInterface.action()
    {
        string animationToPlay = "";
        float randomValue = Random.value;

        if (randomValue < 0.8)
        {
            string[] possibleAttacks = AnimationStates.GetGroundAttacks();
            int randomAttack = Random.Range(0, possibleAttacks.Length - 1);
            animationToPlay = possibleAttacks[randomAttack];
        }
        else
        {
            animationToPlay = AnimationStates.WALK_BACKWARDS;
        }

        return animationToPlay;
    }
}

/// Timer > 20 || infinite ; Distance: Close ; Characer health: Full ; Character State: Air
public class SecondRuleRivalIdle : RulesInterface
{
    bool RulesInterface.condition(AIConditions conditions)
    {
        return ((conditions & AIConditions.timer) == 0)
            && ((conditions & AIConditions.distance) != 0)
            && ((conditions & AIConditions.characterHealth) == 0)
            && ((conditions & AIConditions.characterStateAir) != 0);
    }

    string RulesInterface.action()
    {
        string animationToPlay = "";
        float randomValue = Random.value;

        if (randomValue < 0.8)
        {
            string[] possibleAttacks = AnimationStates.GetAirAttacks();
            int randomAttack = Random.Range(0, possibleAttacks.Length - 1);
            animationToPlay = possibleAttacks[randomAttack];
        }
        else
        {
            animationToPlay = AnimationStates.BLOCKING_JUMPING;
        }

        return animationToPlay;
    }
}

/// Timer > 20 || infinite ; Distance: Far ; Characer health: Full ; Character State: Ground
public class ThirdRuleRivalIdle : RulesInterface
{
    bool RulesInterface.condition(AIConditions conditions)
    {
        return ((conditions & AIConditions.timer) == 0)
            && ((conditions & AIConditions.distance) == 0)
            && ((conditions & AIConditions.characterHealth) == 0)
            && ((conditions & AIConditions.characterStateAir) == 0);
    }

    string RulesInterface.action()
    {
        string animationToPlay = "";
        float randomValue = Random.value;

        if (randomValue < 0.4)
        {
            animationToPlay = AnimationStates.WALK_FORWARDS;
        }
        else if (randomValue > 0.4 && randomValue < 0.8)
        {
            animationToPlay = AnimationStates.JUMPING_FORWARDS;
        }
        else
        {
            animationToPlay = AnimationStates.JUMPING_UP;
        }

        return animationToPlay;
    }
}

/// Timer > 20 || infinite ; Distance: Far ; Characer health: Full ; Character State: Air
public class FourthRuleRivalIdle : RulesInterface
{
    bool RulesInterface.condition(AIConditions conditions)
    {
        return ((conditions & AIConditions.timer) == 0)
            && ((conditions & AIConditions.distance) == 0)
            && ((conditions & AIConditions.characterHealth) == 0)
            && ((conditions & AIConditions.characterStateAir) != 0);
    }

    string RulesInterface.action()
    {
        return "";
    }
}

/// Timer > 20 || infinite ; Distance: Close ; Characer health: Low ; Character State: Ground
public class FifthRuleRivalIdle : RulesInterface
{
    bool RulesInterface.condition(AIConditions conditions)
    {
        return ((conditions & AIConditions.timer) == 0)
            && ((conditions & AIConditions.distance) != 0)
            && ((conditions & AIConditions.characterHealth) != 0)
            && ((conditions & AIConditions.characterStateAir) == 0);
    }

    string RulesInterface.action()
    {
        string animationToPlay = "";
        float randomValue = Random.value;

        if (randomValue < 0.8)
        {
            animationToPlay = AnimationStates.WALK_BACKWARDS;
        }
        else if (randomValue > 0.8 && randomValue < 0.9)
        {
            animationToPlay = AnimationStates.JUMPING_BACKWARDS;
        }
        else
        {
            string[] possibleAttacks = AnimationStates.GetGroundAttacks();
            int randomAttack = Random.Range(0, possibleAttacks.Length - 1);
            animationToPlay = possibleAttacks[randomAttack];
        }

        return animationToPlay;
    }
}

/// Timer > 20 || infinite ; Distance: Close ; Characer health: Low ; Character State: Air
public class SixthRuleRivalIdle : RulesInterface
{
    bool RulesInterface.condition(AIConditions conditions)
    {
        return ((conditions & AIConditions.timer) == 0)
            && ((conditions & AIConditions.distance) != 0)
            && ((conditions & AIConditions.characterHealth) != 0)
            && ((conditions & AIConditions.characterStateAir) != 0);
    }

    string RulesInterface.action()
    {
        string animationToPlay = "";
        float randomValue = Random.value;

        if (randomValue < 0.8)
        {
            animationToPlay = AnimationStates.BLOCKING_JUMPING;
        }
        else
        {
            string[] possibleAttacks = AnimationStates.GetAirAttacks();
            int randomAttack = Random.Range(0, possibleAttacks.Length - 1);
            animationToPlay = possibleAttacks[randomAttack];
        }

        return animationToPlay;
    }
}

/// Timer > 20 || infinite ; Distance: Far ; Characer health: Low ; Character State: Ground
public class SeventhRuleRivalIdle : RulesInterface
{
    bool RulesInterface.condition(AIConditions conditions)
    {
        return ((conditions & AIConditions.timer) == 0)
            && ((conditions & AIConditions.distance) == 0)
            && ((conditions & AIConditions.characterHealth) != 0)
            && ((conditions & AIConditions.characterStateAir) == 0);
    }

    string RulesInterface.action()
    {
        string animationToPlay = "";
        float randomValue = Random.value;

        if (randomValue < 0.4)
        {
            animationToPlay = AnimationStates.WALK_BACKWARDS;
        }
        else if (randomValue > 0.4 && randomValue < 0.8)
        {
            animationToPlay = AnimationStates.JUMPING_BACKWARDS;
        }
        else if (randomValue > 0.8 && randomValue < 0.9)
        {
            animationToPlay = AnimationStates.WALK_FORWARDS;
        }
        else
        {
            animationToPlay = AnimationStates.JUMPING_FORWARDS;
        }

        return animationToPlay;
    }
}

/// Timer > 20 || infinite ; Distance: Far ; Characer health: Low ; Character State: Air
public class EighthRuleRivalIdle : RulesInterface
{
    bool RulesInterface.condition(AIConditions conditions)
    {
        return ((conditions & AIConditions.timer) == 0)
            && ((conditions & AIConditions.distance) == 0)
            && ((conditions & AIConditions.characterHealth) != 0)
            && ((conditions & AIConditions.characterStateAir) != 0);
    }

    string RulesInterface.action()
    {
        string animationToPlay = "";
        float randomValue = Random.value;

        if (randomValue < 0.8)
        {
            animationToPlay = AnimationStates.BLOCKING_JUMPING;
        }

        return animationToPlay;
    }
}

/// Timer < 20 ; Distance: Close ; Characer health: High (Rival > Own) ; Character State: Ground
public class NinthRuleRivalIdle : RulesInterface
{
    bool RulesInterface.condition(AIConditions conditions)
    {
        return ((conditions & AIConditions.timer) != 0)
            && ((conditions & AIConditions.distance) != 0)
            && ((conditions & AIConditions.characterHealth) == 0)
            && ((conditions & AIConditions.characterStateAir) == 0);
    }

    string RulesInterface.action()
    {
        string animationToPlay = "";
        float randomValue = Random.value;

        if (randomValue < 0.9)
        {
            string[] possibleAttacks = AnimationStates.GetGroundAttacks();
            int randomAttack = Random.Range(0, possibleAttacks.Length - 1);
            animationToPlay = possibleAttacks[randomAttack];
        }
        else
        {
            animationToPlay = AnimationStates.WALK_BACKWARDS;
        }

        return animationToPlay;
    }
}

/// Timer < 20 ; Distance: Close ; Characer health: High (Rival > Own) ; Character State: Air
public class TenthRuleRivalIdle : RulesInterface
{
    bool RulesInterface.condition(AIConditions conditions)
    {
        return ((conditions & AIConditions.timer) != 0)
            && ((conditions & AIConditions.distance) != 0)
            && ((conditions & AIConditions.characterHealth) == 0)
            && ((conditions & AIConditions.characterStateAir) != 0);
    }

    string RulesInterface.action()
    {
        string animationToPlay = "";
        float randomValue = Random.value;

        if (randomValue < 0.9)
        {
            string[] possibleAttacks = AnimationStates.GetAirAttacks();
            int randomAttack = Random.Range(0, possibleAttacks.Length - 1);
            animationToPlay = possibleAttacks[randomAttack];
        }
        else
        {
            animationToPlay = AnimationStates.BLOCKING_JUMPING;
        }

        return animationToPlay;
    }
}

/// Timer < 20 ; Distance: Far ; Characer health: High (Rival > Own) ; Character State: Ground
public class EleventhRuleRivalIdle : RulesInterface
{
    bool RulesInterface.condition(AIConditions conditions)
    {
        return ((conditions & AIConditions.timer) != 0)
            && ((conditions & AIConditions.distance) == 0)
            && ((conditions & AIConditions.characterHealth) == 0)
            && ((conditions & AIConditions.characterStateAir) == 0);
    }

    string RulesInterface.action()
    {
        string animationToPlay = "";
        float randomValue = Random.value;

        if (randomValue < 0.5)
        {
            animationToPlay = AnimationStates.WALK_FORWARDS;
        }
        else
        {
            animationToPlay = AnimationStates.JUMPING_FORWARDS;
        }

        return animationToPlay;
    }
}

/// Timer < 20 ; Distance: Far ; Characer health: High (Rival > Own) ; Character State: Air
public class TwelfthRuleRivalIdle : RulesInterface
{
    bool RulesInterface.condition(AIConditions conditions)
    {
        return ((conditions & AIConditions.timer) != 0)
            && ((conditions & AIConditions.distance) == 0)
            && ((conditions & AIConditions.characterHealth) == 0)
            && ((conditions & AIConditions.characterStateAir) != 0);
    }

    string RulesInterface.action()
    {
        return "";
    }
}

/// Timer < 20 ; Distance: Close ; Characer health: Low (Rival < Own) ; Character State: Ground
public class ThirteenthRuleRivalIdle : RulesInterface
{
    bool RulesInterface.condition(AIConditions conditions)
    {
        return ((conditions & AIConditions.timer) != 0)
            && ((conditions & AIConditions.distance) != 0)
            && ((conditions & AIConditions.characterHealth) != 0)
            && ((conditions & AIConditions.characterStateAir) == 0);
    }

    string RulesInterface.action()
    {
        string animationToPlay = "";
        float randomValue = Random.value;

        if (randomValue < 0.9)
        {
            animationToPlay = AnimationStates.WALK_BACKWARDS;
        }
        else
        {
            animationToPlay = AnimationStates.JUMPING_BACKWARDS;
        }

        return animationToPlay;
    }
}

/// Timer < 20 ; Distance: Close ; Characer health: Low (Rival < Own) ; Character State: Air
public class FourteenthRuleRivalIdle : RulesInterface
{
    bool RulesInterface.condition(AIConditions conditions)
    {
        return ((conditions & AIConditions.timer) != 0)
            && ((conditions & AIConditions.distance) != 0)
            && ((conditions & AIConditions.characterHealth) != 0)
            && ((conditions & AIConditions.characterStateAir) != 0);
    }

    string RulesInterface.action()
    {

        return AnimationStates.BLOCKING_JUMPING;
    }
}

/// Timer < 20 ; Distance: Far ; Characer health: Low (Rival < Own) ; Character State: Ground
public class FifteenthRuleRivalIdle : RulesInterface
{
    bool RulesInterface.condition(AIConditions conditions)
    {
        return ((conditions & AIConditions.timer) != 0)
            && ((conditions & AIConditions.distance) == 0)
            && ((conditions & AIConditions.characterHealth) != 0)
            && ((conditions & AIConditions.characterStateAir) == 0);
    }

    string RulesInterface.action()
    {
        string animationToPlay = "";
        float randomValue = Random.value;

        if (randomValue < 0.5)
        {
            animationToPlay = AnimationStates.WALK_BACKWARDS;
        }
        else
        {
            animationToPlay = AnimationStates.JUMPING_BACKWARDS;
        }

        return animationToPlay;
    }
}

/// Timer < 20 ; Distance: Far ; Characer health: Low (Rival < Own) ; Character State: Air
public class SixteenthRuleRivalIdle : RulesInterface
{
    bool RulesInterface.condition(AIConditions conditions)
    {
        return ((conditions & AIConditions.timer) != 0)
            && ((conditions & AIConditions.distance) == 0)
            && ((conditions & AIConditions.characterHealth) != 0)
            && ((conditions & AIConditions.characterStateAir) != 0);
    }

    string RulesInterface.action()
    {
        return AnimationStates.BLOCKING_JUMPING;
    }
}

