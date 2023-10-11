using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskNote : MonoBehaviour
{



    public float beatTempo;
    public bool canBePressed;
    public bool comboCount;
    public KeyCode keyToPress;

    static public bool DestonHit;

    static public bool canBeAniSP ;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        canBePressed = false;
        animator = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {

            if (canBePressed)
            {

                
                GameManager.instance.NoteHitBonus();
                comboCount = true;
                DestScroller.DeskStart = false;
                GameManager.DeskBoun = false;
                haatoAttAni.SpaceAnime = true;
                animator.SetTrigger("Onhit");
                canBePressed = false;

                canBeAniSP = true;

            }
        }
        AnimatorStateInfo animatorInfo;
        animatorInfo = animator.GetCurrentAnimatorStateInfo(0);



    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = true;
        }




    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (!comboCount)
        {
            if (other.tag == "Activator")
            {
                canBePressed = false;

                GameManager.instance.NoteMissed();

                BeatScroller.hasStarted = true;

                GameManager.DeskBoun = false;

            }
            
        }
        else
        {
            if (other.tag == "Activator")
            {
                canBePressed = false;

            }

        }

    }
}
