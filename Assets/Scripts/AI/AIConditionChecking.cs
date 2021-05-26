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
        if (timer >= 98 || timer == -1)
        {
            conditions &= ~AIConditions.timer;
        }
        else
        {
            conditions |= AIConditions.timer;
        }
    }

    public static void CheckCharacterHealth(int timer, GameObject characters, GameObject rivalCharacters)
    {

        if (timer >= 20 || timer == -1)
        {
            int full = 0;
            int low = 0;
            HealthBar characterHealthBar;
            for (int i = 0; i < characters.transform.childCount; i++)
            {
                characterHealthBar = characters.transform.GetChild(i).GetComponent<CharacterFeatures>().GetHealthBar();
                if ((characterHealthBar.getHP() / characterHealthBar.getMaxHP()) > 0.4f)
                {
                    full++;
                }
                else
                {
                    low++;
                }
            }
            if (full == 3 || (full == 2))
            {
                conditions &= ~AIConditions.characterHealth;
            }
            else
            {
                conditions |= AIConditions.characterHealth;
            }
        }
        else
        {
            int fullLifePlayer = 0;
            int fullLifeRival = 0;
            for (int i = 0; i < characters.transform.childCount; i++)
            {
                fullLifePlayer += characters.transform.GetChild(i).GetComponent<CharacterFeatures>().GetHealthBar().getHP();
            }
            for (int i = 0; i < rivalCharacters.transform.childCount; i++)
            {
                fullLifeRival += rivalCharacters.transform.GetChild(i).GetComponent<CharacterFeatures>().GetHealthBar().getHP();
            }
        }
    }

    public static void CheckDistance(CharacterActions characterActions)
    {
        string screenDistance = characterActions.GetPositionBetweenCharacters();
        if (screenDistance == "In-close" || screenDistance == "Poke-range")
        {
            conditions |= AIConditions.distance;
        }
        else
        {
            conditions &= ~AIConditions.distance;
        }
    }

    public static void CheckCharacterStates(CharacterFeatures currentCharacter)
    {
        if (currentCharacter.GetIsJumping())
        {
            conditions |= AIConditions.characterStateAir;
        }
        else
        {
            conditions &= ~AIConditions.characterStateAir;
        }
    }


}
