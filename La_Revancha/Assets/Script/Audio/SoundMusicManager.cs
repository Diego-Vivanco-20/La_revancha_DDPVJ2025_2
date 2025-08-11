using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMusicManager : MonoBehaviour
{
    public AudioSource musicAudioSource;

    public AudioClip[] musicClip;

    public SoundMusicManager InstanceMusic;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        InstanceMusic = this;
    }

    public void PlayMainMenu()
    {
        musicAudioSource.PlayOneShot(musicClip[0]);
    }

    public void PlayMenuAjustes()
    {
        musicAudioSource.PlayOneShot(musicClip[1]);
    }
}
