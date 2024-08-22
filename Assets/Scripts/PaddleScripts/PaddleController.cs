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
        float horizontal = Input.GetAxis("Horizontal"); //klavyenin sað ve sol ok tuþlarýna basýnca +1 -1 arasý bir deðer çevirir.
        transform.Translate(Vector2.right * horizontal * Time.deltaTime * speed); //üzerine yazdýðýmýz paddleýn transformu yani konumunu translate yani taþý ancak sýnýr koyulmalý yoksa sahne dýþýna çýkar

        ////Kenar sýnýrlarýný belirleme
        //    //paddleýn x pos sýnýrlardan küçük veya büyükse sýnýrlarda kalsýn y si de zaten y eks hareket etm için ayný kalsýn
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
