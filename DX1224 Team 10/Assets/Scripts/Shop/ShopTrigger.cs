using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    [SerializeField] private GameObject uiToShow;

    private bool playerInRange;

    private void Update()
    {
        if (!PauseMenuUIManager.IsPaused && playerInRange && Input.GetKeyDown(KeyCode.F))
        {
            ShopUIManager.isShopOpen = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
            ShowUI(true);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
            ShowUI(false);
        }
    }

    private void ShowUI(bool b)
    {
        uiToShow.SetActive(b);
    }
}
