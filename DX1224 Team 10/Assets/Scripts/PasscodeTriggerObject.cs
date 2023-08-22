using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PasscodeTriggerObject : MonoBehaviour
{
    [SerializeField] private GameObject uiToShow;
    [SerializeField] private GameObject passcodePrompt;
    private bool playerInRange = false;
    [HideInInspector] public bool enteredCorrectCode = false;

    private void Update()
    {
        if (!PauseMenuUIManager.IsPaused && playerInRange && Input.GetKeyDown(KeyCode.F))
        {
            passcodePrompt.SetActive(true);
            Time.timeScale = 0f; //pause the game
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!enteredCorrectCode)
        {
            if (collision.CompareTag("Player"))
            {
                uiToShow.SetActive(true);
                playerInRange = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!enteredCorrectCode)
        {
            if (collision.CompareTag("Player"))
            {
                uiToShow.SetActive(false);
                playerInRange = false;
            }
        }
    }

    public void CompletePrompt()
    {
        Time.timeScale = 1f;
    }
}
