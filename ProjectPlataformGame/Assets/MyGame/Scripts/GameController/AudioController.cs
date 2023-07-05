using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;

    public List<AudioClip>songs = new List<AudioClip> ();

    public AudioSource audioSource;
    private void Awake()
    {
        instance = this;
    }


    void Update()
    {
        
    }

    public void PlaySong(AudioClip audio)
    {
        audioSource.PlayOneShot (audio);
    }

    public void SwitchSong(AudioClip audio)
    {
        audioSource.clip = audio;
        audioSource.Play();

    }
}
