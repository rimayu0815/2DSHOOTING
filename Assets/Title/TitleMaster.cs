using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TitleMaster : MonoBehaviour
{
    //[SerializeField]
    //private Canvas textPress;

    [SerializeField]
    private AudioClip audioClip;

    private AudioSource audioSource;

    [SerializeField]
    private ButtonScript button;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();

        //audioSource.clip = audioClip;

        //audioSource.Play();

    }

    // Update is called once per frame
    void Update()
    {
        if(button.buttonStart == true)//左クリックしたら
        {
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

    public void PressDisplay()
    {
        //textPress.DOFade(1.0f, 1.0f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }
}
