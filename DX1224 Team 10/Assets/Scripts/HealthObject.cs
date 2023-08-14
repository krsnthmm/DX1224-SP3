using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Default Object", menuName = "Inventory System/Items/Health")]
public class HealthObject : InventoryItem
{
    public int restoreHealthValue;
    public void Awake()
    {
        type = ItemType.Health;
    }
}
