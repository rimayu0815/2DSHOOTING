using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip PlastartSound;

    public bool getSound = false;

    [SerializeField]
    private SoundMaster soundMaster;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if(soundMaster.plaSound == true)
        {
            audioSource.PlayOneShot(PlastartSound);
            soundMaster.plaSound = false;
        }

    }


}
