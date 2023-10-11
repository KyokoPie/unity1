using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPeffect : MonoBehaviour
{
    public GameObject Fire;
    private Animator animator;//(1)
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (DeskNote.canBeAniSP)
        {
            Instantiate(Fire, transform.position, transform.rotation);
            //animator.SetTrigger("hit");
            DeskNote.canBeAniSP = false;
        }
    }
}
