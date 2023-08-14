using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Health,
    Speed,
    Equipment,
    KeyObjects,
    Currency,
    Default
}

// base class to extend other item classes from
public abstract class InventoryItem : ScriptableObject
{
    public GameObject prefab;
    public ItemType type;
    [TextArea]
    public string description;
}
