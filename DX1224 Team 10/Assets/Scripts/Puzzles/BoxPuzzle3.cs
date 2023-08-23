using UnityEngine;

public class BoxPuzzle3 : MonoBehaviour
{
    public bool BoxOnHole3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PuzzleBox3"))
        {
            BoxOnHole3 = true;
            collision.transform.position = transform.position;
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Static;
        }
    }
}


