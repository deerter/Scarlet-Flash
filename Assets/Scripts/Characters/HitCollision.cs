using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCollision : MonoBehaviour
{

    public GameObject hitSparks;
    public GameObject blockSprite;
    private CharacterFeatures rivalCharacter;
    private CharacterFeatures currentCharacter;
    [SerializeField] private GameObject RivalSoundEffectPlayer;
    private CharacterSoundEffect rivalSoundEffect;

    private void PlayHitAnimation()
    {
        string animationToPlay;
        animationToPlay =
                    rivalCharacter.GetIsJumping() ? AnimationStates.TAKING_DAMAGE_JUMPING :
                    rivalCharacter.GetIsCrouching() ? AnimationStates.TAKING_DAMAGE_CROUCHING :
                    AnimationStates.TAKING_DAMAGE;
        rivalCharacter.SetAnimationStatus(animationToPlay);
        rivalCharacter.PlayAnimation(animationToPlay);
    }

    private void PlayBlockAnimation()
    {
        string animationToPlay;
        animationToPlay =
                    rivalCharacter.GetIsJumping() ? AnimationStates.BLOCKING_JUMPING :
                    rivalCharacter.GetIsCrouching() ? AnimationStates.BLOCKING_CROUCHING :
                    AnimationStates.BLOCKING_STANDING;
        rivalCharacter.SetAnimationStatus(animationToPlay);
        rivalCharacter.PlayAnimation(animationToPlay);
    }

    private void HitOpponent(Collider2D otherPlayer, string rival)
    {
        if (otherPlayer.tag == rival)
        {
            rivalCharacter = otherPlayer.gameObject.GetComponent<CharacterFeatures>();
            float attackValue = currentCharacter.DoDamage() * CurrentFightStats.GetDamage();
            ///Moves hit character
            rivalCharacter.HitDone();
            switch (currentCharacter.GetIsFlipped())
            {
                case true:
                    otherPlayer.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.left * 40f;
                    break;
                case false:
                    otherPlayer.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.right * 40f;
                    break;
            }

            if (rivalCharacter.GetIsBlocking())
            {
                rivalSoundEffect.PlayCharacterSoundEffect("Block");
                rivalCharacter.TakeDamage(attackValue / 4);
                PlayBlockAnimation();
                blockSprite.GetComponent<BlockBehaviour>().ActivateBlockSprite(otherPlayer.gameObject.GetComponent<BoxCollider2D>(), rivalCharacter.GetIsFlipped());
            }
            else
            {
                rivalSoundEffect.PlayCharacterSoundEffect("Hit");
                rivalCharacter.TakeDamage(attackValue);
                PlayHitAnimation();
                hitSparks.GetComponent<SparksBehaviour>().ActivateHitSparks(gameObject.GetComponent<BoxCollider2D>().bounds.center);
            }
        }
    }

    void Awake()
    {
        currentCharacter = gameObject.GetComponentInParent<CharacterFeatures>();
    }

    // Use this for initialization
    void Start()
    {
        rivalSoundEffect = RivalSoundEffectPlayer.GetComponent<CharacterSoundEffect>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D otherPlayer)
    {
        switch (currentCharacter.tag)
        {
            case "Player1":
                HitOpponent(otherPlayer, "Player2");
                break;
            case "Player2":
                HitOpponent(otherPlayer, "Player1");
                break;
        }
    }
}
