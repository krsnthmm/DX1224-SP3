using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopUIIcon : MonoBehaviour
{
    [SerializeField] private InventoryItem itemOnSale;
    [SerializeField] private Image borderImage;
    public bool isSelected;

    public void Awake()
    {
        Deselect();
        isSelected = false;
    }

    public InventoryItem GetItem()
    {
        return itemOnSale;
    }

    public void SetItem(InventoryItem itemSet)
    {
        itemOnSale = itemSet;
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
