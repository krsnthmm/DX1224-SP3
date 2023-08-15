using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float timer;
    public float lifetime;
    public float distance;
    public LayerMask whatIsSolid;

    private void Start()
    {
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
                //if (hitInfo.collider.CompareTag("Player"))
                //{

                //}
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }

        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}
