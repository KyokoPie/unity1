using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class haatoAttAni : MonoBehaviour
{
    private Animator animator;//(1)
    public KeyCode keyToPress;
    public KeyCode keyToPress2;
    public KeyCode keyToPressSpace;
    static int Att1 = Animator.StringToHash("Base Layer.haatoAtta1");
    static int Att2 = Animator.StringToHash("Base Layer.haatoAtta2");

    static public bool SpaceAnime;

    static public bool canBeAniSP;

    static public bool EndAni;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo stateinfo = animator.GetCurrentAnimatorStateInfo(0);
        if (stateinfo.IsName("Base Layer.dash"))
        {
            if (Input.GetKeyDown(keyToPress))
            {
                animator.SetTrigger("att1");
                animator.ResetTrigger("att2");
            }
        }
        if (stateinfo.IsName("Base Layer.dash"))
        {
            if (Input.GetKeyDown(keyToPress2))
            {
                animator.SetTrigger("att2");
                animator.ResetTrigger("att1");
            }
        }

        AnimatorStateInfo animatorInfo;
        animatorInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (SpaceAnime)
        {
            animator.SetTrigger("attSP");
            if ((animatorInfo.normalizedTime > 1.0f) && (animatorInfo.IsName("haatoAttaSpecial")))
            {

                Debug.Log("SPend");
                BeatScroller.hasStarted = true;
                SpaceAnime = false;
                DeskNote.DestonHit = true;
                animator.ResetTrigger("attSP");

            }

        }

        if (EndAni)
        {
            animator.SetTrigger("end");
            if ((animatorInfo.normalizedTime > 0.4f) && (animatorInfo.IsName("haatoEnd")))
            {

                EndAni = false;
                Debug.Log("EndAni");
                GameManager.CanBeEnd = true;
                animator.ResetTrigger("end");

            }
        }
    }
}
