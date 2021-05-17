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
    private AudioClip audioClip1;

    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();

        //audioSource.clip = audioClip1;

        //audioSource.Play();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))//左クリックしたら
        {
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
