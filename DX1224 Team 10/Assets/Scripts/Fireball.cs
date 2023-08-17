using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private GameObject target;

    private Animator animator;
    private Rigidbody2D rb;

    public float speed;
    public float rotateSpeed;
    private float timer;
    public float followTime;
    public float lifetime;

    private bool hitSolid;
    private bool isAnimFinished;

    private void Start()
    {
        timer = 0f;

        target = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        animator.SetBool("active", true);
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (timer < followTime)
        {
            Vector2 direction = ((Vector2)target.transform.position - rb.position).normalized;
            float rotateAmount = Vector3.Cross(direction, transform.up).z;

            rb.angularVelocity = -rotateAmount * rotateSpeed;
        }
        else
        {
            rb.angularVelocity = 0f;
        }
            
        rb.velocity = transform.up * speed;

        if (hitSolid || timer > lifetime)
        {
            rb.angularVelocity = 0f;
            rb.velocity = Vector2.zero;

            animator.SetBool("active", false);
            animator.SetBool("hit", true);

            if (isAnimFinished)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hitSolid = true;
        }
    }

    private void AnimationFinishTrigger()
    {
        isAnimFinished = true;
    }
}
