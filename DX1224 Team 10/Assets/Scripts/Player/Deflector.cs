using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deflector : MonoBehaviour
{
    public float deflectionForce = 10f;
    public Vector2 deflectionDirection;

    private PlayerController player;
    private GameObject shield;
    private bool isShieldActive;

    private void Start()
    {
        player = GetComponent<PlayerController>();
        shield = transform.GetChild(0).gameObject;
        isShieldActive = false;
        shield.SetActive(false);
    }

    private void Update()
    {
        if (shield != null)
        {
            if (Input.GetKeyDown(KeyCode.Q) && player.playerData.hasCrossEquipped)
            {
                Debug.Log("a");
                StartCoroutine(ShieldUpCo());
            }
            else if (!player.playerData.hasCrossEquipped)
            {
                isShieldActive = false;
            }

            shield.SetActive(isShieldActive);
        }
    }

    private IEnumerator ShieldUpCo()
    {
        if (shield != null)
        {
            isShieldActive = true;

            yield return new WaitForSeconds(player.playerData.shieldDuration);

            isShieldActive = false;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (shield != null)
        {
            if (collision.collider.CompareTag("Arrow"))
            {
                // Calculate the deflection direction based on the collision normal
                deflectionDirection = Vector2.Reflect(collision.relativeVelocity.normalized, collision.contacts[0].normal).normalized;
            }
            else
                return;
        }
    }
}
