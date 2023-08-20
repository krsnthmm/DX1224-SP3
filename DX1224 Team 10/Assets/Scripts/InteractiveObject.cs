using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractiveObject : MonoBehaviour
{
    public GameObject passcodePrompt;
    //public Passcode passcode;
    private bool inPromptState = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Working");
        if(collision.CompareTag("Player"))
        {
            passcodePrompt.SetActive(true);
            Debug.Log("collided");
            inPromptState = true;
            Time.timeScale = 0f;//pause the game
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            passcodePrompt.SetActive(false);
            inPromptState = false;
            Time.timeScale = 1f;
        }
    }

    public void YesButtonPressed()
    {
        passcodePrompt.SetActive(false); // Hide the prompt
        // Show the passcode UI (activate it here)
        // You can also disable player movement and enemy actions

        inPromptState = true; // Set the prompt state to true
        //interactiveObject.StartPasscodeInput(); // Call the method to start passcode input
        Time.timeScale = 0f; // Pause the game
    }

    public void NoButtonPressed()
    {
        passcodePrompt.SetActive(false); // Hide the prompt
        Time.timeScale = 1f; // Resume the game
    }



    public void CompletePrompt()
    {
        inPromptState = false;
        Time.timeScale = 1f;
    }
}
