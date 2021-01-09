using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipSprite : MonoBehaviour {

	public GameObject rivalCharacter;
	//private SpriteRenderer characterSpriteRenderer;

	// Use this for initialization
	void Start () {
		//characterSpriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(gameObject.transform.position.x < rivalCharacter.transform.position.x){
			gameObject.transform.localScale = new Vector3(Mathf.Abs(gameObject.transform.localScale.x), gameObject.transform.localScale.y, gameObject.transform.localScale.z);
			//characterSpriteRenderer.flipX = false;
        }else{
			gameObject.transform.localScale = new Vector3(- Mathf.Abs(gameObject.transform.localScale.x), gameObject.transform.localScale.y, gameObject.transform.localScale.z);
			//characterSpriteRenderer.flipX = true;
		}
		
	}
}
