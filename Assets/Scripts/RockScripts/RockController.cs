using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : MonoBehaviour
{
    [SerializeField] Sprite breakImage;
    [SerializeField] GameObject RockEffect;
    int collisionCounter=0;

    GameManager gameManager;
    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Ball")
        {
            collisionCounter++;

            if (collisionCounter == 1)
            {
                GetComponent<SpriteRenderer>().sprite = breakImage;

            }
            else if (collisionCounter == 2)
            {
                Instantiate(RockEffect, transform.position, transform.rotation);
                Destroy(gameObject);
                gameManager.score = gameManager.score + 10;
            }
        }
    }
}
