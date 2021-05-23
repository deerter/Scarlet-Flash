using System;

[Flags]
public enum AIConditions
{
    None = 0,
    characterStates = 1,
    timer = 2,
    canChange = 3
}