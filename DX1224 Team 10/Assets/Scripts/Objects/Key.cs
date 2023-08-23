using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private GameObject uiToShow;
    private bool playerInRange;
    public bool gotKey = false;

    // Update is called once per frame
    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.F))
        {
            if (gameObject.CompareTag("Key"))
            {
                gotKey = true;
                //uiToShow.SetActive(false);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
            uiToShow.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            uiToShow.SetActive(false);
        }
    }
}
