using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEff : MonoBehaviour
{
    public GameObject Fire;
    private Animator animator;//(1)
    public KeyCode keyToPress;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (NoteObject.canBeAni)
            {
                Instantiate(Fire, transform.position, transform.rotation);
                //animator.SetTrigger("hit");
            }

        }
    }
}
