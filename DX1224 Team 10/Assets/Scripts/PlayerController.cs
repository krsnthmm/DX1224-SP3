using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator m_animator;

    [SerializeField] private float movementSpeed = 1f;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private bool isIdle;

    private bool isDashing;
    [SerializeField] private float DashSpeed;
    [SerializeField] private float DashDuration;

    void Start()
    {
        m_animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Move the player horizontally and vertically
        Vector2 moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveDirection = Vector2.ClampMagnitude(moveDirection, 1);

        if (!isDashing)
        {
            rb.velocity = moveDirection * movementSpeed;
        }
        else
        {
            rb.velocity = moveDirection * DashSpeed;
        }
    }

    void Update()
    {
        HandleMovementAnimations();

        // Dashing logic
        if (Input.GetKeyDown(KeyCode.X) && !isDashing)
        {
            isDashing = true;
            StartCoroutine(Dash());
        }

        // Idle animation logic
        if (!isDashing && isIdle)
        {
            m_animator.Play("Player_Idle_Front");
        }
    }

    private void HandleMovementAnimations()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (horizontalInput > 0)
        {
            m_animator.Play("Player_Walk_Right");
            isIdle = false;
        }
        else if (horizontalInput < 0)
        {
            m_animator.Play("Player_Walk_Left");
            isIdle = false;
        }
        else if (verticalInput > 0)
        {
            m_animator.Play("Player_Walk_Back");
            isIdle = false;
        }
        else if (verticalInput < 0)
        {
            m_animator.Play("Player_Walk_Front");
            isIdle = false;
        }
        else
        {
            isIdle = true;
        }
    }

    private IEnumerator Dash()
    {
        // Store the player's original movement speed
        float originalSpeed = movementSpeed;

        // Increase the player's movement speed for the dash
        movementSpeed = DashSpeed;

        // Play dash animation
        m_animator.Play("Player_Dash_Front");

        // Continue dashing for the specified duration
        yield return new WaitForSeconds(DashDuration);

        // Reset movement speed
        movementSpeed = originalSpeed;

        // Set dashing to false
        isDashing = false;
    }
}
