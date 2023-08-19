using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    private Animator m_animator;
    private Rigidbody2D rb;

    private bool isAnimFinished;

    //Referencing PlayerData Script
    public PlayerData playerData;
    public Inventory playerInventory;

    private bool isDashing;
    private bool isDead;
    public bool knockedBack;

    //stamina bar
    public Image staminaBar;
    private float timeSinceLastIdleRefill;

    void Start()
    {
        playerData.currentStamina = playerData.maxStamina;
        playerData.currentSpeed = playerData.walkSpeed;

        m_animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        isAnimFinished = false;
    }

    void FixedUpdate()
    {
        // Move the player horizontally and vertically
        Vector2 moveDirection = new(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveDirection = Vector2.ClampMagnitude(moveDirection, 1);

        if (!knockedBack && !isDead)
        {
            rb.velocity = moveDirection * playerData.currentSpeed;
        }
        else if (isDead)
        {
            rb.velocity = Vector2.zero;
        }
    }

    void Update()
    {
        // keep rigidbody awake
        // without this pickupItem input won't work properly
        rb.WakeUp();

        if (playerData.currentHP > 0)
        {
            HandleMovementAnimations();

            // Dashing logic
            if (Input.GetKeyDown(KeyCode.Space) && !isDashing && playerData.currentStamina > 0) // Added Stamina > 0 condition
            {
                isDashing = true;

                StartCoroutine(Dash());
                Debug.Log("dashing");

                playerData.currentStamina -= playerData.staminaConsume;
                if (playerData.currentStamina <= 0)
                {
                    playerData.currentStamina = 0;
                    isDashing = false;
                }
                //stamina bar decrease logic
                playerData.currentStamina -= playerData.staminaConsume * Time.deltaTime;
                staminaBar.fillAmount = playerData.currentStamina / playerData.maxStamina;

            }

            else if (!isDashing)
            {
                // Refill stamina gradually when idle/walking
                timeSinceLastIdleRefill += Time.deltaTime;
                if (timeSinceLastIdleRefill >= playerData.staminaRefillInterval)
                {
                    timeSinceLastIdleRefill = 1f;
                    playerData.currentStamina = Mathf.Clamp(playerData.currentStamina + playerData.staminaRefillRate * playerData.staminaRefillInterval, 0f, playerData.maxStamina);
                    staminaBar.fillAmount = playerData.currentStamina / playerData.maxStamina;
                }
            }
        }
        else
        {
            // set player's current HP to 0 (HP cannot be negative)
            playerData.currentHP = 0;

            if (playerData.currentLives > 0)
            {
                // take away a life from the player
                playerData.currentLives -= 1;
            }

            // set other animation bools to false since player is dead
            m_animator.SetBool("idle", false);
            m_animator.SetBool("walk", false);
            m_animator.SetBool("dash", false);

            m_animator.SetBool("death", true);

            // if death animation is finished, set isDead to true and display death screen
            if (isAnimFinished)
            {
                isDead = true;
                Debug.Log("Player is dead.");
            }
        }
    }

    private void HandleMovementAnimations()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (horizontalInput != 0 || verticalInput != 0)
        {
            m_animator.SetBool("idle", false);
            m_animator.SetBool("walk", true);

            m_animator.SetFloat("x", horizontalInput);
            m_animator.SetFloat("y", verticalInput);
        }
        else
        {
            m_animator.SetBool("idle", true);
            m_animator.SetBool("walk", false);
        }
    }

    private IEnumerator Dash()
    {
        m_animator.SetBool("idle", false);
        m_animator.SetBool("walk", false);

        // Increase the player's movement speed for the dash
        playerData.currentSpeed = playerData.dashSpeed;

        // Play dash animation
        m_animator.SetBool("dash", true);

        // Continue dashing for the specified duration
        yield return new WaitForSeconds(playerData.dashDuration);

        // Reset movement speed
        playerData.currentSpeed = playerData.walkSpeed;

        // Set dashing to false
        m_animator.SetBool("dash", false);
        isDashing = false;
    }

    public void TakeDamage(int damage)
    {
        playerData.currentHP -= damage;

        Debug.Log(playerData.currentHP);
    }

    void AnimationFinishTrigger()
    {
        isAnimFinished = true;
    }
}
