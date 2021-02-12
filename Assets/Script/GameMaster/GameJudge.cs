using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameJudge: MonoBehaviour
{
    private Enemy enemy;//Enemyが破壊されたという判定を取得するため
    private PlayerController playercontroller;//Playerが破壊されたという判定を取得するため

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //isClear();作成してから
        //isGameOver();
    }

    /// <summary>
    /// クリア判定
    /// </summary>
    public void isClear()
    {
        if (enemy.destroiedEnemy == true)
        {
            SceneManager.LoadScene("Result");
        }
    }


    /// <summary>
    /// ゲームオーバー判定
    /// </summary>
    public void isGameOver()
    {
        if(playercontroller.destroiedPlayer == true)
        {
            SceneManager.LoadScene("Result");
        }
    }
}
