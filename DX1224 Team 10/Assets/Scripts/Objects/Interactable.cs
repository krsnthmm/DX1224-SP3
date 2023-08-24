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
    [SerializeField] private AudioPlayer audioPlayer;

    private Vector3 lockerPosition;
    private Quaternion lockerRotation;
    private PlayerData playerData;

    public PlayerController playerController;

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
        audioPlayer = playerObject.GetComponent<AudioPlayer>();
    }

    void Update()
    {
        if (!PauseMenuUIManager.isPaused && playerInRange && Input.GetKeyDown(KeyCode.F) && !isInLocker)
        {
            if (gameObject.CompareTag("Interactable") && !hasGottenCoin)
            {
                Debug.Log("Player gets coin");
                playerData.coins++;
                audioPlayer.PlayClip(2);
                hasGottenCoin = true;
                ShowUI(false);
            }
            else if (gameObject.CompareTag("Destructible"))
            {
                playerData.coins++;
                audioPlayer.PlayClip(2);
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
        playerController.rb.bodyType = RigidbodyType2D.Kinematic;
        playerController.rb.constraints = RigidbodyConstraints2D.FreezeAll;


        SpriteRenderer playerRenderer = playerObject.GetComponent<SpriteRenderer>();
        playerRenderer.enabled = false;


        playerObject.transform.SetPositionAndRotation(lockerPosition, lockerRotation);
        ShowUI(true);

        isInLocker = true;
    }

    private void TransformOutOfLocker()
    {
        playerController.rb.bodyType = RigidbodyType2D.Dynamic;
        playerController.rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        SpriteRenderer playerRenderer = playerObject.GetComponent<SpriteRenderer>();
        playerRenderer.enabled = true;

        playerObject.transform.SetPositionAndRotation(lockerPosition + Vector3.down, lockerRotation);
        ShowUI(false);

        isInLocker = false;
    }

    private void ShowUI(bool b)
    {
        uiToShow.SetActive(b);
    }
}