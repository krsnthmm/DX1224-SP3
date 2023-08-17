using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIIcon : MonoBehaviour
{
    // Serialized to check if the right object is assigned to the icon
    [SerializeField] private InventoryItem item;
    [SerializeField] private Image borderImage;

    public void Awake()
    {
        Deselect();
    }

    public void SetItem(InventoryItem itemSet)
    {
        item = itemSet;
    }

    public void Select()
    {
        borderImage.enabled = true;
    }

    public void Deselect()
    {
        borderImage.enabled = false;
    }
}
