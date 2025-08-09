using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSFxProta : MonoBehaviour
{
    public AudioSource SFxProtaSource;

    public AudioClip[] SFxClip;

    public static SoundSFxProta InstanceSFxProta;


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
        InstanceSFxProta = this;
    }

    public void caminaProta()
    {
        SFxProtaSource.PlayOneShot(SFxClip[0]);
    }

    public void saltoProta()
    {
        SFxProtaSource.PlayOneShot(SFxClip[1]);
    }

    public void golpeaProta()
    {
        SFxProtaSource.PlayOneShot(SFxClip[2]);
    }
    public void pateaProta()
    {
        SFxProtaSource.PlayOneShot(SFxClip[3]);
    }
    public void impactaSueloProta()
    {
        SFxProtaSource.PlayOneShot(SFxClip[2]);
    }
}
