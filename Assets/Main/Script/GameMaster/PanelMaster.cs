using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelMaster : MonoBehaviour
{
    [SerializeField]
    private GameObject plaPanel;//playerのパネルオブジェクト
    [SerializeField]
    private GameObject enePanel;//enemyのパネルオブジェクト

    [SerializeField]
    private SoundMaster soundMaster;//サウンドマスターのScriptを参照

    [SerializeField]
    private MainMaster mainMaster;


    public bool ready= false;//MainMasterScriptのStartTimerを起動させるため

    // Start is called before the first frame update
    void Start()
    {
        plaPanel.SetActive(false);

        enePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(soundMaster.plaPanelOn == true)//PlayerのサウンドがなったらPlayerのパネルも出す
        {
            isplaPanel();
            soundMaster.plaPanelOn = false;
        }
        if(soundMaster.enePanelOn == true)//Enemyも同様
        {
            isenePanel();
            soundMaster.enePanelOn = false;
        }

        if(mainMaster.offPanel == true)
        {
            mainMaster.offPanel = false;
            OFFPanel();
        }
    }

    public void isplaPanel()//Playerのパネル表示とゲームスタートさせるため
    {
        plaPanel.SetActive(true);
        ready = true;//順序逆のほうが分かりやすいかもやけど、Enemyが喋った後にPlayerが喋るからこっちにトリガーをおいている
    }
    public void isenePanel()//Enemyのパネルを表示
    {
        enePanel.SetActive(true);
    }

    public void OFFPanel()
    {
        plaPanel.SetActive(false);
        enePanel.SetActive(false);
    }
}
