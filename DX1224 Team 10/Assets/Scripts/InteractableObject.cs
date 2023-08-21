using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public GameObject uiToShow; // Reference to the UI GameObject that you want to show

    private bool playerInRange = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            ShowUI(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            ShowUI(false);
        }
    }

    private void ShowUI(bool show)
    {
        if (uiToShow != null)
        {
            uiToShow.SetActive(show);
        }
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E)) // Change KeyCode.E to the desired interact key
        {
            // Add your interaction logic here
            // For example, you can play a sound, trigger an animation, etc.
        }
    }
}
