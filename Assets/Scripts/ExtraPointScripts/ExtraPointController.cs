using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ExtraPointController : MonoBehaviour
{
    float speedStar;

    

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speedStar*Time.deltaTime); //yýldýzýn kaymasýný saðladýk
    }
}
