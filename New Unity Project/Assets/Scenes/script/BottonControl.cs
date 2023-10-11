using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottonControl : MonoBehaviour
{
    private SpriteRenderer theSR;
    public Sprite defaultImage;
    public Sprite pressedImage;

    public KeyCode keyTopress;
    // Start is called before the first frame update
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyTopress))
        {
            theSR.sprite = pressedImage;
        }

        if (Input.GetKeyUp(keyTopress))
        {
            theSR.sprite = defaultImage;

        }
        
    }
}
