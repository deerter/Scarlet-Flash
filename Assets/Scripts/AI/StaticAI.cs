using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StaticAI : MonoBehaviour
{


    private List<RulesInterface> rulesEngineRivalAttacks = new List<RulesInterface>();
    private CharacterFeatures currentCharacter;
    private AIConditions conditions;


    void AddRule(RulesInterface rule, List<RulesInterface> rulesEngine)
    {
        rulesEngine.Add(rule);
    }

    void ExecuteRules(List<RulesInterface> rulesEngine)
    {
        foreach (RulesInterface rule in rulesEngine)
        {
            rule.Conditions = conditions;
            /*if (rule.condition(conditions))
            {
                rule.action();
            }*/
        }
    }

    void CheckIfChange()
    {
        /// tiene mas vida
        conditions |= AIConditions.canChange;

        /// tiene menos vida
    }

    void AddRulesRivalAttacks()
    {
        AddRule(new FirstRuleRivalAttacks(), rulesEngineRivalAttacks);
    }

    // Use this for initialization
    void Start()
    {
        currentCharacter = this.GetComponent<CharacterFeatures>();
        AddRulesRivalAttacks();


    }

    // Update is called once per frame
    void Update()
    {
        if (!currentCharacter.GetIsBlocked())
        {
            ExecuteRules(rulesEngineRivalAttacks);

        }

    }
}
