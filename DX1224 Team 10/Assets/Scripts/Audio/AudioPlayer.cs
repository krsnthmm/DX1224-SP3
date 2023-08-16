using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    private AudioSource audioSrc;
    [SerializeField] private AudioClip[] audioClips;

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayClip(int i)
    {
        audioSrc.clip = audioClips[i];
        audioSrc.Play();
    }
}
