using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private GameObject target;
    private PlayerController player;
    [SerializeField] private GameObject enemy;

    private Animator animator;
    private Rigidbody2D rb;
    private ParticleSystem ps;

    private float speed;
    [SerializeField] private float rotateSpeed;
    private float timer;
    [SerializeField] private float followTime; // amount of time projectile follows the player for in seconds
    [SerializeField] private float lifetime; // projectile lifetime in seconds

    private bool hitSolid; // has it hit the player / a wall ?
    private bool isAnimFinished;

    private void Start()
    {
        timer = 0f;

        target = GameObject.FindGameObjectWithTag("Player");
        player = target.GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        ps = GetComponentInChildren<ParticleSystem>();


        animator.SetBool("active", true);
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;

        // we don't want to make it too easy for the player to run away, so we make our fireball's speed the same as our player's walk speed
        speed = player.playerData.walkSpeed;

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

        rb.velocity = speed * transform.up;

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

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            hitSolid = true;

            player.TakeDamage(enemy.GetComponent<Enemy>().attack);
        }
        else if (1 << col.gameObject.layer == enemy.GetComponent<Enemy>().whatIsObstacle)
        {
            hitSolid = true;
        }
    }

    private void AnimationFinishTrigger()
    {
        isAnimFinished = true;
    }
}
