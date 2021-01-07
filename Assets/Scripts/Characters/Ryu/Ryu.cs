using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ryu : Character{
	public Ryu() : base(){
		name = "ryu";
		this.health = 1000000;
		this.doubleJumpCount = 0;
		this.airDashCount = 0;

		this.lightPunchDamage = 50000;
		this.lightKickDamage = 45000;
		this.heavyPunchDamage = 95000;
		this.heavyKickDamage = 90000;
		this.crouchingLightPunchDamage = 50000;
		this.crouchingLightKickDamage = 45000;
		this.crouchingHeavyPunchDamage = 95000;
		this.crouchingHeavyKickDamage = 95000;
		this.jumpingLightPunchDamage = 45000;
		this.jumpingLightKickDamage = 45000;
		this.jumpingHeavyPunchDamage = 90000;
		this.jumpingHeavyKickDamage = 85000;

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
