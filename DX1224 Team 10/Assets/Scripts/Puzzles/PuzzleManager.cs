using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private BoxPuzzle[] boxPuzzles;
    public bool boxPuzzleCompleted = false;

    // Update is called once per frame
    void Update()
    {
        // assume puzzle is incomplete before the for loop
        boxPuzzleCompleted = true;

        // check if each box in the array is in its respective hole
        for (int i = 0; i < boxPuzzles.Length; i++)
        {
            if (!boxPuzzles[i].isBoxInHole)
            {
                boxPuzzleCompleted = false;
                break; // we've found a box that's not in its hole
            }
        }
    }
}
