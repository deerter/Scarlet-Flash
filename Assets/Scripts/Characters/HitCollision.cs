using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCollision : MonoBehaviour {

	private CharacterFeatures rivalCharacter;
	private CharacterFeatures currentCharacter;

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
		rivalCharacter = otherPlayer.gameObject.GetComponent<CharacterFeatures>();
		int attackValue = currentCharacter.DoDamage();
		rivalCharacter.TakeDamage(attackValue);
	}
}
