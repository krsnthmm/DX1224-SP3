using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public PlayerData playerData;
    private bool PlayerInRange;

    private void Start()
    {
       
    }

    void Update()
    {
        if (PlayerInRange && Input.GetKeyDown(KeyCode.F))
        {
            if (gameObject.CompareTag("Interactable"))
            {
                playerData.coins++;
                Debug.Log("Player gets coins");
            }

            if (gameObject.CompareTag("Destructible"))
            {
                playerData.coins++;
                Destroy(gameObject);
            }
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerInRange = false;
        }
    }
}
