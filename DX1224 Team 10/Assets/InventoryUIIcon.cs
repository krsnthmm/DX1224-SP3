using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIIcon : MonoBehaviour
{
    // Serialized to check if the right object is assigned to the icon
    [SerializeField] private InventoryItem item;
    [SerializeField] private Image borderImage;
    public bool isSelected;

    public void Awake()
    {
        Deselect();
        isSelected = false;
    }

    public InventoryItem GetItem()
    {
        return item;
    }

    public void SetItem(InventoryItem itemSet)
    {
        item = itemSet;
    }

    public void ToggleSelection()
    {
        if (!isSelected)
        {
            isSelected = true;
        }
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
