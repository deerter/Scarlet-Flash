using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterFeatures : MonoBehaviour {
	[SerializeField] public GameObject health;
	[SerializeField] private Animator animator;
	private Character character;
	private HealthBar healthBar;
	private string characterName;

	public HealthBar GetHealthBar (){
		return healthBar;
	}

	public Character GetCharacter() {
		return character;
	}

	// Use this for initialization
	void Start () {
		//characterName = CurrentFightStats.GetSelectedCharacter(transform.GetSiblingIndex(), gameObject.tag);     ESTA ES LA FORMA ADECUADA
		characterName = "Sakura";
		var type = Type.GetType(characterName);
		character = (Character)Activator.CreateInstance(type);
		healthBar = new HealthBar (health.transform.GetChild(transform.GetSiblingIndex()).gameObject, character.GetHealth());
		animator.runtimeAnimatorController = Resources.Load("Animation/Characters/" + characterName + "/" + characterName) as RuntimeAnimatorController;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
