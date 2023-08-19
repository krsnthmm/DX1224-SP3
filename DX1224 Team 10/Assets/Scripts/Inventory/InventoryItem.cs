using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Health,
    Speed,
    Stamina,
    KeyObject,
    Default
}

// base class to extend other item classes from
public abstract class InventoryItem : ScriptableObject
{
    public Sprite itemIcon;
    public ItemType type;
    [TextArea]
    public string description;
}

public class InventoryItemBase : MonoBehaviour
{
    public InventoryItem itemData;
}