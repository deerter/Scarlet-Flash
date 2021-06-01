using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Timer > 20 || infinite ; Distance: Close ; Characer health: Full ; Character State: Ground
public class FirstRuleRivalJumpingForwards : RulesInterface
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
public class SecondRuleRivalJumpingForwards : RulesInterface
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
public class ThirdRuleRivalJumpingForwards : RulesInterface
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
public class FourthRuleRivalJumpingForwards : RulesInterface
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
public class FifthRuleRivalJumpingForwards : RulesInterface
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

        if (randomValue < 0.45)
        {
            animationToPlay = AnimationStates.WALK_BACKWARDS;
        }
        else if (randomValue > 0.45 && randomValue < 0.9)
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
public class SixthRuleRivalJumpingForwards : RulesInterface
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

        if (randomValue < 0.9)
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
public class SeventhRuleRivalJumpingForwards : RulesInterface
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
        else
        {
            animationToPlay = AnimationStates.JUMPING_BACKWARDS;
        }

        return animationToPlay;
    }

}

/// Timer > 20 || infinite ; Distance: Far ; Characer health: Low ; Character State: Air
public class EighthRuleRivalJumpingForwards : RulesInterface
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
        return AnimationStates.BLOCKING_JUMPING;
    }

}

/// Timer < 20 ; Distance: Close ; Characer health: High (Rival > Own) ; Character State: Ground
public class NinthRuleRivalJumpingForwards : RulesInterface
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
public class TenthRuleRivalJumpingForwards : RulesInterface
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
public class EleventhRuleRivalJumpingForwards : RulesInterface
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
public class TwelfthRuleRivalJumpingForwards : RulesInterface
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
public class ThirteenthRuleRivalJumpingForwards : RulesInterface
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

/// Timer < 20 ; Distance: Close ; Characer health: Low (Rival < Own) ; Character State: Air
public class FourteenthRuleRivalJumpingForwards : RulesInterface
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
public class FifteenthRuleRivalJumpingForwards : RulesInterface
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
public class SixteenthRuleRivalJumpingForwards : RulesInterface
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