using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    private PlayerController player;

    private void Start()
    {
        player = GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        var item = col.GetComponent<Item>();

        // check if player that collides with the object has an item script
        if (item)
        {
            // TODO: add prompt
            Debug.Log("!");
            // add the item to the player's inventory
            player.playerInventory.AddItem(item.item, 1);
            // Destroy the item after adding it to inventory
            Destroy(col.gameObject);
        }
        else if (col.gameObject.CompareTag("Coin"))
        {
            player.playerData.coins += 5;
            Destroy(col.gameObject);
        }
    }
}
