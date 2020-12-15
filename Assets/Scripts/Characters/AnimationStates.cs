using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnimationStates {
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
	
}
