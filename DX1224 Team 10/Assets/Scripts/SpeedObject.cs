using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Default Object", menuName = "Inventory System/Items/Speed")]
public class SpeedObject : InventoryItem
{
    public int speedValue;
    [SerializeField] private bool isTempBoost;
    public float buffDuration;
    public void Awake()
    {
        type = ItemType.Speed;
    }
}