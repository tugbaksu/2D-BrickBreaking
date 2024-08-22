using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour
{
    [SerializeField] GameObject BrickEffect;
    GameManager gameManager;

    [SerializeField] GameObject extraPointPrefab;

    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Instantiate(BrickEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            gameManager.score = gameManager.score + 5;

            int chance = Random.Range(1, 101);
            if (chance > 60)
            {
                Instantiate(extraPointPrefab, transform.position, transform.rotation);
            }
        }
    }

    
}
