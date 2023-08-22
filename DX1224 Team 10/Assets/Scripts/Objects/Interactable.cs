using UnityEngine;

public class Interactable : MonoBehaviour
{
    private bool playerInRange;
    private bool hasGottenCoin;
    private bool isInLocker;

    [Header("HUD > Interactable Prompt")]
    [SerializeField] private GameObject uiToShow;

    [Header("References")]
    [SerializeField] private GameObject playerObject;
    [SerializeField] private GameObject lockerObject;

    private Vector3 lockerPosition;
    private Quaternion lockerRotation;
    private PlayerData playerData;

    private void Start()
    {
        if (lockerObject != null)
        {
            lockerPosition = lockerObject.transform.position;
            lockerRotation = lockerObject.transform.rotation;
        }

        isInLocker = false;
        hasGottenCoin = false;
        playerData = playerObject.GetComponent<PlayerController>().playerData;
    }

    void Update()
    {
        if (!PauseMenuUIManager.IsPaused && playerInRange && Input.GetKeyDown(KeyCode.F) && !isInLocker)
        {
            if (gameObject.CompareTag("Interactable") && !hasGottenCoin)
            {
                Debug.Log("Player gets coin");
                playerData.coins++;
                playerObject.GetComponent<AudioPlayer>().PlayClip(2);
                hasGottenCoin = true;
                ShowUI(false);
            }
            else if (gameObject.CompareTag("Destructible"))
            {
                playerData.coins++;
                playerObject.GetComponent<AudioPlayer>().PlayClip(2);
                Destroy(gameObject);
                ShowUI(false);
            }
            else if (gameObject.CompareTag("Locker"))
            {
                Debug.Log("Player is interacting with locker");
                TransformIntoLocker();
            }
        }

        else if (isInLocker && Input.GetKeyDown(KeyCode.F))
        {
            TransformOutOfLocker();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasGottenCoin)
        {
            playerInRange = true;
            ShowUI(true);
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

    private void TransformIntoLocker()
    {
        playerObject.SetActive(false);
        playerObject.transform.SetPositionAndRotation(lockerPosition, lockerRotation);
        ShowUI(true);

        isInLocker = true;
    }

    private void TransformOutOfLocker()
    {
        playerObject.SetActive(true);
        playerObject.transform.SetPositionAndRotation(lockerPosition + Vector3.down, lockerRotation);
        ShowUI(false);

        isInLocker = false;
    }

    private void ShowUI(bool b)
    {
        uiToShow.SetActive(b);
    }
}