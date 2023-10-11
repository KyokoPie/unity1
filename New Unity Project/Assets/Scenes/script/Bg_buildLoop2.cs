using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bg_buildLoop2 : MonoBehaviour
{
    //Move Speed;  
    public float mSpeed = 10.0F;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Translate form right to left  
        transform.Translate(Vector3.left * Time.deltaTime * mSpeed);
        // If first background is out of camera view,then show sencond background  
        if (transform.position.x <= -45.2F)
        {
            //We can chenge this value to reduce the wdith between 2 background  
            transform.position = new Vector3(44.68F, transform.position.y, transform.position.z);
        }
    }
}
