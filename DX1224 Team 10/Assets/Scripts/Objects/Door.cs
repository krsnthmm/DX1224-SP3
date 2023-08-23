using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject uiToShow;

    [Header("References")]
    [SerializeField] private AudioPlayer audioPlayer;
    [SerializeField] private PlayerData playerData;

    private bool playerInRange;

    // Update is called once per frame
    void Update()
    {
        if (playerInRange && Input.GetKey(KeyCode.F) && gameObject.CompareTag("Door"))
        {
            audioPlayer.PlayClip(3);
            Destroy(gameObject);
        }

        if (playerData != null) 
        {
            if (playerInRange && Input.GetKey(KeyCode.F) && gameObject.CompareTag("LockedDoor") && playerData.hasKey)
            {
                audioPlayer.PlayClip(3);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (gameObject.CompareTag("Door") || (gameObject.CompareTag("LockedDoor") && playerData.hasKey))
            {
                playerInRange = true;
                ShowUI(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
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
