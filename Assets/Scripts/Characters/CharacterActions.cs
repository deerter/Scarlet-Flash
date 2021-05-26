using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterActions : MonoBehaviour
{
    [SerializeField] private GameObject characterSoundEffectPlayer;
    [SerializeField] private GameObject rivalCharacters;
    private CharacterFeatures currentCharacter;
    private CharacterSoundEffect characterSoundEffect;
    private GameObject rivalCharacter;



    //// Plays the animation of the given attack and its sound effect
    public void PerformAttack(string attack)
    {
        characterSoundEffect.PlayCharacterSoundEffect("Attack");
        currentCharacter.PlayAnimation(attack);
        currentCharacter.SetAnimationStatus(attack);
    }

    //// Checks if character is still crouching after performing a crouching attack so that it doesn't go to Crouching by default
    public void IsCharacterStillCrouching()
    {
        if (currentCharacter.GetIsCrouching())
        {
            currentCharacter.EndAnimation(AnimationStates.CROUCHING);
        }
        else
        {
            currentCharacter.EndAnimation(AnimationStates.STANDING);
        }
    }

    ////Get the screen distance between the two characters//////
    public string GetPositionBetweenCharacters()
    {
        if (Mathf.Abs(this.transform.position.x - rivalCharacter.transform.position.x) > ScreenDistances.IN_CLOSE
            && Mathf.Abs(this.transform.position.x - rivalCharacter.transform.position.x) < ScreenDistances.POKE_RANGE)
        {
            return "In-close";
        }
        else if (Mathf.Abs(this.transform.position.x - rivalCharacter.transform.position.x) > ScreenDistances.POKE_RANGE
            && Mathf.Abs(this.transform.position.x - rivalCharacter.transform.position.x) < ScreenDistances.MID_SCREEN)
        {
            return "Poke-range";
        }
        else if (Mathf.Abs(this.transform.position.x - rivalCharacter.transform.position.x) > ScreenDistances.MID_SCREEN
            && Mathf.Abs(this.transform.position.x - rivalCharacter.transform.position.x) < ScreenDistances.FULL_SCREEN)
        {
            return "Mid-screen";
        }
        else
        {
            return "Full-screen";
        }
    }


    // Use this for initialization
    void Start()
    {
        currentCharacter = this.GetComponent<CharacterFeatures>();
        rivalCharacter = rivalCharacters.transform.GetChild(0).gameObject;
        characterSoundEffect = characterSoundEffectPlayer.GetComponent<CharacterSoundEffect>();
    }

}
