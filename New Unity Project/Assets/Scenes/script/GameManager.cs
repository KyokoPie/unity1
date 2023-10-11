using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;

    public AudioSource HitMusic;

    public AudioSource HitMusicSP;

    public AudioSource DeadMusic;
    public AudioSource DeadMusicBG;

    public AudioSource WinMusic;

    public bool starPlaying;

    public BeatScroller theBS;

    public static GameManager instance;

    public int comboCount;
    public int combo = 1;

    public int scoreCount;
    public int score = 100;

    public int HP = 100;

    public GameObject comboText;

    public Text scoreText;
    public Text HpText;
    public Text TopBarScoreText;

    private Animator animator;
    public GameObject blackboard;

    public Image HpBar;
    public Image EndBar;

    public GameObject death1;
    public GameObject pauseOb;
    public GameObject winBackground;
    static public bool DeskBoun;

    static public bool CanBeEnd;

    public bool gameEnd;

    // Start is called before the first frame update
    void Start()
    {

        DeskBoun = false;
        BeatScroller.hasStarted = false;
        animator = blackboard.GetComponent<Animator>();

        instance = this;
        theMusic.Play();

        scoreText.text = "";

        DeadMusic.volume = 1;
        DeadMusicBG.volume = 1;
        WinMusic.volume = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!starPlaying)
        {
            animator.SetBool("start", true);
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("blackboard"))
            {
                Invoke("exitAnim",5.0f);
                
                    

                
            }
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("blackboardUp"))
            {

                Invoke("StartPlay", 1.0f);
            }
        }
        if (!DeskBoun)
        {
            if (comboCount %10 == 0 && comboCount != 0)
            {
                BeatScroller.hasStarted = false;
                DestScroller.DeskStart = true;
                DestScroller.DeskBoun = true;
                DeskBoun = true;
            }

        }
        if(HP <= 0)
        {
            if (!gameEnd)
            {
                theMusic.Pause();
                DeadMusic.Play();
                DeadMusicBG.Play();
                death1.SetActive(true);
                Invoke("GamePause", 0.5f);
                BeatScroller.hasStarted = false;
                gameEnd = true;
                NoteObject.canBeAni = false;
                NoteObject.canBeAni2 = false;
            }
            HP = 0;
            HpText.text = HP + "/100";

        }




        if(scoreCount >= 10000)
        {
            haatoAttAni.EndAni = true;
            BeatScroller.hasStarted = false;
            scoreCount = 0;

        }

        if (CanBeEnd)
        {
            if (!gameEnd)
            {
                winBackground.SetActive(true);
                theMusic.Pause();
                WinMusic.Play();
                Invoke("GamePause", 1.0f);
                gameEnd = true;
                CanBeEnd = false;
            }
        }
        if (gameEnd)
        {
            HP = 0;
        }
        



    }

    public void NoteHit()
    {
        Debug.Log("hit");

        comboCount += combo;
        scoreCount += score;
        scoreText.text = ""+comboCount;
        comboText.SetActive(true);
        
        EndBar.GetComponent<Image>().fillAmount += 0.01f;
        TopBarScoreText.text = "Score:"+ scoreCount;

        if (HP < 100)
        {
            HpBar.GetComponent<Image>().fillAmount += 0.01f;
            HP += 1;
            HpText.text = HP + "/100";
        }
        if (BeatScroller.hasStarted)
        {
            HitMusic.Play();
        }


    }
    public void NoteHitBonus()
    {
        Debug.Log("hitBonus");

        comboCount += combo;
        scoreCount += 1000;
        scoreText.text = "" + comboCount;
        comboText.SetActive(true);
        HitMusicSP.Play();
        EndBar.GetComponent<Image>().fillAmount += 0.1f;
        TopBarScoreText.text = "Score:" + scoreCount;


        if(HP < 100)
        {
            HpBar.GetComponent<Image>().fillAmount += 0.01f;
            HP += 1;
            HpText.text = HP + "/100";
        }
        




    }

    public void NoteMissed()
    {
        Debug.Log("HitMiss");
        comboCount = 0;
        comboText.SetActive(false);
        HpBar.GetComponent<Image>().fillAmount -= 0.1f;
        HP -= 10;
        HpText.text = HP+"/100" ;

        if(scoreCount > 0)
        {
            scoreCount -= 50;
            TopBarScoreText.text = "Score:" + scoreCount;
            EndBar.GetComponent<Image>().fillAmount -= 0.005f;

        }
       

    }

    void exitAnim()
    {
        animator.SetBool("end", true);
        
    }

    void StartPlay()
    {
        starPlaying = true;
        BeatScroller.hasStarted = true;
    }
    public void Exit()
    {

        Debug.Log("exit");
        Application.Quit();
    }
    public void Retry()
    {
        Time.timeScale = 1f;
        
        gameEnd = false;
        DeadMusic.volume = 0;
        DeadMusicBG.volume = 0;
        WinMusic.volume = 0;

        SceneManager.LoadScene("SampleScene");

    }

    public void Menu()
    {
        Time.timeScale = 1f;
        
        gameEnd = false;

        DeadMusic.volume = 0;
        DeadMusicBG.volume = 0;
        WinMusic.volume = 0;
        SceneManager.LoadScene("Menu");

    }
    void GamePause()
    {
        Time.timeScale = 0f;
    }


}
