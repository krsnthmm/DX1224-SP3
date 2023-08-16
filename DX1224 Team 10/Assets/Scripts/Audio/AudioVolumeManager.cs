using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioVolumeManager : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider masterSlider;
    public Slider BGMSlider;
    public Slider SFXSlider;

    // Start is called before the first frame update
    void Start()
    {
        masterSlider.value = PlayerPrefsManager.Load("MasterVolume");
        BGMSlider.value = PlayerPrefsManager.Load("BGMVolume");
        SFXSlider.value = PlayerPrefsManager.Load("SFXVolume");
        Debug.Log(masterSlider.value + ", " + BGMSlider.value + ", " + SFXSlider.value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMasterVolume()
    {
        mixer.SetFloat("MasterVolume", masterSlider.value);
        PlayerPrefsManager.Save("MasterVolume", masterSlider.value);
    }

    public void SetBGMVolume()
    {
        mixer.SetFloat("BGMVolume", BGMSlider.value);
        PlayerPrefsManager.Save("BGMVolume", BGMSlider.value);
    }

    public void SetSFXVolume()
    {
        mixer.SetFloat("SFXVolume", SFXSlider.value);
        PlayerPrefsManager.Save("SFXVolume", SFXSlider.value);
    }
}
