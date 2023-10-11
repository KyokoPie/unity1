using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestScroller : MonoBehaviour
{
    static public bool DeskStart;
    static public bool DeskBoun;
    public float beatTempo;
    public GameObject Desk;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DeskBoun)
        {
            Instantiate(Desk, new Vector3(1.12f, -3f, 0f), Desk.transform.rotation);
            DeskBoun = false;
        }

    }
}
