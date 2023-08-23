using UnityEngine;

public class BoxPuzzle : MonoBehaviour
{
    [SerializeField] private GameObject box;
    private AudioPlayer audioPlayer;
    public bool isBoxInHole;

    private void Start()
    {
        audioPlayer = GetComponent<AudioPlayer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == box)
        {
            isBoxInHole = true;
            collision.transform.position = transform.position;
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Static;

            audioPlayer.PlayClip(0);
        }
    }
}
