using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private BoxPuzzle[] boxPuzzles;
    [SerializeField] private AudioPlayer audioPlayer;
    public bool boxPuzzleCompleted = false;
    private int boxCount = 0;

    // Update is called once per frame
    void Update()
    {
        // check if each box in the array is in its respective hole
        for (int i = 0; i < boxPuzzles.Length; i++)
        {
            if (boxPuzzles[i].isBoxInHole)
            {
                if (boxCount >= boxPuzzles.Length)
                {
                    boxPuzzleCompleted = true;
                    audioPlayer.PlayClip(3);
                }
            }
            boxCount++;
        }
    }
}
