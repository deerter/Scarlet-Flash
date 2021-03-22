using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ken : Character {

	public Ken() : base(){
		name = "ken";
		health =1000000;
		doubleJumpCount = 0;
		airDashCount = 0;
    	lightPunchDamage = 45000;
    	lightKickDamage = 35000;
    	heavyPunchDamage = 80000;
    	heavyKickDamage = 80000;
    	crouchingLightPunchDamage = 40000;
    	crouchingLightKickDamage = 40000;
    	crouchingHeavyPunchDamage = 70000;
    	crouchingHeavyKickDamage = 75000;
    	jumpingLightPunchDamage = 40000;
    	jumpingLightKickDamage = 40000;
    	jumpingHeavyPunchDamage = 80000;
    	jumpingHeavyKickDamage = 75000;

		attackOutput = new Dictionary<string, int> {
			{AnimationStates.LIGHT_PUNCH, this.lightPunchDamage},
			{AnimationStates.LIGHT_KICK, this.lightKickDamage},
			{AnimationStates.HEAVY_PUNCH, this.heavyPunchDamage},
			{AnimationStates.HEAVY_KICK, this.heavyKickDamage},
			{AnimationStates.CROUCHING_LIGHT_PUNCH, this.crouchingLightPunchDamage},
			{AnimationStates.CROUCHING_LIGHT_KICK, this.crouchingLightKickDamage},
			{AnimationStates.CROUCHING_HEAVY_PUNCH, this.crouchingHeavyPunchDamage},
			{AnimationStates.CROUCHING_HEAVY_KICK, this.crouchingHeavyKickDamage},
			{AnimationStates.JUMPING_LIGHT_PUNCH, this.jumpingLightPunchDamage},
			{AnimationStates.JUMPING_LIGHT_KICK, this.jumpingLightKickDamage},
			{AnimationStates.JUMPING_HEAVY_PUNCH, this.jumpingHeavyPunchDamage},
			{AnimationStates.JUMPING_HEAVY_KICK, this.jumpingHeavyKickDamage}
		};
	}
}
