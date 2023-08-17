using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    //public GameObject inventoryPrefab;
    // Inventory Obj that we want to display
    public Inventory inventory;
    //public GameObject iconPrefab;
    public GameObject iconPrefab;
    public List<GameObject> itemsDisplayed = new();
    public int X_START;
    public int Y_START;
    public int X_SPACE_BETWEEN_ITEM;
    public int NUMBER_OF_COLUMN;
    public int Y_SPACE_BETWEEN_ITEMS;
    private int prevInventoryIndex;
    private int currinventoryIndex;
    //Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();

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
            CreateItemIcon(i);
        }
    }

    private void CreateItemIcon(int i)
    {
        // Instantiate item icons in the inventory bar
        //var obj = Instantiate(inventory.Container[i].item.itemIcon, Vector3.zero, Quaternion.identity, transform);
        var obj = Instantiate(iconPrefab, Vector3.zero, Quaternion.identity, transform);

        // set iconPrefab's scriptable object to its respective item
        obj.GetComponent<InventoryUIIcon>().SetItem(inventory.Container[i].item);

        // set item icon to its respective icon
        obj.transform.GetChild(1).gameObject.GetComponentInChildren<Image>().sprite = inventory.Container[i].item.itemIcon;

        // set item icon positions 
        obj.GetComponent<RectTransform>().localPosition = GetPosition(i);

        // get the amount of items and display it
        obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");

        // add the item to our Dictionary
        //itemsDisplayed.Add(inventory.Container[i], obj);

        // add item to our list
        itemsDisplayed.Add(obj);

        Debug.Log(obj.transform.GetChild(1).gameObject);
    }

    public void UpdateDisplay()
    {
        // loop through items in the inventory obj
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            //// check if the item on display is in the inventory
            //if (itemsDisplayed.ContainsKey(inventory.Container[i]))
            //{
            //    // if yes, update the amount of the same item to the UI
            //    itemsDisplayed[inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            //}
            //else
            //{
            InventoryUIIcon inventoryUIIcon = itemsDisplayed[i].GetComponent<InventoryUIIcon>();

            if (inventoryUIIcon.GetItem() == inventory.Container[i].item)
            {
                inventoryUIIcon.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            }
            else { 
                // if not, create the item icon on display on the UI
                CreateItemIcon(i);
            }

            if (inventoryUIIcon.isSelected)
            {
                // get the current index
                currinventoryIndex = i;

                // Select the icon shown
                inventoryUIIcon.Select();

                // swap the values together
                int tempValue = currinventoryIndex;
                currinventoryIndex = prevInventoryIndex;
                prevInventoryIndex = tempValue;

                // deselect the previous value
                //itemsDisplayed[prevInventoryIndex].GetComponent<InventoryUIIcon>().ToggleSelection();

                Debug.Log("Current: " + currinventoryIndex + " Previous: " + prevInventoryIndex);
            }
            else
            {
                inventoryUIIcon.Deselect();
            }
        }
    }

    public Vector3 GetPosition(int i)
    {
        return new Vector3(X_START + (X_SPACE_BETWEEN_ITEM * (i % NUMBER_OF_COLUMN)), Y_START + (-Y_SPACE_BETWEEN_ITEMS * (i / NUMBER_OF_COLUMN)), 0f);
    }
}
