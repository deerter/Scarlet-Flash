using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterFeatures : MonoBehaviour
{
    [SerializeField] public GameObject health;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject CharacterVoicePlayer;
    private Character character;
    private HealthBar healthBar;
    private CharacterVoice characterVoice;
    private string characterName;
    private string characterSeries;
    private bool animationPlaying = false;   //Character is currently on an animation other than standing /// Used to not enter other animations when the current one has finished and a button has been pressed during the execution.
    private string animationStatus;
    private bool isCrouching = false;
    private bool isJumping = false;
    private bool isBlocking = false;
    private bool isHit = false;
    private bool isWinner = false;
    private bool isFlipped;  /// False - Facing Right ; True - Facing Left ////
	private bool isDead = false;
    private bool isBlocked = true; /// Character can move or not ///
	private bool isAI;  /// Character is controlled by AI or not ///

    private bool victoryAlreadyStated = false;   ////////Erase this one eventually
    private bool deathAleradyStated = false;     ////////Erase this one eventually


    public Character GetCharacter()
    {
        return character;
    }

    public HealthBar GetHealthBar()
    {
        return healthBar;
    }

    public Animator GetAnimator()
    {
        return animator;
    }


    /// Play animations and Set its status ///
    public bool IsAnimationPlaying()
    {
        return animationPlaying;
    }

    public void SetAnimationPlaying(bool animationPlaying)
    {
        this.animationPlaying = animationPlaying;
    }

    public void PlayAnimation(string animation)
    {
        animator.Play(animation);
        animationPlaying = true;
    }

    public void EndAnimation(string animation)
    {
        animator.Play(animation);
        animationPlaying = false;
    }

    public void SetAnimationStatus(string animationStatus)
    {
        this.animationStatus = animationStatus;
    }

    public string GetAnimationStatus()
    {
        return animationStatus;
    }


    /// Is Crouching ///
    public bool GetIsCrouching()
    {
        return isCrouching;
    }

    public void SetIsCrouching(bool isCrouching)
    {
        this.isCrouching = isCrouching;
    }


    /// Is Jumping ///	
    public bool GetIsJumping()
    {
        return isJumping;
    }

    public void SetIsJumping(bool isJumping)
    {
        this.isJumping = isJumping;
    }


    /// Is Blocking ///
    public bool GetIsBlocking()
    {
        return isBlocking;
    }

    public void SetIsBlocking(bool isBlocking)
    {
        this.isBlocking = isBlocking;
    }


    /// Is Hit ///
    public bool GetIsHit()
    {
        return isHit;
    }

    public void HitDone()
    {
        this.isHit = true;
    }

    public void HitEnding()
    {
        this.isHit = false;
    }


    /// Is Winner ///
    public void SetIsWinner()
    {
        isWinner = true;
    }


    /// Is Flipped ///
    public bool GetIsFlipped()
    {
        return isFlipped;
    }

    public void SetIsFlipped(bool flip)
    {
        this.isFlipped = flip;
    }


    /// Check if character is dead ///
    public bool GetIsDead()
    {
        return isDead;
    }

    /// Character Dies ///
    public void CharacterIsDead()
    {
        //gameObject.GetComponent<Animator>().enabled = false;
        animator.enabled = false;
    }

    public void PlayCharacterDeadVoice()
    {
        if (!deathAleradyStated)
        {
            characterVoice.PlayCharacterVoice("KO", characterSeries, characterName);
            deathAleradyStated = true;
        }
    }


    /// Is Blocked ///
    public bool GetIsBlocked()
    {
        return isBlocked;
    }

    public void SetIsBlocked(bool isBlocked)
    {
        this.isBlocked = isBlocked;
    }


    /// Is AI ///
    public bool GetIsAI()
    {
        return isAI;
    }

    public void SetIsAI(bool isAI)
    {
        this.isAI = isAI;
    }


    /// Character Takes or Does damage ///
    public void TakeDamage(float attackValue)
    {
        healthBar.Deplete(attackValue);
    }

    public int DoDamage()
    {
        if (Array.IndexOf(AnimationStates.GetAttacks(), animationStatus) >= 0)
        {
            return character.GetAttackOutput(animationStatus);
        }
        return 0;
    }

    public void FightIntroduction()
    {
        PlayAnimation(AnimationStates.INTRO);
        characterVoice.PlayCharacterVoice("Intro", characterSeries, characterName);
    }

    /// Character celebrates victory ///
    IEnumerator VictoryDance()
    {
        yield return new WaitForSeconds(5);
        SetAnimationStatus(AnimationStates.VICTORY);
        PlayAnimation(AnimationStates.VICTORY);
        if (!victoryAlreadyStated && animator.enabled)
        {
            characterVoice.PlayCharacterVoice("Victory", characterSeries, characterName);
            victoryAlreadyStated = true;
        }
    }

    public void StopAnimation()
    {
        animator.enabled = false;
    }

    // Use this for initialization
    void Start()
    {
        characterName = CurrentFightStats.GetSelectedCharacter(transform.GetSiblingIndex(), gameObject.tag);
        //characterName = "Ken";  //For testing
        characterSeries = CharacterSelectionMapping.GetCharacterSeries(characterName);
        var type = Type.GetType(characterName);
        character = (Character)Activator.CreateInstance(type);
        healthBar = new HealthBar(health.transform.GetChild(transform.GetSiblingIndex()).gameObject, character.GetHealth(), characterName);
        animator.runtimeAnimatorController = Resources.Load("Animation/Characters/" + characterSeries + "/" + characterName + "/" + characterName) as RuntimeAnimatorController;
        SetIsAI(CurrentFightStats.GetAI(transform.tag));
        characterVoice = CharacterVoicePlayer.GetComponent<CharacterVoice>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animationStatus == "Standing")
        {
            animationPlaying = false;
        }
        if (healthBar.getHP() == 0)
        {
            //GetComponent<CharacterMovement>().enabled = false;  /////Use these commands if the rival character is not AI
            //GetComponent<CharacterCombat>().enabled = false;

            /*GetComponent<Rigidbody2D>().isKinematic = true;
			GetComponent<Rigidbody2D>().MovePosition(GetComponent<Rigidbody2D>().position);
			GetComponent<BoxCollider2D>().enabled = false;*/
            isDead = true;
            if (!GetIsJumping())
            {
                PlayAnimation(AnimationStates.KO);
            }
        }
        if (isWinner && !GetIsJumping())
        {
            StartCoroutine(VictoryDance());
        }

    }
}
