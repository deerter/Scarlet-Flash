using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character
{
    protected string name;
    protected int health;
    protected int doubleJumpCount;
    protected int airDashCount;
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

    public int GetLightPunch(){
        return this.lightPunchDamage;
    }

    public int GetLightKick(){
        return this.lightKickDamage;
    }

    public int GetHeavyPunch(){
        return this.heavyPunchDamage;
    }

    public int GetHeavyKick(){
        return this.heavyKickDamage;
    }

    



	
}
