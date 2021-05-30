using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnimationStates
{
    public const string STANDING = "Standing";
    public const string WALK_FORWARDS = "WalkForwards";
    public const string WALK_BACKWARDS = "WalkBackwards";
    public const string LIGHT_PUNCH = "LightPunch";
    public const string LIGHT_KICK = "LightKick";
    public const string HEAVY_PUNCH = "HeavyPunch";
    public const string HEAVY_KICK = "HeavyKick";
    public const string CROUCHING = "Crouching"; //State in which the character stays crouched
    public const string CROUCH = "Crouch";   //State in which the character is crouching
    public const string CROUCHING_LIGHT_PUNCH = "CrouchingLightPunch";
    public const string CROUCHING_LIGHT_KICK = "CrouchingLightKick";
    public const string CROUCHING_HEAVY_PUNCH = "CrouchingHeavyPunch";
    public const string CROUCHING_HEAVY_KICK = "CrouchingHeavyKick";
    public const string JUMPING_UP = "JumpingUp";
    public const string JUMPING_DOWN = "JumpingDown";
    public const string JUMPING_FORWARDS = "JumpingForwards";
    public const string JUMPING_BACKWARDS = "JumpingBackwards";
    public const string JUMPING_LIGHT_PUNCH = "JumpingLightPunch";
    public const string JUMPING_LIGHT_KICK = "JumpingLightKick";
    public const string JUMPING_HEAVY_PUNCH = "JumpingHeavyPunch";
    public const string JUMPING_HEAVY_KICK = "JumpingHeavyKick";
    public const string LANDING = "Landing";
    public const string TAKING_DAMAGE = "TakingDamage";
    public const string TAKING_DAMAGE_CROUCHING = "TakingDamageCrouching";
    public const string TAKING_DAMAGE_JUMPING = "TakingDamageJumping";
    public const string BLOCKING_STANDING = "BlockingStanding";
    public const string BLOCKING_CROUCHING = "BlockingCrouching";
    public const string BLOCKING_JUMPING = "BlockingJumping";
    public const string KO = "KO";
    public const string VICTORY = "Victory";
    public const string INTRO = "Intro";


    public static string[] GetGroundAttacks()
    {
        return new string[] { LIGHT_PUNCH, LIGHT_KICK, HEAVY_PUNCH, HEAVY_KICK, CROUCHING_LIGHT_PUNCH, CROUCHING_LIGHT_KICK, CROUCHING_HEAVY_PUNCH, CROUCHING_HEAVY_KICK };
    }

    public static string[] GetAirAttacks()
    {
        return new string[] { JUMPING_LIGHT_PUNCH, JUMPING_LIGHT_KICK, JUMPING_HEAVY_PUNCH, JUMPING_HEAVY_KICK };
    }

    public static string[] GetAttacks()
    {
        return new string[] {LIGHT_PUNCH, LIGHT_KICK, HEAVY_PUNCH, HEAVY_KICK, CROUCHING_LIGHT_PUNCH,
                            CROUCHING_LIGHT_KICK, CROUCHING_HEAVY_PUNCH, CROUCHING_HEAVY_KICK, JUMPING_LIGHT_PUNCH,
                            JUMPING_LIGHT_KICK, JUMPING_HEAVY_PUNCH, JUMPING_HEAVY_KICK };
    }

    public static string[] GetIdleMovements()
    {
        return new string[] { STANDING, WALK_BACKWARDS, WALK_FORWARDS, JUMPING_BACKWARDS, JUMPING_DOWN, JUMPING_FORWARDS, JUMPING_UP, CROUCHING };
    }

    public static string[] GetTakingDamageStates()
    {
        return new string[] { TAKING_DAMAGE, TAKING_DAMAGE_CROUCHING, TAKING_DAMAGE_JUMPING };
    }

    public static string[] GetBlockingStates()
    {
        return new string[] { BLOCKING_CROUCHING, BLOCKING_JUMPING, BLOCKING_STANDING };
    }

}
