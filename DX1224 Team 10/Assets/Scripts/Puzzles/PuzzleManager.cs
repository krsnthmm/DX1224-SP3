using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public BoxPuzzle1 boxPuzzle1;
    public BoxPuzzle2 boxPuzzle2;
    public BoxPuzzle3 boxPuzzle3;
    public bool BoxPuzzleCompleted = false;

    // Update is called once per frame
    void Update()
    {
        if (boxPuzzle1.BoxOnHole1 && boxPuzzle2.BoxOnHole2 && boxPuzzle3.BoxOnHole3)
        {
            BoxPuzzleCompleted = true;
        }
    }
}
