using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeDoor : MonoBehaviour
{
    [Header("Player's Audio Player")]
    [SerializeField] private AudioPlayer audioPlayer;
    private bool playerInRange;
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
