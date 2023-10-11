using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskMove : MonoBehaviour
{

    public float beatTempo;
    // Start is called before the first frame update
    void Start()
    {
        void Start()
        {

        }
    }

    // Update is called once per frame
    void Update()
    {

        if (DestScroller.DeskStart)
        {

            beatTempo /= 60f;
            transform.Translate(Vector3.left * Time.deltaTime * 10.0f);
        }
    }
}
