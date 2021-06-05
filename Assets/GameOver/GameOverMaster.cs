using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverMaster : MonoBehaviour
{
    [SerializeField]
    private AudioSource buttonSe;

    [SerializeField]
    private AudioClip buttonSE;


    [SerializeField]
    private ButtonGameOver buttonGameOver;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonGameOver.buttonReStart == true)//左クリックしたら
        {
            SE();

            buttonGameOver.buttonReStart = false;
            SeaneChange();
        }
    }
    public void SeaneChange()
    {
        SceneManager.LoadScene("Title");
    }

    public void SE()
    {
        buttonSe.PlayOneShot(buttonSE);
    }
}
