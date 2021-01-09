using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCollision : MonoBehaviour {

	private CharacterFeatures rivalCharacter;
	private CharacterFeatures currentCharacter;

	private void hitOpponent(Collider2D otherPlayer, string rival){
		if (otherPlayer.tag == rival){
			rivalCharacter = otherPlayer.gameObject.GetComponent<CharacterFeatures>();
			int attackValue = currentCharacter.DoDamage();
			rivalCharacter.TakeDamage(attackValue);
		}
	}

	void Awake(){
		currentCharacter = gameObject.GetComponentInParent<CharacterFeatures>();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D otherPlayer){
		switch(currentCharacter.tag){
			case "Player1":
				hitOpponent(otherPlayer, "Player2");
				break;
			case "Player2":
				hitOpponent(otherPlayer, "Player1");
				break;
		}
	}
}
