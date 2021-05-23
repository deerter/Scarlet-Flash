interface RulesInterface
{

    AIConditions Conditions   // property
    {
        get;  // get method
        set;  // set method
    }
    bool condition(AIConditions condition);
    void action();
}
