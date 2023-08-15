using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Inventory playerInventory;
    public PlayerData playerData;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        var item = col.GetComponent<Item>();
        // check if player that collides with the object has an item script
        if (item)
        {
            Debug.Log("!");
            // add the item to the player's inventory
            playerInventory.AddItem(item.item, 1);
            // Destroy the item after adding it to inventory
            Destroy(col.gameObject);
        }
    }
}
