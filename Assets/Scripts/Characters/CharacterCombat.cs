using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCombat : MonoBehaviour
{

    [SerializeField] private GameObject CharacterSoundEffectPlayer;
    private CharacterFeatures currentCharacter;
    private CharacterSoundEffect characterSoundEffect;
    private CharacterActions characterActions;

    // Use this for initialization
    void Start()
    {
        currentCharacter = this.GetComponent<CharacterFeatures>();
        characterActions = this.GetComponent<CharacterActions>();
        characterSoundEffect = CharacterSoundEffectPlayer.GetComponent<CharacterSoundEffect>();
    }


    // Update is called once per frame
    void Update()
    {
        if (!currentCharacter.GetIsBlocked())
        {
            ///Standing Attacks
            if (Input.GetKeyDown(GameConstants.LP) && !currentCharacter.IsAnimationPlaying() && !currentCharacter.GetIsCrouching() && !currentCharacter.GetIsJumping())
            {
                characterActions.PerformAttack(AnimationStates.LIGHT_PUNCH);
            }

            if (Input.GetKeyDown(GameConstants.LK) && !currentCharacter.IsAnimationPlaying() && !currentCharacter.GetIsCrouching() && !currentCharacter.GetIsJumping())
            {
                characterActions.PerformAttack(AnimationStates.LIGHT_KICK);
            }

            if (Input.GetKeyDown(GameConstants.HP) && !currentCharacter.IsAnimationPlaying() && !currentCharacter.GetIsCrouching() && !currentCharacter.GetIsJumping())
            {
                characterActions.PerformAttack(AnimationStates.HEAVY_PUNCH);
            }

            if (Input.GetKeyDown(GameConstants.HK) && !currentCharacter.IsAnimationPlaying() && !currentCharacter.GetIsCrouching() && !currentCharacter.GetIsJumping())
            {
                characterActions.PerformAttack(AnimationStates.HEAVY_KICK);
            }

            /////Crouching Attacks
            if (Input.GetKeyDown(GameConstants.LP) && currentCharacter.GetIsCrouching() && !currentCharacter.IsAnimationPlaying())
            {
                characterActions.PerformAttack(AnimationStates.CROUCHING_LIGHT_PUNCH);
            }

            if (Input.GetKeyDown(GameConstants.LK) && currentCharacter.GetIsCrouching() && !currentCharacter.IsAnimationPlaying())
            {
                characterActions.PerformAttack(AnimationStates.CROUCHING_LIGHT_KICK);
            }

            if (Input.GetKeyDown(GameConstants.HP) && currentCharacter.GetIsCrouching() && !currentCharacter.IsAnimationPlaying())
            {
                characterActions.PerformAttack(AnimationStates.CROUCHING_HEAVY_PUNCH);
            }

            if (Input.GetKeyDown(GameConstants.HK) && currentCharacter.GetIsCrouching() && !currentCharacter.IsAnimationPlaying())
            {
                characterActions.PerformAttack(AnimationStates.CROUCHING_HEAVY_KICK);
            }

            //////Jumping Attacks
            if (Input.GetKeyDown(GameConstants.LP) && currentCharacter.GetIsJumping() && !currentCharacter.IsAnimationPlaying())
            {
                characterActions.PerformAttack(AnimationStates.JUMPING_LIGHT_PUNCH);
            }

            if (Input.GetKeyDown(GameConstants.LK) && currentCharacter.GetIsJumping() && !currentCharacter.IsAnimationPlaying())
            {
                characterActions.PerformAttack(AnimationStates.JUMPING_LIGHT_KICK);
            }

            if (Input.GetKeyDown(GameConstants.HP) && currentCharacter.GetIsJumping() && !currentCharacter.IsAnimationPlaying())
            {
                characterActions.PerformAttack(AnimationStates.JUMPING_HEAVY_PUNCH);
            }

            if (Input.GetKeyDown(GameConstants.HK) && currentCharacter.GetIsJumping() && !currentCharacter.IsAnimationPlaying())
            {
                characterActions.PerformAttack(AnimationStates.JUMPING_HEAVY_KICK);
            }
        }

    }
}
