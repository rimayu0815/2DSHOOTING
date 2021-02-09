using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameJudge: MonoBehaviour
{
    private Enemy enemy;
    private PlayerController playercontroller;

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
    public void isClear()
    {
        if (enemy.destroiedEnemy == true)
        {
            SceneManager.LoadScene("Result");
        }
    }
    public void isGameOver()
    {
        if(playercontroller.destroiedPlayer == true)
        {
            SceneManager.LoadScene("Result");
        }
    }
}
