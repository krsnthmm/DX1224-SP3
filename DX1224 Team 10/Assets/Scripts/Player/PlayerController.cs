using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    private Animator m_animator;
    private Rigidbody2D rb;
    private SceneLoader sceneLoader;

    private bool isAnimFinished;

    //Referencing PlayerData Script
    public PlayerData playerData;
    public Inventory playerInventory;
    public SpeedObject speedBoostItem;

    private bool isDashing;
    private bool isDead;
    public bool knockedBack;

    private float timeSinceLastIdleRefill;
    public ParticleSystem dashParticles;
    public ParticleSystem bloodParticles;

    void Start()
    {
        playerData.currentStamina = playerData.maxStamina;
        playerData.currentSpeed = playerData.walkSpeed;

        m_animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sceneLoader = GetComponent<SceneLoader>();

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
        if (playerData.currentHP > 0)
        {
            HandleMovementAnimations();
            
            if (playerData.hasSpeedBoost)
            {
                StartCoroutine(SpeedBoost());
            }

            // Dashing logic
            if (Input.GetKeyDown(KeyCode.Space) && !isDashing && playerData.currentStamina >= playerData.staminaConsume)
            {
                isDashing = true;

                StartCoroutine(Dash());
                Debug.Log("dashing");
                CreateTrails();

                //stamina bar decrease logic
                playerData.currentStamina -= playerData.staminaConsume;

                if (playerData.currentStamina < 0)
                {
                    playerData.currentStamina = 0;
                    isDashing = false;
                }

                timeSinceLastIdleRefill = 1f;
            }

            else if (!isDashing)
            {
                // Refill stamina gradually when idle/walking
                timeSinceLastIdleRefill += Time.deltaTime;
                if (timeSinceLastIdleRefill >= playerData.staminaRefillInterval)
                {
                    playerData.currentStamina += playerData.staminaRefillRate * Time.deltaTime;
                    if (playerData.currentStamina > 75)
                    {
                        playerData.currentStamina = 75;
                        timeSinceLastIdleRefill = 1f;
                    }
                }
            }
        }
        else
        {
            // set player's current HP to 0 (HP cannot be negative)
            playerData.currentHP = 0;

            // set other animation bools to false since player is dead
            m_animator.SetBool("idle", false);
            m_animator.SetBool("walk", false);
            m_animator.SetBool("dash", false);

            m_animator.SetBool("death", true);

            // if death animation is finished, set isDead to true and display death screen
            if (isAnimFinished)
            {
                isDead = true;
                sceneLoader.LoadScene(sceneLoader.sceneToLoad);
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
        CreateBlood();

        Debug.Log(playerData.currentHP);
    }

    void AnimationFinishTrigger()
    {
        isAnimFinished = true;
    }

    private IEnumerator SpeedBoost()
    {
        playerData.hasSpeedBoost = false;

        playerData.walkSpeed += speedBoostItem.speedValue;
        playerData.dashSpeed += speedBoostItem.speedValue;
        playerData.currentSpeed = playerData.walkSpeed;

        yield return new WaitForSeconds(30);

        playerData.walkSpeed -= speedBoostItem.speedValue;
        playerData.dashSpeed -= speedBoostItem.speedValue;
        playerData.currentSpeed = playerData.walkSpeed;
    }


    void CreateTrails()
    {
        dashParticles.Play();
    }

    void CreateBlood()
    {
        bloodParticles.Play();
    }
}
