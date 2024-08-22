using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    float speed = 5f;

    [SerializeField]
    bool inPlay;

    [SerializeField]
    Transform ballStartPos;

    GameManager gameManager;

    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = Object.FindObjectOfType<GameManager>();

    }


    void Update()
    {
        if (!inPlay)
        {
            transform.position = ballStartPos.position;
        }


        if (Input.GetButtonDown("Jump"))
        {
            inPlay = true;
            rb.AddForce(Vector2.up * speed);
        }
    }


    public void OnTriggerEnter2D(Collider2D collision) //trigger enter kulland�k ��nk� bottom boundry nesnesinin IsTrigger �zelli�i a��k dolay�s�yla ball nesnesi onun i�inden ge�er.
    {
        if (collision.CompareTag("Ground"))
        {
            rb.velocity = Vector2.zero;
            inPlay = false;

            gameManager.live -=1;
            if (gameManager.live <= 0) 
            {
                gameManager.live = 0;
                gameManager.GameOver();
            }

        }
    }



}
