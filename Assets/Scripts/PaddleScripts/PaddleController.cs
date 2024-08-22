using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float leftBorder, rightBorder;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
    }


    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); //klavyenin sa� ve sol ok tu�lar�na bas�nca +1 -1 aras� bir de�er �evirir.
        transform.Translate(Vector2.right * horizontal * Time.deltaTime * speed); //�zerine yazd���m�z paddle�n transformu yani konumunu translate yani ta�� ancak s�n�r koyulmal� yoksa sahne d���na ��kar

        ////Kenar s�n�rlar�n� belirleme
        //    //paddle�n x pos s�n�rlardan k���k veya b�y�kse s�n�rlarda kals�n y si de zaten y eks hareket etm i�in ayn� kals�n
        //if(transform.position.x < leftBorder)
        //{
        //    transform.position= new Vector2(leftBorder,transform.position.y);
        //}
        //else if (transform.position.x > rightBorder)
        //{
        //    transform.position = new Vector2(rightBorder, transform.position.y);
        //}

        //Kenar belirleme Clamp fonk ile
        Vector2 temp=transform.position;
        temp.x=Mathf.Clamp(temp.x, leftBorder, rightBorder);
        transform.position=temp;

    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.gameObject.tag == "ExtraPoint")
        {
            gameManager.live += 1;
            Destroy(other.gameObject);
        }
    }
}
