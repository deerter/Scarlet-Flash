using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehaviour : MonoBehaviour
{

    public void ActivateBlockSprite(BoxCollider2D boxCollider, bool isFlipped)
    {
        gameObject.SetActive(true);
        if (isFlipped)
        {
            gameObject.transform.position = new Vector2(boxCollider.bounds.center.x - boxCollider.bounds.extents.x, boxCollider.bounds.center.y);
        }
        else
        {
            gameObject.transform.position = new Vector2(boxCollider.bounds.center.x + boxCollider.bounds.extents.x, boxCollider.bounds.center.y);
        }

    }

    public void StopBlockSprite()
    {
        gameObject.SetActive(false);
    }

}
