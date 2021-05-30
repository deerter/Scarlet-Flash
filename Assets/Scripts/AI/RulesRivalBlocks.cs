using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Timer > 20 || infinite ; Distance: Close ; Characer health: Full ; Character State: Ground
public class FirstRuleRivalBlocks : RulesInterface
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

        if (randomValue < 0.6)
        {
            string[] possibleAttacks = AnimationStates.GetGroundAttacks();
            int randomAttack = Random.Range(0, possibleAttacks.Length - 1);
            animationToPlay = possibleAttacks[randomAttack];
        }
        else if (randomValue > 0.6 && randomValue < 0.8)
        {
            animationToPlay = AnimationStates.WALK_BACKWARDS;
        }
        else if (randomValue > 0.8 && randomValue < 0.9)
        {
            animationToPlay = AnimationStates.JUMPING_BACKWARDS;
        }
        else
        {
            animationToPlay = AnimationStates.JUMPING_UP;
        }

        return animationToPlay;
    }
}

/// Timer > 20 || infinite ; Distance: Close ; Characer health: Full ; Character State: Air
public class SecondRuleRivalBlocks : RulesInterface
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

        if (randomValue < 0.7)
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
public class ThirdRuleRivalBlocks : RulesInterface
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
        else if (randomValue > 0.8 && randomValue < 0.9)
        {
            animationToPlay = AnimationStates.JUMPING_BACKWARDS;
        }
        else
        {
            animationToPlay = AnimationStates.WALK_BACKWARDS;
        }

        return animationToPlay;
    }
}

/// Timer > 20 || infinite ; Distance: Far ; Characer health: Full ; Character State: Air
public class FourthRuleRivalBlocks : RulesInterface
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
        string animationToPlay = "";
        float randomValue = Random.value;

        if (randomValue < 0.1)
        {
            animationToPlay = AnimationStates.BLOCKING_JUMPING;
        }

        return animationToPlay;
    }
}

/// Timer > 20 || infinite ; Distance: Close ; Characer health: Low ; Character State: Ground
public class FifthRuleRivalBlocks : RulesInterface
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

        if (randomValue < 0.6)
        {
            animationToPlay = AnimationStates.WALK_BACKWARDS;
        }
        else if (randomValue > 0.6 && randomValue < 0.9)
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
public class SixthRuleRivalBlocks : RulesInterface
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
public class SeventhRuleRivalBlocks : RulesInterface
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

        if (randomValue < 0.6)
        {
            animationToPlay = AnimationStates.WALK_BACKWARDS;
        }
        else if (randomValue > 0.6 && randomValue < 0.9)
        {
            animationToPlay = AnimationStates.JUMPING_BACKWARDS;
        }
        else if (randomValue > 0.9 && randomValue < 0.95)
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
public class EighthRuleRivalBlocks : RulesInterface
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
public class NinthRuleRivalBlocks : RulesInterface
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

        if (randomValue < 0.6)
        {
            string[] possibleAttacks = AnimationStates.GetGroundAttacks();
            int randomAttack = Random.Range(0, possibleAttacks.Length - 1);
            animationToPlay = possibleAttacks[randomAttack];
        }
        else if (randomValue > 0.6 && randomValue < 0.8)
        {
            animationToPlay = AnimationStates.WALK_BACKWARDS;
        }
        else if (randomValue > 0.8 && randomValue < 0.9)
        {
            animationToPlay = AnimationStates.JUMPING_BACKWARDS;
        }
        else
        {
            animationToPlay = AnimationStates.JUMPING_UP;
        }
        return animationToPlay;
    }
}

/// Timer < 20 ; Distance: Close ; Characer health: High (Rival > Own) ; Character State: Air
public class TenthRuleRivalBlocks : RulesInterface
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

        if (randomValue < 0.6)
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
public class EleventhRuleRivalBlocks : RulesInterface
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

        if (randomValue < 0.4)
        {
            animationToPlay = AnimationStates.WALK_FORWARDS;
        }
        else if (randomValue > 0.4 && randomValue < 0.8)
        {
            animationToPlay = AnimationStates.JUMPING_FORWARDS;
        }
        else if (randomValue > 0.8 && randomValue < 0.9)
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

/// Timer < 20 ; Distance: Far ; Characer health: High (Rival > Own) ; Character State: Air
public class TwelfthRuleRivalBlocks : RulesInterface
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
public class ThirteenthRuleRivalBlocks : RulesInterface
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
public class FourteenthRuleRivalBlocks : RulesInterface
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

/// Timer < 20 ; Distance: Far ; Characer health: Low (Rival < Own) ; Character State: Ground
public class FifteenthRuleRivalBlocks : RulesInterface
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
        else if (randomValue > 0.6 && randomValue < 0.9)
        {
            animationToPlay = AnimationStates.JUMPING_BACKWARDS;
        }
        else if (randomValue > 0.9 && randomValue < 0.95)
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
public class SixteenthRuleRivalBlocks : RulesInterface
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
