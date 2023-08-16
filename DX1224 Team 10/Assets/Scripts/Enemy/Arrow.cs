using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed;
    private float timer;
    public float lifetime;
    public float distance;

    private Rigidbody2D rb;
    public LayerMask whatIsSolid;

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
                if (hitInfo.collider.CompareTag("Player"))
                {
                    Debug.Log("Player takes damage!");
                }
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }

        rb.velocity = speed * Time.deltaTime * transform.up;
    }
}
