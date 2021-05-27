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

    /// Moves the character forwards or backwards
    public void Walk(Rigidbody2D rigidBody, Animator animator)
    {
        if ((currentCharacter.GetAnimationStatus() == AnimationStates.STANDING) ||
            (currentCharacter.GetAnimationStatus() == AnimationStates.WALK_FORWARDS) ||
                (currentCharacter.GetAnimationStatus() == AnimationStates.WALK_BACKWARDS))
        {
            switch (currentCharacter.GetIsFlipped())
            {
                case true: animator.SetFloat("Horizontal", -Input.GetAxis("Horizontal")); break;
                case false: animator.SetFloat("Horizontal", Input.GetAxis("Horizontal")); break;
            }
            Vector2 horizontal = new Vector2(Input.GetAxis("Horizontal"), 0.0f);
            rigidBody.velocity = horizontal * 3500f * Time.fixedDeltaTime;
            //rigidBody.MovePosition(rigidBody.position + horizontal * Time.fixedDeltaTime * 70f);   ///Uses MovePosition because both transform and rb.position makes the character phase through when pushing the rival on the edge of the screen.
            //Uses Time.fixedDeltaTime instead of Time.deltaTime because MovePosition works with physics (as does fixedDeltaTime)
        }
    }

    public void Block()
    {
        if ((currentCharacter.GetAnimationStatus() == AnimationStates.WALK_BACKWARDS)
            || ((currentCharacter.GetIsCrouching() || currentCharacter.GetIsJumping()) && !currentCharacter.IsAnimationPlaying()))
        {
            currentCharacter.SetIsBlocking(true);
        }
    }

    public void StopBlocking()
    {
        currentCharacter.SetIsBlocking(false);
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
