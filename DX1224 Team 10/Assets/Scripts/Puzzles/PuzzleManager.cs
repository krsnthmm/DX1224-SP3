using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private BoxPuzzle[] boxPuzzles;
    [SerializeField] private AudioPlayer audioPlayer;
    public bool boxPuzzleCompleted = false;

    // Update is called once per frame
    void Update()
    {
        // assume boxPuzzleCompleted is true
        boxPuzzleCompleted = true;

        // check if each box in the array is in its respective hole
        for (int i = 0; i < boxPuzzles.Length; i++)
        {
            if (!boxPuzzles[i].isBoxInHole)
            {
                // if any box(es) are not in their respective holes, boxPuzzleCompleted is false
                boxPuzzleCompleted = false;
            }
        }
    }
}
