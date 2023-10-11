using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;
    public bool comboCount;
    static public bool canBeAni;
    Animator m_Animator;
    static public bool canBeAni2;

    

    public BeatScroller theBS;

    public float beatTempo;

    public KeyCode keyToPress;

    public KeyCode DToPress;
    public KeyCode FToPress;

    public int Xpos = -32;
    // Start is called before the first frame update
    void Start()
    {
        canBePressed = false;
       
        m_Animator = gameObject.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            
            if (canBePressed)
            {
                m_Animator.SetBool("hit", true);

                GameManager.instance.NoteHit();

                comboCount = true;
            }    
        }

        if (BeatScroller.hasStarted)
        {
            beatTempo /= 60f;
            transform.Translate(Vector3.left * Time.deltaTime * 5.0f);
        }

        if (this.transform.position.x < Xpos)
        {
            Destroy(this.gameObject);
        }



    }

    private void OnTriggerEnter2D(Collider2D other)
    {
            if (other.tag == "Activator")
            {
                canBePressed = true;
                canBeAni = true;
            }
            if (other.tag == "Activator2")
            {
                canBePressed = true;
                canBeAni2 = true;
            }


        
        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (!comboCount)
        {
            if (other.tag == "Activator")
            {
                canBePressed = false;
                canBeAni = false;

                GameManager.instance.NoteMissed();
                
            }
            if (other.tag == "Activator2")
            {
                canBePressed = false;
                canBeAni2 = false;

                GameManager.instance.NoteMissed();
            }
        }
        else
        {
            if (other.tag == "Activator")
            {
                canBePressed = false;
                canBeAni = false;

            }
            if (other.tag == "Activator2")
            {
                canBePressed = false;
                canBeAni2 = false;

            }

        }
        
    }
}
