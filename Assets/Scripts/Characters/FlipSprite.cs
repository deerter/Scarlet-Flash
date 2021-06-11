using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipSprite : MonoBehaviour
{

    [SerializeField] private GameObject rivalCharacters;
    private BoxCollider2D rivalBoxCollider;
    private float characterSideChecking;
    private float rivalCharacterSideChecking;

    private void CheckFirstFlip()
    {
        if (gameObject.GetComponent<BoxCollider2D>().bounds.center.x < rivalBoxCollider.bounds.center.x)
        {
            gameObject.transform.localScale = new Vector3(Mathf.Abs(gameObject.transform.localScale.x), gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            gameObject.GetComponent<CharacterFeatures>().SetIsFlipped(false);
            characterSideChecking = gameObject.GetComponent<BoxCollider2D>().bounds.center.x - gameObject.GetComponent<BoxCollider2D>().bounds.extents.x;
        }
        else
        {
            gameObject.transform.localScale = new Vector3(-Mathf.Abs(gameObject.transform.localScale.x), gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            gameObject.GetComponent<CharacterFeatures>().SetIsFlipped(true);
            characterSideChecking = gameObject.GetComponent<BoxCollider2D>().bounds.center.x + gameObject.GetComponent<BoxCollider2D>().bounds.extents.x;
        }
    }

    private float GetSideChecking()
    {
        return characterSideChecking;
    }

    private void CheckFlip()
    {
        rivalCharacterSideChecking = rivalCharacters.transform.GetChild(0).GetComponent<FlipSprite>().GetSideChecking();
        if (characterSideChecking < rivalCharacterSideChecking)
        {
            gameObject.transform.localScale = new Vector3(Mathf.Abs(gameObject.transform.localScale.x), gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            gameObject.GetComponent<CharacterFeatures>().SetIsFlipped(false);
            characterSideChecking = gameObject.GetComponent<BoxCollider2D>().bounds.center.x - gameObject.GetComponent<BoxCollider2D>().bounds.extents.x;
        }
        else
        {
            gameObject.transform.localScale = new Vector3(-Mathf.Abs(gameObject.transform.localScale.x), gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            gameObject.GetComponent<CharacterFeatures>().SetIsFlipped(true);
            characterSideChecking = gameObject.GetComponent<BoxCollider2D>().bounds.center.x + gameObject.GetComponent<BoxCollider2D>().bounds.extents.x;
        }
    }

    // Use this for initialization
    void Start()
    {
        rivalBoxCollider = rivalCharacters.transform.GetChild(0).GetComponent<BoxCollider2D>();
        CheckFirstFlip();
    }

    // Update is called once per frame
    void Update()
    {
        rivalBoxCollider = rivalCharacters.transform.GetChild(0).GetComponent<BoxCollider2D>();
        CheckFlip();

    }
}
