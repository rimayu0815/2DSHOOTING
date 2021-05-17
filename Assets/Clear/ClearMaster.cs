using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ClearMaster: MonoBehaviour
{
    private int[] cleaNum;

    [SerializeField]
    private MainMaster mainMas;

    // Start is called before the first frame update
    void Start()
    {
        cleaNum = new int[20];//作りかけ
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneChange();
        }
    }

    public void SceneChange()
    {
        SceneManager.LoadScene("Main");
    }


}
