using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private GameObject target;
    private PlayerController player;

    private Animator animator;
    private Rigidbody2D rb;
    private ParticleSystem ps;

    public float speed;
    public float rotateSpeed;
    private float timer;
    public float followTime; // amount of time projectile follows the player for in seconds
    public float lifetime; // projectile lifetime in seconds

    private bool hitSolid; // has it hit the player / a wall ?
    private bool isAnimFinished;

    private void Start()
    {
        timer = 0f;

        target = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        ps = GetComponentInChildren<ParticleSystem>();

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
            
        rb.velocity = speed * Time.deltaTime * transform.up;

        if (hitSolid || timer > lifetime)
        {
            ps.Stop();

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

            player = collision.gameObject.GetComponent<PlayerController>();
            player.TakeDamage(15);
        }
    }

    private void AnimationFinishTrigger()
    {
        isAnimFinished = true;
    }
}
