using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceManager : MonoBehaviour
{

    private AudioSource jumpAudioSource;
    private AudioSource crashAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        jumpAudioSource = gameObject.AddComponent<AudioSource>();
        crashAudioSource = gameObject.AddComponent<AudioSource>();

        jumpAudioSource.clip = Resources.Load("Sounds/game_jump") as AudioClip;
        crashAudioSource.clip = Resources.Load("Sounds/crash") as AudioClip;
        
    }

    //Method that when called, plays jump audio
    public void PlayJumpSound()
    {
        jumpAudioSource.Play();
    }

    //Method that when called, plays crash audio
    public void PlayCrashSound()
    {
        crashAudioSource.Play();
    }
}
