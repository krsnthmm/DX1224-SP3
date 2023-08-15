using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    private Animator m_animator;

    [SerializeField] private float movementSpeed = 1f;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private bool isIdle;
    private bool isWalking;

    private bool isDashing;
    [SerializeField] private float DashSpeed;
    [SerializeField] private float DashDuration;

    //stamina bar
    public Image StaminaBar;
    public float Stamina, MaxStamina;
    public float Dashing;

    // Refill rate and interval
    [SerializeField] private float staminaRefillRate = 0.5f; // Amount of stamina to refill per second
    [SerializeField] private float idleStaminaRefillInterval = 1f; // Interval to refill stamina while idle
    private float timeSinceLastIdleRefill;

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
        if (Input.GetKeyDown(KeyCode.Space) && !isDashing && Stamina > 0) // Added Stamina > 0 condition
        {
            isDashing = true;
            isWalking = true;
            StartCoroutine(Dash());
            Debug.Log("dashing");
            Stamina -= Dashing;
            if (Stamina <= 0)
            {
                Stamina = 0;
                isDashing = false;
            }
            Stamina -= Dashing * Time.deltaTime;
            StaminaBar.fillAmount = Stamina / MaxStamina;

            // Idle animation logic
            if (!isDashing && (isIdle || isWalking))
            {
                m_animator.Play("Player_Idle_Front");
              
            }
        }

        else if (!isDashing && (isIdle || isWalking))
        {
            // Refill stamina gradually when idle
            timeSinceLastIdleRefill += Time.deltaTime;
            if (timeSinceLastIdleRefill >= idleStaminaRefillInterval)
            {
                timeSinceLastIdleRefill = 1f;
                Stamina = Mathf.Clamp(Stamina + staminaRefillRate * idleStaminaRefillInterval, 0f, MaxStamina);
                StaminaBar.fillAmount = Stamina / MaxStamina;
            }
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
            isWalking = true;
        }
        else if (horizontalInput < 0)
        {
            m_animator.Play("Player_Walk_Left");
            isIdle = false;
            isWalking = true;
        }
        else if (verticalInput > 0)
        {
            m_animator.Play("Player_Walk_Back");
            isIdle = false;
            isWalking = true;
        }
        else if (verticalInput < 0)
        {
            m_animator.Play("Player_Walk_Front");
            isIdle = false;
            isWalking = true;
        }
        else
        {
            isIdle = true;
            isWalking = false;
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
