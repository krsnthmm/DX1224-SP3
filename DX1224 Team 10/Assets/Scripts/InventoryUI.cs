using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    // Inventory Obj that we want to display
    public Inventory inventory;
    public int X_START;
    public int Y_START;
    public int X_SPACE_BETWEEN_ITEM;
    public int NUMBER_OF_COLUMN;
    public int Y_SPACE_BETWEEN_ITEMS;
    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        CreateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
    }

    public void CreateDisplay()
    {
        // loop through items in the inventory obj
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            // Instantiate item icons in the inventory bar
            var obj = Instantiate(inventory.Container[i].item.itemIcon, Vector3.zero, Quaternion.identity, transform);
            // set item icon positions 
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            // get the amount of items and display it
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            // add the item to our Dictionary
            itemsDisplayed.Add(inventory.Container[i], obj);
        }
    }

    public void UpdateDisplay()
    {
        // loop through items in the inventory obj
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            // check if the item on display is in the inventory
            if (itemsDisplayed.ContainsKey(inventory.Container[i]))
            {
                // if yes, update the amount of the same item to the UI
                itemsDisplayed[inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            } else
            {
                // if not, create the item icon on display on the UI
                // Instantiate item icons in the inventory bar
                var obj = Instantiate(inventory.Container[i].item.itemIcon, Vector3.zero, Quaternion.identity, transform);
                // set item icon positions 
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                // get the amount of items and display it
                obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
                // add the item to our Dictionary
                itemsDisplayed.Add(inventory.Container[i], obj);
            }
        }
    }

    public Vector3 GetPosition(int i)
    {
        return new Vector3(X_START + (X_SPACE_BETWEEN_ITEM * (i % NUMBER_OF_COLUMN)), Y_START + (-Y_SPACE_BETWEEN_ITEMS * (i / NUMBER_OF_COLUMN)), 0f);
    }
}
