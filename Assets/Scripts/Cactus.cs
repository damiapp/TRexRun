using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Cactus : MonoBehaviour
{
    public Sprite[] cactuses;

    void Start()
    {
        SpawnRandomCactus();
    }

    public void SpawnRandomCactus()
    {
        int randomIndex = Random.Range(0, cactuses.Length);
        Sprite randomSprite = cactuses[randomIndex];

        GetComponent<SpriteRenderer>().sprite = randomSprite;

        Vector2 spriteSize = randomSprite.bounds.size;
        GetComponent<BoxCollider2D>().size = spriteSize;
    }
}
