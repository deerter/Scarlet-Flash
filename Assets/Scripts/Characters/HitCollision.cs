using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCollision : MonoBehaviour {

	private FightManager fightManager;

	void Awake(){
		fightManager = GameObject.FindObjectOfType<FightManager>();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void HitOpponent(string playerHit,int otherPlayer, int player){
		//Check if character is blocking//
		fightManager.GetHealthBar(playerHit, otherPlayer).TakeDamage(fightManager.GetCharacter(playerHit, player).GetLightPunch());

	}

	private void OnTriggerEnter2D(Collider2D otherPlayer){
		string playerHit = otherPlayer.gameObject.tag;
		switch (playerHit){
			case "Player2": HitOpponent(playerHit, 0,0); break;
			case "Player1": HitOpponent(playerHit, 0,0); break;
		}
	}
}
