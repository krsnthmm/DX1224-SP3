using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locker : MonoBehaviour
{
    private bool PlayerInRange;
    private bool IsInLocker;

    public GameObject playerObject;
    public GameObject lockerObject;
    private Vector3 lockerPosition;
    private Quaternion lockerRotation;
    private Vector3 playerPosition;
    private Quaternion playerRotation;

    private void Start()
    {
        lockerPosition = lockerObject.transform.position;
        lockerRotation = lockerObject.transform.rotation;
        playerPosition = playerObject.transform.position;
        playerRotation = playerObject.transform.rotation;

        IsInLocker = false;
    }

    void Update()
    {
        if (PlayerInRange && Input.GetKeyDown(KeyCode.E) && !IsInLocker)
        {
            if (gameObject.CompareTag("Locker"))
            {
                TransformIntoLocker();
            }
        }

        else if (IsInLocker && Input.GetKeyDown(KeyCode.E))
        {
            TransformOutOfLocker();
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

    private void TransformIntoLocker()
    {
        playerObject.SetActive(false);

        playerObject.transform.position = lockerPosition;
        playerObject.transform.rotation = lockerRotation;

        IsInLocker = true;
    }

    private void TransformOutOfLocker()
    {
        playerObject.SetActive(true);

        playerObject.transform.position = lockerPosition + Vector3.down;
        playerObject.transform.rotation = lockerRotation;

        IsInLocker = false;
    }
}
