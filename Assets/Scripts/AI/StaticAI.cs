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
    private List<RulesInterface> rulesEngineCharacterLowHealth = new List<RulesInterface>();
    private List<RulesInterface> rulesEngineRivalBlocks = new List<RulesInterface>();
    private List<RulesInterface> rulesEngineRivalIsHit = new List<RulesInterface>();
    private List<RulesInterface> rulesEngineRivalMovement = new List<RulesInterface>();
    private CharacterFeatures currentCharacter;
    private CharacterActions characterActions;
    private Rigidbody2D rigidBody;
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
            characterActions.Walk(rigidBody, animator);
        }
    }

    private void AddRulesRivalAttacks()
    {
        AddRule(new FirstRuleRivalAttacks(), rulesEngineRivalAttacks);
    }

    // Use this for initialization
    void Start()
    {
        currentCharacter = this.GetComponent<CharacterFeatures>();
        characterActions = this.GetComponent<CharacterActions>();
        animator = currentCharacter.GetAnimator();
        rigidBody = this.GetComponent<Rigidbody2D>();
        AddRulesRivalAttacks();
    }

    // Update is called once per frame
    void Update()
    {
        if ((currentCharacter.IsAnimationPlaying() && !currentCharacter.GetIsJumping() && !currentCharacter.GetIsHit())
                || currentCharacter.GetAnimationStatus() == AnimationStates.STANDING)
        { //In case the animation goes from walking to other animation, prevents from sliding behaviour
            rigidBody.velocity = new Vector2(0, 0);
        }

        if (!currentCharacter.GetIsBlocked())
        {
            AIConditionChecking.CheckTimer(currentTimer.GetTimer());
            AIConditionChecking.CheckCharacterStates(currentCharacter);
            AIConditionChecking.CheckDistance(characterActions);
            AIConditionChecking.CheckCharacterHealth(currentTimer.GetTimer(), characters, rivalCharacters);

            if ((currentCharacter.GetAnimationStatus() == AnimationStates.WALK_BACKWARDS || currentCharacter.GetAnimationStatus() == AnimationStates.WALK_FORWARDS)
                && rigidBody.velocity.x == 0 && actionTaken == true)
            {
                print("movement");
                currentCharacter.EndAnimation("Standing");
            }

            if (currentCharacter.GetAnimationStatus() == "Standing")
            {
                actionTaken = false;
                ExecuteRules(rulesEngineRivalAttacks);
            }


        }

    }
}
