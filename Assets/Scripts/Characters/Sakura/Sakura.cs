using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	}
}
