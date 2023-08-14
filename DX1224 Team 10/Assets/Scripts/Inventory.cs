using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* We use an inventory scriptable object so we can create multiple inventories, 
 especially for the shop or anything that stores items in general */

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class Inventory : ScriptableObject
{
    public int maxItems;
    public List<InventorySlot> Container = new List<InventorySlot>();
    
    // add to player inventory
    public void AddItem(InventoryItem _item, int _amount)
    {
        // check if we have that item in that inventory
        bool hasItem = false;
        // loop through the Inventory to check if we have the item
        for (int i = 0; i < Container.Count; i++)
        {
            // if we find the exact item in the inventory
            if (Container[i].item == _item)
            {
                // Add to the amount of the item we have
                Container[i].AddAmount(_amount);
                // set hasItem to true
                hasItem = true;
                // break the loop
                break;
            }

        }
        if (!hasItem && Container.Count < maxItems)
        {
            Container.Add(new InventorySlot(_item, _amount));
        }
    } 
}

[System.Serializable]
public class InventorySlot
{
    // type of item
    public InventoryItem item;
    // amount of items in the inventory
    public int amount;
    // probably won't use maxAmount since this is a small game
    // Inventory slot of the item and its amount
    public InventorySlot(InventoryItem _item, int _amount)
    {
        item = _item;
        amount = _amount;
    }
    // Add to the amount of objects you have in the inventory
    public void AddAmount(int value)
    {
        amount += value;
    }
}