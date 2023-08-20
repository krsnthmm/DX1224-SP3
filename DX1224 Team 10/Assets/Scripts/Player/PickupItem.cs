using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    [SerializeField] private PickupUIManager pickupUIManager;
    private PlayerController player;
    private AudioPlayer audioPlayer;

    private bool isPromptOpen;
    private Collider2D collisionItem;

    private void Start()
    {
        player = GetComponent<PlayerController>();
        audioPlayer = GetComponent<AudioPlayer>();
    }

    private void Update()
    {
        if (isPromptOpen)
        {
            var item = collisionItem.GetComponent<Item>();

            if (Input.GetKeyDown(KeyCode.F))
            {
                if (item)
                {
                    // add the item to the player's inventory
                    player.playerInventory.AddItem(item.item, 1);

                    // play pickup item audio clip
                    audioPlayer.PlayClip(1);

                    // destroy the item after adding it to inventory
                    Destroy(collisionItem.gameObject);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        var item = col.GetComponent<Item>();

        // check if the object player collides with has an item script
        if (item)
        {
            // open pickup prompt
            pickupUIManager.OpenPrompt(item);
            collisionItem = col;
            isPromptOpen = true;
        }
        else if (col.gameObject.CompareTag("Coin"))
        {
            // add coins to playerData immediately
            player.playerData.coins += 5;

            // play pickup coin audio clip
            audioPlayer.PlayClip(2);

            // destroy the item after adding it to playerData
            Destroy(col.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        var item = col.GetComponent<Item>();

        // check if the object player collides with has an item script
        if (item)
        {
            pickupUIManager.ClosePrompt();
            collisionItem = null;
            isPromptOpen = false;
        }
    }
}
