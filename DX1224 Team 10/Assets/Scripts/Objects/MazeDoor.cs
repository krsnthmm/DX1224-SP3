using UnityEngine;

public class MazeDoor : MonoBehaviour
{
    [Header("Player's Audio Player")]
    [SerializeField] private AudioPlayer audioPlayer;
    public PuzzleManager puzzleManager;

    // Update is called once per frame
    void Update()
    {
        if (puzzleManager.boxPuzzleCompleted)
        {
            audioPlayer.PlayClip(3);
            Destroy(gameObject);
        }
    }
}
