using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deflector : MonoBehaviour
{
    public float deflectionForce = 10f;
    public Vector2 deflectionDirection;

    private GameObject shield;
    private bool isShieldActive;
    private void Start()
    {
        shield = GameObject.Find("Shield");
        isShieldActive = false;
        shield.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleShield();
        }
    }

    private void ToggleShield()
    {
        if (shield != null)
        {
            isShieldActive = !isShieldActive;
            shield.SetActive(isShieldActive);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Arrow arrow = collision.collider.GetComponent<Arrow>();
        
        if (shield != null && collision.collider.CompareTag("Arrow"))
        {
            // Calculate the deflection direction based on the collision normal
            deflectionDirection = Vector2.Reflect(collision.relativeVelocity.normalized, collision.contacts[0].normal);

            // Get the arrow's rigidbody if it has one
            Rigidbody2D arrowRigidbody = collision.collider.GetComponent<Rigidbody2D>();

            if (arrowRigidbody != null)
            {
                // Apply a force to the arrow in the deflection direction
                //arrowRigidbody.velocity = deflectionDirection * deflectionForce;
                arrow.isDeflected = true;
            }
        }
        else
        {
            arrow.isDeflected = false;
        }    
    }
}
