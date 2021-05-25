using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;


public class StaticAI : MonoBehaviour
{

    [SerializeField] private Timer currentTimer;
    private List<RulesInterface> rulesEngineRivalAttacks = new List<RulesInterface>();
    private List<RulesInterface> rulesEngineCharacterLowHealth = new List<RulesInterface>();
    private List<RulesInterface> rulesEngineRivalBlocks = new List<RulesInterface>();
    private List<RulesInterface> rulesEngineRivalIsHit = new List<RulesInterface>();
    private List<RulesInterface> rulesEngineRivalMovement = new List<RulesInterface>();
    private CharacterFeatures currentCharacter;
    private CharacterActions characterActions;
    private string characterAction = "Standing";
    private bool actionTaken = false;


    void AddRule(RulesInterface rule, List<RulesInterface> rulesEngine)
    {
        rulesEngine.Add(rule);
    }

    void ExecuteRules(List<RulesInterface> rulesEngine)
    {
        foreach (RulesInterface rule in rulesEngine)
        {
            if (rule.condition(AIConditionChecking.GetConditions()) && !actionTaken)
            {
                characterAction = rule.action();
                if (!currentCharacter.GetIsJumping() && (Array.IndexOf(AnimationStates.GetGroundAttacks(), characterAction) >= 0))
                {
                    characterActions.PerformAttack(characterAction);
                }
                actionTaken = true;
            }
        }
    }

    void AddRulesRivalAttacks()
    {
        AddRule(new FirstRuleRivalAttacks(), rulesEngineRivalAttacks);
    }

    // Use this for initialization
    void Start()
    {
        currentCharacter = this.GetComponent<CharacterFeatures>();
        characterActions = this.GetComponent<CharacterActions>();
        AddRulesRivalAttacks();
    }

    // Update is called once per frame
    void Update()
    {
        if (!currentCharacter.GetIsBlocked())
        {
            AIConditionChecking.CheckTimer(currentTimer.GetTimer());

            if (currentCharacter.GetAnimationStatus() == "Standing")
            {
                actionTaken = false;
                ExecuteRules(rulesEngineRivalAttacks);
            }

        }

    }
}
