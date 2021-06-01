using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;


public class StaticAI : MonoBehaviour
{

    [SerializeField] private Timer currentTimer;
    [SerializeField] private GameObject characters;
    [SerializeField] private GameObject rivalCharacters;
    private List<RulesInterface> rulesEngineRivalAttacks = new List<RulesInterface>();
    private List<RulesInterface> rulesEngineSwapCharacter = new List<RulesInterface>();
    private List<RulesInterface> rulesEngineRivalBlocks = new List<RulesInterface>();
    private List<RulesInterface> rulesEngineRivalIsHit = new List<RulesInterface>();
    private List<RulesInterface> rulesEngineRivalIdle = new List<RulesInterface>();
    private List<RulesInterface> rulesEngineRivalJumpingForwards = new List<RulesInterface>();
    private List<RulesInterface> rulesEngineRivalJumpingBackwards = new List<RulesInterface>();
    private List<RulesInterface> rulesEngineRivalForwards = new List<RulesInterface>();
    private List<RulesInterface> rulesEngineRivalBackwards = new List<RulesInterface>();
    private CharacterFeatures currentCharacter;
    private CharacterFeatures rivalCharacter;
    private CharacterActions characterActions;
    private CharacterAssist characterAssist;
    private Rigidbody2D rigidBody;
    private BoxCollider2D boxCollider;
    private Animator animator;
    private string characterAction = "Standing";
    private bool actionTaken = false;


    private void AddRule(RulesInterface rule, List<RulesInterface> rulesEngine)
    {
        rulesEngine.Add(rule);
    }

    private void ExecuteRules(List<RulesInterface> rulesEngine)
    {
        foreach (RulesInterface rule in rulesEngine)
        {
            if (rule.condition(AIConditionChecking.GetConditions()) && !actionTaken)
            {
                characterAction = rule.action();
                ExecuteAction();
                actionTaken = true;
            }
        }
    }

    private void ExecuteAction()
    {
        if ((Array.IndexOf(AnimationStates.GetAttacks(), characterAction) >= 0))
        {
            characterActions.PerformAttack(characterAction);
        }
        else if (characterAction == AnimationStates.WALK_BACKWARDS)
        {
            characterActions.Block();
            characterActions.Walk(rigidBody, animator, AnimationStates.WALK_BACKWARDS);
        }
        else if (characterAction == AnimationStates.WALK_FORWARDS)
        {
            characterActions.Walk(rigidBody, animator, AnimationStates.WALK_FORWARDS);
        }
        else if (characterAction == AnimationStates.STANDING)
        {
            animator.SetFloat("Horizontal", 0);
            currentCharacter.EndAnimation(AnimationStates.STANDING);
        }
        else if (characterAction == AnimationStates.JUMPING_BACKWARDS)
        {
            switch (currentCharacter.GetIsFlipped())
            {
                case true: characterActions.Jump(rigidBody, "JumpingRight"); break;
                case false: characterActions.Jump(rigidBody, "JumpingLeft"); break;
            }
        }
        else if (characterAction == AnimationStates.JUMPING_FORWARDS)
        {
            switch (currentCharacter.GetIsFlipped())
            {
                case true: characterActions.Jump(rigidBody, "JumpingLeft"); break;
                case false: characterActions.Jump(rigidBody, "JumpingRight"); break;
            }
        }
        else if (characterAction == AnimationStates.JUMPING_UP)
        {
            characterActions.Jump(rigidBody, "JumpingUp");
        }
        else if (characterAction == AnimationStates.BLOCKING_JUMPING || characterAction == AnimationStates.BLOCKING_CROUCHING)
        {
            characterActions.Block();
            characterActions.Invoke("StopBlocking", 3);   //// Stops blocking after 2 seconds
        }


        ///// Swap characters
        if (characterAction == "SwapCharacter2")
        {
            print("how do you do");
            characterAssist.Swap("Assist1", false);
        }
        else if (characterAction == "SwapCharacter3")
        {
            print("On my own");
            characterAssist.Swap("Assist2", false);
        }
    }

    private void AddRulesRivalAttacks()
    {
        AddRule(new FirstRuleRivalAttacks(), rulesEngineRivalAttacks); AddRule(new SecondRuleRivalAttacks(), rulesEngineRivalAttacks);
        AddRule(new ThirdRuleRivalAttacks(), rulesEngineRivalAttacks); AddRule(new FourthRuleRivalAttacks(), rulesEngineRivalAttacks);
        AddRule(new FifthRuleRivalAttacks(), rulesEngineRivalAttacks); AddRule(new SixthRuleRivalAttacks(), rulesEngineRivalAttacks);
        AddRule(new SeventhRuleRivalAttacks(), rulesEngineRivalAttacks); AddRule(new EighthRuleRivalAttacks(), rulesEngineRivalAttacks);
        AddRule(new NinthRuleRivalAttacks(), rulesEngineRivalAttacks); AddRule(new TenthRuleRivalAttacks(), rulesEngineRivalAttacks);
        AddRule(new EleventhRuleRivalAttacks(), rulesEngineRivalAttacks); AddRule(new TwelfthRuleRivalAttacks(), rulesEngineRivalAttacks);
        AddRule(new ThirteenthRuleRivalAttacks(), rulesEngineRivalAttacks); AddRule(new FourteenthRuleRivalAttacks(), rulesEngineRivalAttacks);
        AddRule(new FifteenthRuleRivalAttacks(), rulesEngineRivalAttacks); AddRule(new SixteenthRuleRivalAttacks(), rulesEngineRivalAttacks);
    }

    private void AddRulesRivalIsHit()
    {
        AddRule(new FirstRuleRivalIsHit(), rulesEngineRivalIsHit); AddRule(new SecondRuleRivalIsHit(), rulesEngineRivalIsHit);
        AddRule(new ThirdRuleRivalIsHit(), rulesEngineRivalIsHit); AddRule(new FourthRuleRivalIsHit(), rulesEngineRivalIsHit);
        AddRule(new FifthRuleRivalIsHit(), rulesEngineRivalIsHit); AddRule(new SixthRuleRivalIsHit(), rulesEngineRivalIsHit);
        AddRule(new SeventhRuleRivalIsHit(), rulesEngineRivalIsHit); AddRule(new EighthRuleRivalIsHit(), rulesEngineRivalIsHit);
        AddRule(new NinthRuleRivalIsHit(), rulesEngineRivalIsHit); AddRule(new TenthRuleRivalIsHit(), rulesEngineRivalIsHit);
        AddRule(new EleventhRuleRivalIsHit(), rulesEngineRivalIsHit); AddRule(new TwelfthRuleRivalIsHit(), rulesEngineRivalIsHit);
        AddRule(new ThirteenthRuleRivalIsHit(), rulesEngineRivalIsHit); AddRule(new FourteenthRuleRivalIsHit(), rulesEngineRivalIsHit);
        AddRule(new FifteenthRuleRivalIsHit(), rulesEngineRivalIsHit); AddRule(new SixteenthRuleRivalIsHit(), rulesEngineRivalIsHit);
    }

    private void AddRulesRivalIsBlock()
    {
        AddRule(new FirstRuleRivalBlocks(), rulesEngineRivalBlocks); AddRule(new SecondRuleRivalBlocks(), rulesEngineRivalBlocks);
        AddRule(new ThirdRuleRivalBlocks(), rulesEngineRivalBlocks); AddRule(new FourthRuleRivalBlocks(), rulesEngineRivalBlocks);
        AddRule(new FifthRuleRivalBlocks(), rulesEngineRivalBlocks); AddRule(new SixthRuleRivalBlocks(), rulesEngineRivalBlocks);
        AddRule(new SeventhRuleRivalBlocks(), rulesEngineRivalBlocks); AddRule(new EighthRuleRivalBlocks(), rulesEngineRivalBlocks);
        AddRule(new NinthRuleRivalBlocks(), rulesEngineRivalBlocks); AddRule(new TenthRuleRivalBlocks(), rulesEngineRivalBlocks);
        AddRule(new EleventhRuleRivalBlocks(), rulesEngineRivalBlocks); AddRule(new TwelfthRuleRivalBlocks(), rulesEngineRivalBlocks);
        AddRule(new ThirteenthRuleRivalBlocks(), rulesEngineRivalBlocks); AddRule(new FourteenthRuleRivalBlocks(), rulesEngineRivalBlocks);
        AddRule(new FifteenthRuleRivalBlocks(), rulesEngineRivalBlocks); AddRule(new SixteenthRuleRivalBlocks(), rulesEngineRivalBlocks);
    }

    private void AddRulesRivalBackwards()
    {
        AddRule(new FirstRuleRivalBackwards(), rulesEngineRivalBackwards); AddRule(new SecondRuleRivalBackwards(), rulesEngineRivalBackwards);
        AddRule(new ThirdRuleRivalBackwards(), rulesEngineRivalBackwards); AddRule(new FourthRuleRivalBackwards(), rulesEngineRivalBackwards);
        AddRule(new FifthRuleRivalBackwards(), rulesEngineRivalBackwards); AddRule(new SixthRuleRivalBackwards(), rulesEngineRivalBackwards);
        AddRule(new SeventhRuleRivalBackwards(), rulesEngineRivalBackwards); AddRule(new EighthRuleRivalBackwards(), rulesEngineRivalBackwards);
        AddRule(new NinthRuleRivalBackwards(), rulesEngineRivalBackwards); AddRule(new TenthRuleRivalBackwards(), rulesEngineRivalBackwards);
        AddRule(new EleventhRuleRivalBackwards(), rulesEngineRivalBackwards); AddRule(new TwelfthRuleRivalBackwards(), rulesEngineRivalBackwards);
        AddRule(new ThirteenthRuleRivalBackwards(), rulesEngineRivalBackwards); AddRule(new FourteenthRuleRivalBackwards(), rulesEngineRivalBackwards);
        AddRule(new FifteenthRuleRivalBackwards(), rulesEngineRivalBackwards); AddRule(new SixteenthRuleRivalBackwards(), rulesEngineRivalBackwards);
    }

    private void AddRulesRivalJumpingBackwards()
    {
        AddRule(new FirstRuleRivalJumpingBackwards(), rulesEngineRivalJumpingBackwards); AddRule(new SecondRuleRivalJumpingBackwards(), rulesEngineRivalJumpingBackwards);
        AddRule(new ThirdRuleRivalJumpingBackwards(), rulesEngineRivalJumpingBackwards); AddRule(new FourthRuleRivalJumpingBackwards(), rulesEngineRivalJumpingBackwards);
        AddRule(new FifthRuleRivalJumpingBackwards(), rulesEngineRivalJumpingBackwards); AddRule(new SixthRuleRivalJumpingBackwards(), rulesEngineRivalJumpingBackwards);
        AddRule(new SeventhRuleRivalJumpingBackwards(), rulesEngineRivalJumpingBackwards); AddRule(new EighthRuleRivalJumpingBackwards(), rulesEngineRivalJumpingBackwards);
        AddRule(new NinthRuleRivalJumpingBackwards(), rulesEngineRivalJumpingBackwards); AddRule(new TenthRuleRivalJumpingBackwards(), rulesEngineRivalJumpingBackwards);
        AddRule(new EleventhRuleRivalJumpingBackwards(), rulesEngineRivalJumpingBackwards); AddRule(new TwelfthRuleRivalJumpingBackwards(), rulesEngineRivalJumpingBackwards);
        AddRule(new ThirteenthRuleRivalJumpingBackwards(), rulesEngineRivalJumpingBackwards); AddRule(new FourteenthRuleRivalJumpingBackwards(), rulesEngineRivalJumpingBackwards);
        AddRule(new FifteenthRuleRivalJumpingBackwards(), rulesEngineRivalJumpingBackwards); AddRule(new SixteenthRuleRivalJumpingBackwards(), rulesEngineRivalJumpingBackwards);
    }

    private void AddRulesRivalForwards()
    {
        AddRule(new FirstRuleRivalForwards(), rulesEngineRivalForwards); AddRule(new SecondRuleRivalForwards(), rulesEngineRivalForwards);
        AddRule(new ThirdRuleRivalForwards(), rulesEngineRivalForwards); AddRule(new FourthRuleRivalForwards(), rulesEngineRivalForwards);
        AddRule(new FifthRuleRivalForwards(), rulesEngineRivalForwards); AddRule(new SixthRuleRivalForwards(), rulesEngineRivalForwards);
        AddRule(new SeventhRuleRivalForwards(), rulesEngineRivalForwards); AddRule(new EighthRuleRivalForwards(), rulesEngineRivalForwards);
        AddRule(new NinthRuleRivalForwards(), rulesEngineRivalForwards); AddRule(new TenthRuleRivalForwards(), rulesEngineRivalForwards);
        AddRule(new EleventhRuleRivalForwards(), rulesEngineRivalForwards); AddRule(new TwelfthRuleRivalForwards(), rulesEngineRivalForwards);
        AddRule(new ThirteenthRuleRivalForwards(), rulesEngineRivalForwards); AddRule(new FourteenthRuleRivalForwards(), rulesEngineRivalForwards);
        AddRule(new FifteenthRuleRivalForwards(), rulesEngineRivalForwards); AddRule(new SixteenthRuleRivalForwards(), rulesEngineRivalForwards);
    }

    private void AddRulesRivalJumpingForwards()
    {
        AddRule(new FirstRuleRivalJumpingForwards(), rulesEngineRivalJumpingForwards); AddRule(new SecondRuleRivalJumpingForwards(), rulesEngineRivalJumpingForwards);
        AddRule(new ThirdRuleRivalJumpingForwards(), rulesEngineRivalJumpingForwards); AddRule(new FourthRuleRivalJumpingForwards(), rulesEngineRivalJumpingForwards);
        AddRule(new FifthRuleRivalJumpingForwards(), rulesEngineRivalJumpingForwards); AddRule(new SixthRuleRivalJumpingForwards(), rulesEngineRivalJumpingForwards);
        AddRule(new SeventhRuleRivalJumpingForwards(), rulesEngineRivalJumpingForwards); AddRule(new EighthRuleRivalJumpingForwards(), rulesEngineRivalJumpingForwards);
        AddRule(new NinthRuleRivalJumpingForwards(), rulesEngineRivalJumpingForwards); AddRule(new TenthRuleRivalJumpingForwards(), rulesEngineRivalJumpingForwards);
        AddRule(new EleventhRuleRivalJumpingForwards(), rulesEngineRivalJumpingForwards); AddRule(new TwelfthRuleRivalJumpingForwards(), rulesEngineRivalJumpingForwards);
        AddRule(new ThirteenthRuleRivalJumpingForwards(), rulesEngineRivalJumpingForwards); AddRule(new FourteenthRuleRivalJumpingForwards(), rulesEngineRivalJumpingForwards);
        AddRule(new FifteenthRuleRivalJumpingForwards(), rulesEngineRivalJumpingForwards); AddRule(new SixteenthRuleRivalJumpingForwards(), rulesEngineRivalJumpingForwards);
    }

    private void AddRulesRivalIdle()
    {
        AddRule(new FirstRuleRivalIdle(), rulesEngineRivalIdle); AddRule(new SecondRuleRivalIdle(), rulesEngineRivalIdle);
        AddRule(new ThirdRuleRivalIdle(), rulesEngineRivalIdle); AddRule(new FourthRuleRivalIdle(), rulesEngineRivalIdle);
        AddRule(new FifthRuleRivalIdle(), rulesEngineRivalIdle); AddRule(new SixthRuleRivalIdle(), rulesEngineRivalIdle);
        AddRule(new SeventhRuleRivalIdle(), rulesEngineRivalIdle); AddRule(new EighthRuleRivalIdle(), rulesEngineRivalIdle);
        AddRule(new NinthRuleRivalIdle(), rulesEngineRivalIdle); AddRule(new TenthRuleRivalIdle(), rulesEngineRivalIdle);
        AddRule(new EleventhRuleRivalIdle(), rulesEngineRivalIdle); AddRule(new TwelfthRuleRivalIdle(), rulesEngineRivalIdle);
        AddRule(new ThirteenthRuleRivalIdle(), rulesEngineRivalIdle); AddRule(new FourteenthRuleRivalIdle(), rulesEngineRivalIdle);
        AddRule(new FifteenthRuleRivalIdle(), rulesEngineRivalIdle); AddRule(new SixteenthRuleRivalIdle(), rulesEngineRivalIdle);
    }

    private void AddRulesSwapCharacter()
    {
        AddRule(new FirstRuleSwapCharacter(), rulesEngineSwapCharacter); AddRule(new SecondRuleSwapCharacter(), rulesEngineSwapCharacter);
        AddRule(new ThirdRuleSwapCharacter(), rulesEngineSwapCharacter);
    }

    // Use this for initialization
    void Start()
    {
        currentCharacter = this.GetComponent<CharacterFeatures>();
        rivalCharacter = rivalCharacters.transform.GetChild(0).GetComponent<CharacterFeatures>();
        characterActions = this.GetComponent<CharacterActions>();
        characterAssist = characters.GetComponent<CharacterAssist>();
        animator = currentCharacter.GetAnimator();
        rigidBody = this.GetComponent<Rigidbody2D>();
        boxCollider = this.GetComponent<BoxCollider2D>();

        AddRulesRivalAttacks();
        AddRulesRivalIsHit();
        AddRulesRivalIsBlock();
        AddRulesRivalBackwards();
        AddRulesRivalJumpingBackwards();
        AddRulesRivalForwards();
        AddRulesRivalJumpingForwards();
        AddRulesRivalIdle();
        AddRulesSwapCharacter();

    }

    // Update is called once per frame
    void Update()
    {

        if ((currentCharacter.IsAnimationPlaying() && !currentCharacter.GetIsJumping() && !currentCharacter.GetIsHit())
                || currentCharacter.GetAnimationStatus() == AnimationStates.STANDING)
        { //In case the animation goes from walking to other animation, prevents from sliding behaviour
            rigidBody.velocity = new Vector2(0, 0);
        }
        rivalCharacter = rivalCharacters.transform.GetChild(0).GetComponent<CharacterFeatures>(); //Has to be done constantly in case it changes

        if (!currentCharacter.GetIsBlocked() && !currentCharacter.GetIsDead())
        {
            AIConditionChecking.CheckTimer(currentTimer.GetTimer());
            AIConditionChecking.CheckCharacterStates(currentCharacter);
            AIConditionChecking.CheckDistance(characterActions);
            AIConditionChecking.CheckCharacterHealth(currentTimer.GetTimer(), characters, rivalCharacters);
            AIConditionChecking.CheckCharacterSwap(characterAssist, currentCharacter, characters);



            if (currentCharacter.GetAnimationStatus() != AnimationStates.WALK_BACKWARDS || characterAction != AnimationStates.BLOCKING_JUMPING
                || characterAction != AnimationStates.BLOCKING_CROUCHING)
            {
                characterActions.StopBlocking();
            }

            if (Array.IndexOf(AnimationStates.GetIdleMovements(), currentCharacter.GetAnimationStatus()) >= 0)
            {
                actionTaken = false;
                ExecuteRules(rulesEngineSwapCharacter);
                if (Array.IndexOf(AnimationStates.GetAttacks(), rivalCharacter.GetAnimationStatus()) >= 0)
                {
                    ExecuteRules(rulesEngineRivalAttacks);
                }
                if (Array.IndexOf(AnimationStates.GetTakingDamageStates(), rivalCharacter.GetAnimationStatus()) >= 0)
                {
                    ExecuteRules(rulesEngineRivalIsHit);
                }
                if (Array.IndexOf(AnimationStates.GetBlockingStates(), rivalCharacter.GetAnimationStatus()) >= 0)
                {
                    ExecuteRules(rulesEngineRivalBlocks);
                }
                if (rivalCharacter.GetAnimationStatus() == AnimationStates.WALK_BACKWARDS)
                {
                    ExecuteRules(rulesEngineRivalBackwards);
                }
                if (rivalCharacter.GetAnimationStatus() == AnimationStates.WALK_FORWARDS)
                {
                    ExecuteRules(rulesEngineRivalForwards);
                }
                if (rivalCharacter.GetAnimationStatus() == AnimationStates.JUMPING_BACKWARDS)
                {
                    ExecuteRules(rulesEngineRivalJumpingBackwards);
                }
                if (rivalCharacter.GetAnimationStatus() == AnimationStates.JUMPING_FORWARDS)
                {
                    ExecuteRules(rulesEngineRivalJumpingForwards);
                }
                if (rivalCharacter.GetAnimationStatus() == AnimationStates.STANDING || rivalCharacter.GetAnimationStatus() == AnimationStates.CROUCHING
                    || rivalCharacter.GetAnimationStatus() == AnimationStates.JUMPING_DOWN || rivalCharacter.GetAnimationStatus() == AnimationStates.JUMPING_UP
                    || rivalCharacter.GetAnimationStatus() == AnimationStates.CROUCH)
                {
                    ExecuteRules(rulesEngineRivalIdle);
                }
            }
        }

    }
}
