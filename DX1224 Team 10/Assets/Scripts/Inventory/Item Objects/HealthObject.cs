using UnityEngine;

[CreateAssetMenu(fileName = "New Default Object", menuName = "Inventory System/Items/Health")]
public class HealthObject : InventoryItem
{
    public int healthValue;
    public bool isMaxIncrease;

    public void Awake()
    {
        type = ItemType.Health;
    }
}
