using System.Collections.Generic;
using UnityEngine;

// Shop Scriptable Object
[CreateAssetMenu(fileName = "New Shop", menuName = "Shop System")]
public class Shop : ScriptableObject
{
    public List<ShopSlot> Container = new();
    [SerializeField] private List<ShopSlot> DefaultShop = new();

    public void RemoveItem(InventoryItem _item)
    {
        // declare itemToRemove as null first
        ShopSlot itemToRemove = null;

        // check if we have that item in the shop inventory
        bool hasItem = false;

        // loop through the Inventory to check if we have the item
        for (int i = 0; i < Container.Count; i++)
        {
            // if we find the exact item in the inventory
            if (Container[i].item == _item)
            {
                // set hasItem to tru
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

    public void SetDefaults()
    {
        Container = DefaultShop;
    }
}

[System.Serializable]
// Shop Item Slot
public class ShopSlot
{
    // type of item
    public InventoryItem item;
    // amount of items in the shop
    public int amount;
    // price of items in the shop
    public float price;
    // check if selected
    public bool isSelected;
    // Shop Slot of the item and its quantity and price
    public ShopSlot(InventoryItem _item, int _amount, float _price)
    {
        item = _item;
        amount = _amount;
        price = _price;
    }
    // Deduct amount after it is being bought
    public void DeductAmount(int value)
    {
        amount -= value;
    }
}
