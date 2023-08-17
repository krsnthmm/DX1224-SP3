using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    private Animator m_animator;
    private SpriteRenderer sr;
    private Rigidbody2D rb;

    //Referencing PlayerData Script
    public PlayerData playerData;
    public Inventory playerInventory;

    private bool isIdle;
    private bool isWalking;

    private bool isDashing;
    //stamina bar
    public Image StaminaBar;
    private float timeSinceLastIdleRefill;

    void Start()
    {
        playerData.defaultStamina = playerData.maxStamina;
        playerData.currentSpeed = playerData.defaultSpeed;
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
            rb.velocity = moveDirection * playerData.defaultSpeed;
        }
        else
        {
            rb.velocity = moveDirection * playerData. dashSpeed;
        }
    }

    void Update()
    {
        HandleMovementAnimations();
        // Dashing logic
        if (Input.GetKeyDown(KeyCode.Space) && !isDashing && playerData.defaultStamina > 0) // Added Stamina > 0 condition
        {
            isDashing = true;
            isWalking = true;
           
            Debug.Log("dashing");
            playerData.defaultStamina -= playerData.staminaConsume;
            if (playerData.defaultStamina <= 0)
            {
                playerData.defaultStamina = 0;
                isDashing = false;
            }
            //stamina bar decrease logic
            playerData.defaultStamina -= playerData.staminaConsume * Time.deltaTime;
            StaminaBar.fillAmount = playerData.defaultStamina / playerData.maxStamina;

            // Idle animation logic
            if (!isDashing && (isIdle || isWalking))
            {
                m_animator.Play("Player_Idle_Front");
            }
            StartCoroutine(Dash());
        }

        else if (!isDashing && (isIdle || isWalking))
        {
            // Refill stamina gradually when idle/walking
            timeSinceLastIdleRefill += Time.deltaTime;
            if (timeSinceLastIdleRefill >= playerData.staminaRefillInterval)
            {
                timeSinceLastIdleRefill = 1f;
                playerData.defaultStamina = Mathf.Clamp(playerData.defaultStamina + playerData.staminaRefillRate * playerData.staminaRefillInterval, 0f, playerData.maxStamina);
                StaminaBar.fillAmount = playerData.defaultStamina / playerData.maxStamina;
            }
        }

        playerData.currentSpeed = playerData.defaultSpeed;


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
        float originalSpeed = playerData.defaultSpeed;

        // Increase the player's movement speed for the dash
        playerData.defaultSpeed = playerData. dashSpeed;

        // Play dash animation
        m_animator.Play("Player_Dash_Front");

        // Continue dashing for the specified duration
        yield return new WaitForSeconds(playerData. dashDuration);

        // Reset movement speed
        playerData.defaultSpeed = originalSpeed;

        // Set dashing to false
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
}
