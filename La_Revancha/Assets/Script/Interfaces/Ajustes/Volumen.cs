using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Volumen : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider musicSlider;
    public Slider ambientalSlider;
    public Slider SFxSlider;
    public Slider masterSlider;
    public AudioMixer mainAudioMixer;

    private float currentMusicVolume;
    private float currentAmbientalVolume;
    private float currentSfxVolume;
    private float currentMasterVolume;



    // Start is called before the first frame update
    void Start()
    {
        if (mainAudioMixer.GetFloat("musicVolume", out currentMusicVolume))
            musicSlider.value = currentMusicVolume;
        if (mainAudioMixer.GetFloat("ambientalVolume", out currentAmbientalVolume))
            ambientalSlider.value = currentAmbientalVolume;
        if (mainAudioMixer.GetFloat("SFxVolume", out currentSfxVolume))
            SFxSlider.value = currentSfxVolume;
        if(mainAudioMixer.GetFloat("masterVolume", out currentMasterVolume))
            masterSlider.value = currentMasterVolume;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMusicVolumeChange(float volume)
    {
        mainAudioMixer.SetFloat("musicVolume", volume);
    }

    public void OnAmbientalVolumeChange(float volume)
    {
        mainAudioMixer.SetFloat("ambientalVolume", volume);
    }

    public void OnSFxVolumeChange(float volume)
    {
        mainAudioMixer.SetFloat("SFxVolume", volume);
    }

    public void OnMaterVolumeChange(float volume)
    {
        mainAudioMixer.SetFloat("masterVolume", volume);
    }
}
