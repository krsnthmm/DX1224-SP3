using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private GameObject enemy;

    public float speed;
    private float timer;
    public float lifetime;
    public float distance;

    private Rigidbody2D rb;
    public LayerMask whatIsSolid;

    [SerializeField] private Deflector deflector;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = 0f;
    }

    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);

        timer += Time.deltaTime;

        if (timer < lifetime)
        {
            if (hitInfo.collider != null)
            {
                if (!hitInfo.collider.CompareTag("Shield"))
                {
                    if (hitInfo.collider.CompareTag("Player"))
                    {
                        var target = hitInfo.collider.gameObject;
                        target.GetComponent<PlayerController>().TakeDamage(enemy.GetComponent<Enemy>().attack);
                    }
                    Destroy(gameObject);
                }
                else
                {
                    transform.Rotate(0f, 0f, 180f);
                }
            }
        }
        else
        {
            Destroy(gameObject);
        }

        rb.velocity = speed * transform.up;
    }
}
