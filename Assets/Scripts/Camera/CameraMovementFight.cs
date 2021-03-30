using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementFight : MonoBehaviour {

	public Transform player1;
	public EdgeCollider2D ground;
	public EdgeCollider2D wallRight;
	public EdgeCollider2D wallLeft;
	public EdgeCollider2D ceiling;
	float offsetX = 34.5f;
	float offsetY = 19.2f;
	private float xMin, xMax, yMin, yMax;
	private float camY, camX;
	private float camOrthSize;
	private float cameraRatio;
	private Camera mainCam;
	private Transform followTransform;

	private void Start(){
		xMin = wallLeft.bounds.min.x;
		xMax = wallRight.bounds.max.x;
		yMin = ground.bounds.min.y;
		yMax = ceiling.bounds.max.y;
		mainCam = GetComponent<Camera>();
		camOrthSize = mainCam.orthographicSize;
		cameraRatio = (xMax + camOrthSize) / 2.0f - 6;   /////Needs an offset to hit the correct boundaries of X.
	}

	void FixedUpdate(){
		followTransform = player1.GetChild(0).gameObject.transform;
		camY = Mathf.Clamp(followTransform.position.y - offsetY, yMin + camOrthSize - 7, yMax - camOrthSize);
		camX = Mathf.Clamp(followTransform.position.x + offsetX, xMin + cameraRatio, xMax - cameraRatio);
		this.transform.position = new Vector3(camX, camY, this.transform.position.z);
	}
}
