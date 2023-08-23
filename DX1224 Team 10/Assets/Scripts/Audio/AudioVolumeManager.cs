using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioVolumeManager : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private AudioPlayer audioPlayer;

    [Header("Volume Sliders")]
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider BGMSlider;
    [SerializeField] private Slider SFXSlider;

    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = GetComponent<AudioPlayer>();

        masterSlider.value = PlayerPrefsManager.Load("MasterVolume");
        BGMSlider.value = PlayerPrefsManager.Load("BGMVolume");
        SFXSlider.value = PlayerPrefsManager.Load("SFXVolume");

        Debug.Log(masterSlider.value + ", " + BGMSlider.value + ", " + SFXSlider.value);
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
