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
    //public int id;
    //public Sprite itemIcon;
    public ItemType type;
    [TextArea]
    public string description;
    //public bool isSelected;

    //public void Awake()
    //{
    //    isSelected = false;
    //}
}



//[System.Serializable]
//public class Item
//{
//    public string Name;
//    public int Id;
//    public Item(InventoryItem item)
//    {
//        Name = item.name;
//        Id = item.id;
//    }
//}