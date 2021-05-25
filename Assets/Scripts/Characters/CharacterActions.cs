using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterActions : MonoBehaviour
{
    [SerializeField] private GameObject CharacterSoundEffectPlayer;
    private CharacterFeatures currentCharacter;
    private CharacterSoundEffect characterSoundEffect;

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


    // Use this for initialization
    void Start()
    {
        currentCharacter = this.GetComponent<CharacterFeatures>();
        characterSoundEffect = CharacterSoundEffectPlayer.GetComponent<CharacterSoundEffect>();
    }

}
