using UnityEngine;

[CreateAssetMenu(fileName = "New Default Object", menuName = "Inventory System/Items/Stamina")]
public class StaminaObject : InventoryItem
{
    public float staminaValue;
    public void Awake()
    {
        type = ItemType.Stamina;
    }
}
