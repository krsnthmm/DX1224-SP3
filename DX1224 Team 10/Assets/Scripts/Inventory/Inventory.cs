using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* We use an inventory scriptable object so we can create multiple inventories, 
 especially for the shop or anything that stores items in general */

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class Inventory : ScriptableObject
{
    [Header("References")]
    [SerializeField] private PlayerData playerData;

    [Header("Inventory")]
    private int maxItems;
    public bool showScrollPopup;
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
            switch (Container[i].item.type)
            {
                case ItemType.Health:
                    var healthItem = Container[i].item as HealthObject;
                    if (!healthItem.isMaxIncrease)
                    {
                        playerData.currentHP += healthItem.healthValue;
                        if (playerData.currentHP > playerData.maxHP)
                        {
                            playerData.currentHP = playerData.maxHP;
                        }
                    }
                    else
                    {
                        playerData.maxHP += healthItem.healthValue;
                    }
                    break;
                case ItemType.Stamina:
                    var staminaItem = Container[i].item as StaminaObject;
                    playerData.currentStamina += staminaItem.staminaValue;
                    if (playerData.currentStamina > playerData.maxStamina)
                    {
                        playerData.currentStamina = playerData.maxStamina;
                    }
                    break;
                case ItemType.Speed:
                    var speedItem = Container[i].item as SpeedObject;
                    if (speedItem.isTempBoost)
                    {
                        playerData.currentSpeed += speedItem.speedValue;
                    }
                    else
                    {
                        playerData.walkSpeed += speedItem.speedValue;
                        playerData.dashSpeed += speedItem.speedValue;
                    }
                    break;
                case ItemType.Default:
                    var defaultItem = Container[i].item as DefaultObject;
                    if (defaultItem.name == "Cross")
                    {
                        playerData.hasCrossEquipped = !playerData.hasCrossEquipped;
                    }
                    break;
                default:
                    break;
            }

            if (Container[i].item.type < ItemType.KeyObject)
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