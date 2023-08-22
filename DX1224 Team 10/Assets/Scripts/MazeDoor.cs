using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeDoor : MonoBehaviour
{
    [Header("Player's Audio Player")]
    [SerializeField] private AudioPlayer audioPlayer;
    public PuzzleManager puzzleManager;

    // Update is called once per frame
    void Update()
    {
        if (puzzleManager.BoxPuzzleCompleted)
        {
            audioPlayer.PlayClip(3);
            Destroy(gameObject);
        }
    }
}
