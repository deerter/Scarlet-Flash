using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipSprite : MonoBehaviour
{

    [SerializeField] private GameObject rivalCharacters;
    private BoxCollider2D rivalBoxCollider;
    private SpriteRenderer characterSpriteRenderer;


    // Use this for initialization
    void Start()
    {
        characterSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rivalBoxCollider = rivalCharacters.transform.GetChild(0).GetComponent<BoxCollider2D>();
        if (gameObject.GetComponent<BoxCollider2D>().bounds.center.x < rivalBoxCollider.bounds.center.x)
        {
            gameObject.transform.localScale = new Vector3(Mathf.Abs(gameObject.transform.localScale.x), gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            //characterSpriteRenderer.flipX = true;
            gameObject.GetComponent<CharacterFeatures>().SetIsFlipped(false);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(-Mathf.Abs(gameObject.transform.localScale.x), gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            //characterSpriteRenderer.flipX = false;
            gameObject.GetComponent<CharacterFeatures>().SetIsFlipped(true);
        }

    }
}
