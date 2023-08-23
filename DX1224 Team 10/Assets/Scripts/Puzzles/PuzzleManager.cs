using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private BoxPuzzle[] boxPuzzles;
    public bool boxPuzzleCompleted = false;

    // Update is called once per frame
    void Update()
    {
        boxPuzzleCompleted = true;

        for (int i = 0; i < boxPuzzles.Length; i++)
        {
            if (!boxPuzzles[i].isBoxInHole)
            {
                boxPuzzleCompleted = false;
                break;
            }
        }
    }
}
