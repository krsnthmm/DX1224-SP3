using UnityEngine;

[CreateAssetMenu(fileName = "New Default Object", menuName = "Inventory System/Items/KeyObject")]
public class KeyObject : InventoryItem
{
    [TextArea]
    public string keyText;
    public void Awake()
    {
        type = ItemType.KeyObject;
    }
}
