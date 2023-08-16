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

    private bool isAnimFinished;

    private bool isDashing;
    private bool isDead;
    public bool knockedBack;
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

    public Inventory playerInventory;
    public PlayerData playerData;

    void Start()
    {
        m_animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        isAnimFinished = false;
    }

    void FixedUpdate()
    {
        // Move the player horizontally and vertically
        Vector2 moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveDirection = Vector2.ClampMagnitude(moveDirection, 1);

        if (!knockedBack && !isDead)
        {
            if (!isDashing)
            {
                rb.velocity = moveDirection * movementSpeed;
            }
            else
            {
                rb.velocity = moveDirection * DashSpeed;
            }
        }
        else if (isDead)
        {
            rb.velocity = Vector2.zero;
        }
    }

    void Update()
    {
        if (playerData.currentHP > 0)
        {
            HandleMovementAnimations();

            // Dashing logic
            if (Input.GetKeyDown(KeyCode.Space) && !isDashing && playerData.currentStamina > 0) // Added Stamina > 0 condition
            {
                isDashing = true;
                StartCoroutine(Dash());
                Debug.Log("dashing");
                //Stamina -= Dashing;
                if (playerData.currentStamina <= 0)
                {
                    playerData.currentStamina = 0;
                    isDashing = false;
                }
                //StaminaBar.fillAmount = Stamina / MaxStamina;
            }

            else if (!isDashing)
            {
                // Refill stamina gradually when idle
                timeSinceLastIdleRefill += Time.deltaTime;
                if (timeSinceLastIdleRefill >= idleStaminaRefillInterval)
                {
                    timeSinceLastIdleRefill = 1f;
                    playerData.currentStamina = Mathf.Clamp(playerData.currentStamina + staminaRefillRate * idleStaminaRefillInterval, 0f, playerData.maxStamina);
                    //StaminaBar.fillAmount = Stamina / MaxStamina;
                }
            }
        }
        else
        {
            isDead = true;

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

        // Store the player's original movement speed
        float originalSpeed = movementSpeed;

        // Increase the player's movement speed for the dash
        movementSpeed = DashSpeed;

        // Play dash animation
        m_animator.SetBool("dash", true);

        // Continue dashing for the specified duration
        yield return new WaitForSeconds(DashDuration);

        // Reset movement speed
        movementSpeed = originalSpeed;

        Stamina -= Dashing * Time.deltaTime;

        // Set dashing to false
        m_animator.SetBool("dash", false);
        isDashing = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        var item = col.GetComponent<Item>();
        // check if player that collides with the object has an item script
        if (item)
        {
            Debug.Log("!");
            // add the item to the player's inventory
            playerInventory.AddItem(item.item, 1);
            // Destroy the item after adding it to inventory
            Destroy(col.gameObject);
        }
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
