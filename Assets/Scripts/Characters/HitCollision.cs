using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D otherPlayer){
		if (otherPlayer.gameObject.CompareTag("Player2")){
			print("Golpeo golpeo");
			//quitar vida al jugador contrario
		}
	}
}
