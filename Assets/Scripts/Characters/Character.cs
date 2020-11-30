using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Character
{
    protected string name;
    protected int health;
    protected int doubleJumpCount;
    protected int airDashCount;
    protected Dictionary<string, int> attackOutput;
    protected int lightPunchDamage;
    protected int lightKickDamage;
    protected int heavyPunchDamage;
    protected int heavyKickDamage;
    protected int crouchingLightPunchDamage;
    protected int crouchingLightKickDamage;
    protected int crouchingHeavyPunchDamage;
    protected int crouchingHeavyKickDamage;
    protected int jumpingLightPunchDamage;
    protected int jumpingLightKickDamage;
    protected int jumpingHeavyPunchDamage;
    protected int jumpingHeavyKickDamage;

    public Character(){
	}

	/////Gets
	public string GetName(){
		return this.name;
	}

    public int GetHealth(){
        return this.health;
    }

    public int GetAttackOutput(string currentAnimation){
        return attackOutput[currentAnimation];
    }

}
