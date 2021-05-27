﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMaster : MonoBehaviour
{
    public bool plaSound;
    public bool eneSound;

    public bool plaPanelOn = false;
    public bool enePanelOn = false;

    [SerializeField]
    private MainMaster mainMaster;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (mainMaster.onStage ==true)
        {
            AudioPlayButton();

            mainMaster.onStage = false;
        }
    }

    private IEnumerator WaitCommand()
    {

        enePanelOn = true;

        Debug.Log("一回目");
        while (true)
        {
            eneSound = true;
            yield return new WaitForSeconds(2);

            Debug.Log("二回目");
            if (!eneSound)
            {

                plaSound = true;
                plaPanelOn = true;
                Debug.Log("三回目");
                break;
 
            }
        }
    }

    public void AudioPlayButton()
    {
        StartCoroutine(WaitCommand());
    }
}