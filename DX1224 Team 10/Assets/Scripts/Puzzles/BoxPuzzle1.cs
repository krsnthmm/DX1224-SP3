using UnityEngine;

public class BoxPuzzle1 : MonoBehaviour
{
    public bool BoxOnHole1;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PuzzleBox1"))
        {
            BoxOnHole1 = true;
            collision.transform.position = transform.position;
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Static;
        }
    }
}


