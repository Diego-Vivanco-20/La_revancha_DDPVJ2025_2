using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSFxMuerto : MonoBehaviour
{
    public AudioSource SFxMuertoSource;

    public AudioClip[] SFxClip;

    public static SoundSFxMuerto InstanceSFxMuerto;
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
        InstanceSFxMuerto = this;
    }

    public void AtaqueMuerto()
    {
        SFxMuertoSource.PlayOneShot(SFxClip[0]);
    }

    public void RecibeAtaque()
    {
        SFxMuertoSource.PlayOneShot(SFxClip[1]);
    }
    public void PersecucionMuerto()
    {
        SFxMuertoSource.PlayOneShot(SFxClip[2]);
    }

    public void Derrota()
    {
        SFxMuertoSource.PlayOneShot(SFxClip[3]);
    }

    public void Machetear()
    {
        SFxMuertoSource.PlayOneShot(SFxClip[4]);
    }
}
