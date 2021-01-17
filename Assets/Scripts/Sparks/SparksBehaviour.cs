using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparksBehaviour : MonoBehaviour{

	public void ActivateHitSparks(Vector2 center){
		gameObject.SetActive(true);
		float offsetx = 5.5f;
		gameObject.transform.position = new Vector2(center.x + offsetx, center.y);
	}

	public void StopHitSparks(){
		gameObject.SetActive(false);
	}

}
