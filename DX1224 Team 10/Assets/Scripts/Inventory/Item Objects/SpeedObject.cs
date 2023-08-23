using UnityEngine;

[CreateAssetMenu(fileName = "New Default Object", menuName = "Inventory System/Items/Speed")]
public class SpeedObject : InventoryItem
{
    public int speedValue;
    public bool isTempBoost;
    public float buffDuration;
    public void Awake()
    {
        type = ItemType.Speed;
    }
}
