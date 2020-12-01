using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Sakura : Character {

	public Sakura() : base(){
		this.name = "sakura";
		this.health = 850000;
		this.doubleJumpCount = 0;
		this.airDashCount = 0;

    	this.lightPunchDamage = 40000;
    	this.lightKickDamage = 35000;
    	this.heavyPunchDamage = 75000;
    	this.heavyKickDamage = 75000;
    	this.crouchingLightPunchDamage = 40000;
    	this.crouchingLightKickDamage = 40000;
    	this.crouchingHeavyPunchDamage = 75000;
    	this.crouchingHeavyKickDamage = 80000;
    	this.jumpingLightPunchDamage = 40000;
    	this.jumpingLightKickDamage = 40000;
    	this.jumpingHeavyPunchDamage = 80000;
    	this.jumpingHeavyKickDamage = 75000;

		attackOutput = new Dictionary<string, int> {
			{AnimationStates.LIGHT_PUNCH, this.lightPunchDamage},
			{AnimationStates.LIGHT_KICK, this.lightKickDamage},
			{AnimationStates.HEAVY_PUNCH, this.heavyPunchDamage},
			{AnimationStates.HEAVY_KICK, this.heavyKickDamage},
			{AnimationStates.CROUCHING_LIGHT_PUNCH, this.crouchingLightPunchDamage},
			{AnimationStates.CROUCHING_LIGHT_KICK, this.crouchingLightKickDamage},
			{AnimationStates.CROUCHING_HEAVY_PUNCH, this.crouchingHeavyPunchDamage},
			{AnimationStates.CROUCHING_HEAVY_KICK, this.crouchingHeavyKickDamage}
		};
	}


}
