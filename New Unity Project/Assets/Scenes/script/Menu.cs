using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject Panel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void startbt()
    {
        SceneManager.LoadScene("SampleScene");
        //startVo.PlayOneShot(Startvoice);
    }
    public void exit()
    {

        Debug.Log("exit");
        Application.Quit();
    }
    public void howPlay()
    {

        Debug.Log("play");
        Panel.SetActive(true);

    }
    public void howPlayClose()
    {

        Panel.SetActive(false);

    }
}
