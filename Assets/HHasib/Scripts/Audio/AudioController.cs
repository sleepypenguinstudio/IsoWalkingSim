using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private static AudioController instance;


    private void Awake()


    {
        instance = this;
    }

    public AudioController GetInstance()
    {
        return instance;
    }


    public void PlayAudio(AudioSource audioSource,AudioClip audioClip)
    {

    }


}
