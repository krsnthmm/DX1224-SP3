using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioSource audioSrc;
    [SerializeField] private AudioClip[] audioClips;

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    public void PlayClip(int i)
    {
        audioSrc.clip = audioClips[i];
        audioSrc.Play();
    }
}
