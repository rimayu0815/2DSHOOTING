using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMaster: MonoBehaviour
{
    public Enemy enemy;//Enemyが破壊されたという判定を取得するため
    public PlayerController playercontroller;//Playerが破壊されたという判定を取得するため

    [SerializeField]
    private float startTimer;
    [SerializeField]
    private Text timerLabel;
    [SerializeField]
    private GameObject timerlabel;
    [SerializeField]
    private GameObject startText;
    //private bool starttext = false;

    [SerializeField]
    private float gameTimer;
    [SerializeField]
    private Text gameTimerLabel;

    public int level;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        StartTimer();
        //GameTimer();


        if (enemy.destroiedEnemy == true)
        {
            Invoke("isClear", 1.5f);
        }
        if (playercontroller.destroiedPlayer == true)
        {
            Invoke("isGameOver", 1.5f);
        }

    }

    /// <summary>
    /// クリア判定
    /// </summary>
    public void isClear()
    {
        level++;

        SceneManager.LoadScene("Clear");

    }


    /// <summary>
    /// ゲームオーバー判定
    /// </summary>
    public void isGameOver()
    {
        level = 0;

        SceneManager.LoadScene("GameOver");

    }

    public void StartTimer()
    {
        startTimer -= Time.deltaTime;
        
        if(startTimer < 1)
        {
            timerlabel.SetActive(false);

            startText.SetActive(true);
        }
        if(startTimer <0)
        {
            startTimer = 0;

            startText.SetActive(false);

            //Destroy(startText);

            //starttext = true;

            //if(starttext == true)
            //{
            //    startText.text = "Start!!";
            //    Destroy(startText, 2);
            //}

            GameTimer();
        }

        //timerLabel.text = "" + startTimer.ToString("0");
        timerLabel.text = "Ready…";//Readyに変更
    }

    public void GameTimer()
    {
        gameTimer -= Time.deltaTime;

        if (gameTimer < 0)
        {
            gameTimer = 0;

            SceneManager.LoadScene("GameOver");


        }

        gameTimerLabel.text = "" + gameTimer.ToString("0");
    }
}
