using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Timer > 20 || infinite ; Distance: Close ; Characer health: Full ; Character State: Ground
public class FirstRuleRivalBackwards : RulesInterface
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

        if (randomValue < 0.7)
        {
            string[] possibleAttacks = AnimationStates.GetGroundAttacks();
            int randomAttack = Random.Range(0, possibleAttacks.Length - 1);
            animationToPlay = possibleAttacks[randomAttack];
        }
        else if (randomValue > 0.7 && randomValue < 0.9)
        {
            animationToPlay = AnimationStates.WALK_FORWARDS;
        }
        else
        {
            animationToPlay = AnimationStates.WALK_BACKWARDS;
        }

        return animationToPlay;
    }
}

/// Timer > 20 || infinite ; Distance: Close ; Characer health: Full ; Character State: Air
public class SecondRuleRivalBackwards : RulesInterface
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
public class ThirdRuleRivalBackwards : RulesInterface
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
public class FourthRuleRivalBackwards : RulesInterface
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
public class FifthRuleRivalBackwards : RulesInterface
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
public class SixthRuleRivalBackwards : RulesInterface
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
        return AnimationStates.BLOCKING_JUMPING;
    }
}

/// Timer > 20 || infinite ; Distance: Far ; Characer health: Low ; Character State: Ground
public class SeventhRuleRivalBackwards : RulesInterface
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
            animationToPlay = AnimationStates.JUMPING_FORWARDS;
        }
        else
        {
            animationToPlay = AnimationStates.WALK_FORWARDS;
        }

        return animationToPlay;
    }
}

/// Timer > 20 || infinite ; Distance: Far ; Characer health: Low ; Character State: Air
public class EighthRuleRivalBackwards : RulesInterface
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
public class NinthRuleRivalBackwards : RulesInterface
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
            animationToPlay = AnimationStates.WALK_FORWARDS;
        }

        return animationToPlay;
    }
}

/// Timer < 20 ; Distance: Close ; Characer health: High (Rival > Own) ; Character State: Air
public class TenthRuleRivalBackwards : RulesInterface
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
public class EleventhRuleRivalBackwards : RulesInterface
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

        if (randomValue < 0.6)
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
public class TwelfthRuleRivalBackwards : RulesInterface
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
public class ThirteenthRuleRivalBackwards : RulesInterface
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

/// Timer < 20 ; Distance: Close ; Characer health: Low (Rival < Own) ; Character State: Air
public class FourteenthRuleRivalBackwards : RulesInterface
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
public class FifteenthRuleRivalBackwards : RulesInterface
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

        if (randomValue < 0.8)
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
public class SixteenthRuleRivalBackwards : RulesInterface
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
