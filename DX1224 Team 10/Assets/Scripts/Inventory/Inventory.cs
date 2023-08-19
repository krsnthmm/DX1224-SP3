using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* We use an inventory scriptable object so we can create multiple inventories, 
 especially for the shop or anything that stores items in general */

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class Inventory : ScriptableObject
{
    public int maxItems;
    public PlayerData playerData;
    public List<InventorySlot> Container = new();

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
        else
        {
            Debug.Log("No more space");
        }
    } 

    // remove from player inventory
    public void RemoveItem(InventoryItem _item)
    {
        // declare itemToRemove as null first
        InventorySlot itemToRemove = null;

        // check if we have that item in that inventory
        bool hasItem = false;

        // loop through the Inventory to check if we have the item
        for (int i = 0; i < Container.Count; i++)
        {
            // if we find the exact item in the inventory
            if (Container[i].item == _item)
            {
                // set hasItem to true
                hasItem = true;

                // set itemToRemove to current inventory slot
                itemToRemove = Container[i];

                // break the loop
                break;
            }
        }

        if (hasItem)
        {
            Container.Remove(itemToRemove);
        }
        else
            return;
    }

    public void UseItem(int i)
    {
        if (Container[i].amount > 0)
        {
            switch (Container[i].item.name)
            {
                case ("Billybob Medicine"):
                    playerData.currentHP += 25;

                    if (playerData.currentHP > playerData.maxHP)
                    {
                        playerData.currentHP = playerData.maxHP;
                    }
                    break;
                case ("Billybob Power-ade"):
                    playerData.currentStamina += 30;

                    if (playerData.currentStamina > playerData.maxStamina)
                    {
                        playerData.currentStamina = playerData.maxStamina;
                    }
                    break;
                case ("Billybob-ster Energy"):
                    playerData.walkSpeed += 5;
                    // TODO: playerData coroutine, set movementspeed back to 0 at the end of 30s
                    break;
                case ("Some Billybob's Heart"):
                    playerData.maxHP += 50;
                    break;
                case ("Billybob Shoes"):
                    playerData.walkSpeed += 5;
                    break;
                default:
                    break;
            }

            if (Container[i].item.type != ItemType.KeyObject)
            {
                Container[i].amount--;
            }
        }
        else
            return;
    }
}

[System.Serializable]
public class InventorySlot
{
    // type of item
    public InventoryItem item;

    // amount of items in the inventory
    // probably won't use maxAmount since this is a small game
    public int amount;

    // check if this is selected
    public bool isSelected;

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