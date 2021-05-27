using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySound : MonoBehaviour
{
    public AudioClip EnestartSound;
    private AudioSource audioSource;
    private float seconds;
    public bool soundOk = false;

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
        if(soundMaster.eneSound == true)
        {
            audioSource.PlayOneShot(EnestartSound);
            soundMaster.eneSound = false;
        }

    }




}
