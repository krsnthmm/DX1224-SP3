using UnityEngine;

public class BoxPuzzle2 : MonoBehaviour
{
    public bool BoxOnHole2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PuzzleBox2"))
        {
            BoxOnHole2 = true;
            collision.transform.position = transform.position;
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Static;
        }
    }
}


