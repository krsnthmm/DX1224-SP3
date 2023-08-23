using UnityEngine;

[CreateAssetMenu(fileName = "New Default Object", menuName = "Inventory System/Items/Default")]
public class DefaultObject : InventoryItem
{
    public void Awake()
    {
        type = ItemType.Default;
    }
}
