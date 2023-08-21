using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject uiToShow;

    [Header("Player's Audio Player")]
    [SerializeField] private AudioPlayer audioPlayer;
    private bool playerInRange;

    // Update is called once per frame
    void Update()
    {
        if (playerInRange && Input.GetKey(KeyCode.F))
        {
            audioPlayer.PlayClip(3);
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
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

    private void ShowUI(bool b)
    {
        uiToShow.SetActive(b);
    }
}
