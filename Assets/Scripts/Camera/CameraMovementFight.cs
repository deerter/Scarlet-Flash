using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementFight : MonoBehaviour
{

    public Transform player1;
    public Transform player2;
    public EdgeCollider2D ground;
    public EdgeCollider2D wallRight;
    public EdgeCollider2D wallLeft;
    public EdgeCollider2D ceiling;
    float offsetX = 34.5f;  //34.5f
    float offsetY = 19.2f;  //19.2f
    float offsetMaxBounds;
    private float xMin, xMax, yMin, yMax;
    private float camY, camX;
    private float camOrthSize;
    private float cameraRatio;
    private Camera mainCam;
    private Transform followTransformP1;
    private Transform followTransformP2;
    private BoxCollider2D boxColliderP1;
    private BoxCollider2D boxColliderP2;

    private Vector3 middle;

    private void Start()
    {
        xMin = wallLeft.bounds.min.x;
        xMax = wallRight.bounds.max.x;
        yMin = ground.bounds.min.y;
        yMax = ceiling.bounds.max.y;
        mainCam = GetComponent<Camera>();
        camOrthSize = mainCam.orthographicSize;
        cameraRatio = (xMax + camOrthSize) / 2.0f - 6;   /////Needs an offset to hit the correct boundaries of X.
    }

    private void SetCameraPosition()
    {
        float camYMovement = Mathf.Max(followTransformP1.position.y, followTransformP2.position.y);
        camY = Mathf.Clamp(camYMovement - offsetY, yMin + camOrthSize - 7, yMax - camOrthSize);
        switch (followTransformP1.GetComponent<CharacterFeatures>().GetIsFlipped())
        {
            case true: camX = Mathf.Clamp(followTransformP1.position.x - offsetX, xMin + cameraRatio, xMax - cameraRatio); break;
            case false: camX = Mathf.Clamp(followTransformP1.position.x + offsetX, xMin + cameraRatio, xMax - cameraRatio); break;
        }

        mainCam.transform.position = new Vector3(
            camX,
            camY,
            mainCam.transform.position.z
        );
    }

    private void SetCameraSize()
    {
        float minSizeY = camY;
        float minSizeX = camX;
        float width = Mathf.Abs(followTransformP1.position.x + followTransformP2.position.x) * 0.5f + offsetX;
        float camSizeX = Mathf.Max(width, minSizeX);
        cameraRatio = camSizeX * Screen.height / Screen.width;
        mainCam.orthographicSize = Mathf.Max(
             camSizeX * Screen.height / Screen.width, minSizeY);
    }

    void FixedUpdate()
    {
        followTransformP1 = player1.GetChild(0).gameObject.transform;
        followTransformP2 = player2.GetChild(0).gameObject.transform;
        boxColliderP1 = player1.GetChild(0).transform.GetComponent<BoxCollider2D>();
        boxColliderP2 = player2.GetChild(0).transform.GetComponent<BoxCollider2D>();

        //camY = Mathf.Clamp(followTransformP1.position.y - offsetY, yMin + camOrthSize - 7, yMax - camOrthSize);
        //camX = Mathf.Clamp(followTransformP1.position.x + offsetX, xMin + cameraRatio, xMax - cameraRatio);

        //this.transform.position = new Vector3(camX, camY, this.transform.position.z);

        /*
                camY = Mathf.Clamp(((followTransformP1.position.y + followTransformP2.position.y) * 0.5f) - offsetY, yMin + camOrthSize - 7, yMax - camOrthSize);
                camX = Mathf.Clamp((followTransformP1.position.x + followTransformP2.position.x) * 0.5f + offsetX, xMin + cameraRatio, xMax - cameraRatio);

                this.transform.position = new Vector3(camX, camY, this.transform.position.z);*/
        SetCameraPosition();
        //SetCameraSize();
    }
}
