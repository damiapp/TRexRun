using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Sprite[] spritePool;

    void Start()
    {
        // Choose a random sprite from the pool
        int randomIndex = Random.Range(0, spritePool.Length);
        Sprite randomSprite = spritePool[randomIndex];

        // Set the sprite on the Sprite Renderer component
        GetComponent<SpriteRenderer>().sprite = randomSprite;

        // Get the size of the sprite and adjust the box collider accordingly
        Vector2 spriteSize = randomSprite.bounds.size;
        GetComponent<BoxCollider2D>().size = spriteSize;
    }
}
