using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPuzzle2 : MonoBehaviour
{
    public bool BoxOnHole2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PuzzleBox2"))
        {
            BoxOnHole2 = true;
            collision.transform.position = transform.position;
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Static;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PuzzleBox2"))
        {
            BoxOnHole2 = false;
        }
    }
}


