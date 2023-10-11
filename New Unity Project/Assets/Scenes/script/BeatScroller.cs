using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    public float beatTempo;
    public static bool hasStarted;
    private float ftime;
    private float BornTime;

    public GameObject Bird;

    public GameObject PinkBird;
    // Start is called before the first frame update
    void Start()
    {
        beatTempo = beatTempo / 60f;
    }


    // Update is called once per frame
    void Update()
    {
        if(!hasStarted)
        {
            if(Input.anyKey)
            {
            }
        }
        else
        {
            transform.position -= new Vector3(beatTempo * Time.deltaTime, 0f, 0f);

            ftime += Time.deltaTime;
            if (ftime >= 0.5f)
            {
                BornTime = Random.Range(0, 2);
                if (BornTime == 1)
                {
                    Instantiate(Bird, new Vector3(8.44f, 5.11f, 0f),Bird.transform.rotation);
                }

                if(BornTime == 0)
                {
                    Instantiate(PinkBird, new Vector3(8.44f, 5.11f, 0f), Bird.transform.rotation);
                }
                ftime = 0f;
            }

        }



    }
    
}
