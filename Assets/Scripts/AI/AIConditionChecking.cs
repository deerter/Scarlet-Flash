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

    public static void CheckTimer(float timer)
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

    public static void CheckCharacterHealth(float timer, GameObject characters, GameObject rivalCharacters)
    {

        if (timer >= 20 || timer == -1)
        {
            int full = 0;
            int low = 0;
            HealthBar characterHealthBar;
            for (int i = 0; i < characters.transform.childCount; i++)
            {
                characterHealthBar = characters.transform.GetChild(i).GetComponent<CharacterFeatures>().GetHealthBar();
                if (((float)characterHealthBar.getHP() / characterHealthBar.getMaxHP()) > 0.2f)
                {
                    full++;
                }
                else
                {
                    low++;
                }
            }
            if (full == 3 || full == 2 || full == 1) /// Character health is high
            {
                conditions &= ~AIConditions.characterHealth;
            }
            else                          /// Character health is low
            {
                conditions |= AIConditions.characterHealth;
            }
        }
        else
        {
            float fullLifePlayer = 0;
            float fullLifeRival = 0;
            for (int i = 0; i < characters.transform.childCount; i++)
            {
                fullLifePlayer += characters.transform.GetChild(i).GetComponent<CharacterFeatures>().GetHealthBar().getHP();
            }
            for (int i = 0; i < rivalCharacters.transform.childCount; i++)
            {
                fullLifeRival += rivalCharacters.transform.GetChild(i).GetComponent<CharacterFeatures>().GetHealthBar().getHP();
            }
            if (fullLifePlayer >= fullLifeRival) /// Character health is higher than rival's
            {
                conditions |= AIConditions.characterHealth;
            }
            else                                 /// Caharacter health is lower than rival's
            {
                conditions &= ~AIConditions.characterHealth;
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

    public static void CheckCharacterSwap(CharacterAssist assist, CharacterFeatures currentCharacter, GameObject characters)
    {
        if (!assist.GetSwapped())
        {
            float lifePercentage = (float)currentCharacter.GetHealthBar().getHP() / currentCharacter.GetHealthBar().getMaxHP();
            float pointCharacterHealth = currentCharacter.GetHealthBar().getHP();
            float secondCharacterHealth = characters.transform.GetChild(1).GetComponent<CharacterFeatures>().GetHealthBar().getHP();
            float thirdCharacterHealth = characters.transform.GetChild(2).GetComponent<CharacterFeatures>().GetHealthBar().getHP();
            if (lifePercentage < 0.4)
            {
                if (pointCharacterHealth > secondCharacterHealth)
                {
                    if (pointCharacterHealth > thirdCharacterHealth)
                    {
                        ////Leave point character
                        conditions &= ~AIConditions.changeSecondCharacter;
                        conditions &= ~AIConditions.changeThirdCharacter;
                        conditions |= AIConditions.leavePointCharacter;
                    }
                    else
                    {
                        ///Change to third character
                        conditions &= ~AIConditions.leavePointCharacter;
                        conditions &= ~AIConditions.changeSecondCharacter;
                        conditions |= AIConditions.changeThirdCharacter;
                    }
                }
                else
                {
                    if (secondCharacterHealth >= thirdCharacterHealth)
                    {
                        ///Change to second character
                        conditions &= ~AIConditions.leavePointCharacter;
                        conditions &= ~AIConditions.changeThirdCharacter;
                        conditions |= AIConditions.changeSecondCharacter;
                    }
                    else
                    {
                        /// Change to third character
                        conditions &= ~AIConditions.leavePointCharacter;
                        conditions &= ~AIConditions.changeSecondCharacter;
                        conditions |= AIConditions.changeThirdCharacter;
                    }
                }
            }
            else
            {
                /// leave point character
                conditions &= ~AIConditions.changeSecondCharacter;
                conditions &= ~AIConditions.changeThirdCharacter;
                conditions |= AIConditions.leavePointCharacter;
            }
        }
        else
        {
            //// Reset all conditions
            conditions &= ~AIConditions.leavePointCharacter;
            conditions &= ~AIConditions.changeSecondCharacter;
            conditions &= ~AIConditions.changeThirdCharacter;
        }
    }


}
