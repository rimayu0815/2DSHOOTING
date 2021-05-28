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

    [SerializeField]
    private PanelMaster panelMaster;

    public bool start = false;

    [SerializeField]
    private GameObject stageText;
    public bool onStage = false;
    public bool offPanel = false;


    public int level;

    // Start is called before the first frame update
    void Start()
    {
        stageText.SetActive(false);

        StartCoroutine(isStageLevel());

        startText.SetActive(false);

        timerlabel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
                    
        if(panelMaster.ready == true)
        {

            
            StartCoroutine(StartTimer());

        }


        if (enemy.destroiedEnemy == true)
        {
            Invoke("isClear", 1.5f);
        }
        if (playercontroller.destroiedPlayer == true)
        {
            Invoke("isGameOver", 1.5f);
        }

        if(start == true)
        {
            GameTimer();
        }


    }


    private IEnumerator isStageLevel()
    {
        stageText.SetActive(true);

        yield return new WaitForSeconds(2);

        stageText.SetActive(false);
        onStage = true;
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

    private  IEnumerator StartTimer()//Ready Go
    {
        
        yield return new WaitForSeconds(3);
        offPanel = true;

        startTimer -= Time.deltaTime;


        if(startTimer <4.5)
        {
            timerLabel.text = "Ready…";//Readyに変更
            timerlabel.SetActive(true);
        }
        if (startTimer < 1)
        {
            timerlabel.SetActive(false);

            startText.SetActive(true);//これ使ってないからこれを導入のテキストに置き換え
        }
        if(startTimer <0)
        {
            startTimer = 0;

            startText.SetActive(false);

            start = true;
            panelMaster.ready = false;


        }


    }

    public void GameTimer()//右上の時間表示
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
