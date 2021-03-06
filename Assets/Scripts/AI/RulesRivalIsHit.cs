﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// Timer > 20 || infinite ; Distance: Close ; Characer health: Full ; Character State: Ground
public class FirstRuleRivalIsHit : RulesInterface
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
        string[] possibleAttacks = AnimationStates.GetGroundAttacks();
        int randomAttack = Random.Range(0, possibleAttacks.Length - 1);
        return possibleAttacks[randomAttack];
    }
}

/// Timer > 20 || infinite ; Distance: Close ; Characer health: Full ; Character State: Air
public class SecondRuleRivalIsHit : RulesInterface
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
        string[] possibleAttacks = AnimationStates.GetAirAttacks();
        int randomAttack = Random.Range(0, possibleAttacks.Length - 1);
        return possibleAttacks[randomAttack];
    }
}

/// Timer > 20 || infinite ; Distance: Far ; Characer health: Full ; Character State: Ground
public class ThirdRuleRivalIsHit : RulesInterface
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

/// Timer > 20 || infinite ; Distance: Far ; Characer health: Full ; Character State: Air
public class FourthRuleRivalIsHit : RulesInterface
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
public class FifthRuleRivalIsHit : RulesInterface
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

        if (randomValue < 0.4)
        {
            string[] possibleAttacks = AnimationStates.GetGroundAttacks();
            int randomAttack = Random.Range(0, possibleAttacks.Length - 1);
            animationToPlay = possibleAttacks[randomAttack];
        }
        else if (randomValue > 0.4 && randomValue < 0.8)
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

/// Timer > 20 || infinite ; Distance: Close ; Characer health: Low ; Character State: Air
public class SixthRuleRivalIsHit : RulesInterface
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

        if (randomValue < 0.5)
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

/// Timer > 20 || infinite ; Distance: Far ; Characer health: Low ; Character State: Ground
public class SeventhRuleRivalIsHit : RulesInterface
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

        if (randomValue < 0.5)
        {
            animationToPlay = AnimationStates.WALK_BACKWARDS;
        }
        else if (randomValue > 0.5 && randomValue < 0.75)
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
public class EighthRuleRivalIsHit : RulesInterface
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

        if (randomValue < 0.9)
        {
            animationToPlay = AnimationStates.BLOCKING_JUMPING;
        }

        return animationToPlay;
    }
}

/// Timer < 20 ; Distance: Close ; Characer health: High (Rival > Own) ; Character State: Ground
public class NinthRuleRivalIsHit : RulesInterface
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
        string[] possibleAttacks = AnimationStates.GetGroundAttacks();
        int randomAttack = Random.Range(0, possibleAttacks.Length - 1);
        return possibleAttacks[randomAttack];
    }
}

/// Timer < 20 ; Distance: Close ; Characer health: High (Rival > Own) ; Character State: Air
public class TenthRuleRivalIsHit : RulesInterface
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
        string[] possibleAttacks = AnimationStates.GetAirAttacks();
        int randomAttack = Random.Range(0, possibleAttacks.Length - 1);
        return possibleAttacks[randomAttack];
    }
}

/// Timer < 20 ; Distance: Far ; Characer health: High (Rival > Own) ; Character State: Ground
public class EleventhRuleRivalIsHit : RulesInterface
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
public class TwelfthRuleRivalIsHit : RulesInterface
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
        string animationToPlay = "";
        float randomValue = Random.value;

        if (randomValue < 0.1)
        {
            animationToPlay = AnimationStates.BLOCKING_JUMPING;
        }

        return animationToPlay;
    }
}

/// Timer < 20 ; Distance: Close ; Characer health: Low (Rival < Own) ; Character State: Ground
public class ThirteenthRuleRivalIsHit : RulesInterface
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

        if (randomValue < 0.6)
        {
            animationToPlay = AnimationStates.WALK_BACKWARDS;
        }
        else if (randomValue > 0.6 && randomValue < 0.9)
        {
            string[] possibleAttacks = AnimationStates.GetGroundAttacks();
            int randomAttack = Random.Range(0, possibleAttacks.Length - 1);
            return possibleAttacks[randomAttack];
        }
        else
        {
            animationToPlay = AnimationStates.JUMPING_BACKWARDS;
        }

        return animationToPlay;
    }
}

/// Timer < 20 ; Distance: Close ; Characer health: Low (Rival < Own) ; Character State: Air
public class FourteenthRuleRivalIsHit : RulesInterface
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
            return possibleAttacks[randomAttack];
        }

        return animationToPlay;
    }
}

/// Timer < 20 ; Distance: Far ; Characer health: Low (Rival < Own) ; Character State: Ground
public class FifteenthRuleRivalIsHit : RulesInterface
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

        if (randomValue < 0.6)
        {
            animationToPlay = AnimationStates.WALK_BACKWARDS;
        }
        else if (randomValue > 0.6 && randomValue < 0.8)
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

/// Timer < 20 ; Distance: Far ; Characer health: Low (Rival < Own) ; Character State: Air
public class SixteenthRuleRivalIsHit : RulesInterface
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
        string animationToPlay = "";
        float randomValue = Random.value;

        if (randomValue < 0.9)
        {
            animationToPlay = AnimationStates.BLOCKING_JUMPING;
        }

        return animationToPlay;
    }
}
