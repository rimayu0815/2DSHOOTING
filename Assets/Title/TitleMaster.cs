using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TitleMaster : MonoBehaviour
{
    [SerializeField]
    private AudioSource buttonSe;

    [SerializeField]
    private AudioClip buttonSE;


    [SerializeField]
    private ButtonScript button;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(button.buttonStart == true)//左クリックしたら
        {
            SE();

            button.buttonStart = false;
            SeaneChange();
        }
    }

    /// <summary>
    ///MainSceneへ切り替え
    /// </summary>
    public void SeaneChange()
    {
        SceneManager.LoadScene("Main");
    }

    public void SE()
    {
        buttonSe.PlayOneShot(buttonSE);
    }

}
