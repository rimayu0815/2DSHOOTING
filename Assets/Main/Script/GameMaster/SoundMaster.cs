using System.Collections;
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

    [SerializeField]
    private AudioSource startSe;
    [SerializeField]
    private AudioClip startSE;


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

        while (true)
        {
            eneSound = true;
            yield return new WaitForSeconds(3.5f);

            if (!eneSound)
            {

                plaSound = true;
                plaPanelOn = true;
                break;
 
            }
        }
    }

    public void AudioPlayButton()
    {
        StartCoroutine(WaitCommand());
    }

    public void SE()
    {
        startSe.PlayOneShot(startSE);
        
    }

}
