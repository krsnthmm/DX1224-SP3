using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [Header("Inventory Display")]
    public Inventory inventory;
    public GameObject iconPrefab;
    public List<GameObject> itemsList = new();

    [Header("Item Details Display")]
    public Image itemDetailsIcon;
    public TMP_Text itemName;
    public TMP_Text itemDescription;
    public Button useButton;

    [Header("Item Box Placements")]
    public int X_START;
    public int Y_START;
    public int X_SPACE_BETWEEN_ITEM;
    public int NUMBER_OF_COLUMN;
    public int Y_SPACE_BETWEEN_ITEMS;

    private int prevInventoryIndex;
    private int currInventoryIndex;
    Dictionary<InventorySlot, GameObject> itemsDictionary = new();

    // Start is called before the first frame update
    void Start()
    {
        // init prev index as -1
        // otherwise, we cannot select inventoryUIIcon[0] without selecting something else first
        prevInventoryIndex = -1;
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
            if (inventory.Container[i].amount > 0)
            {
                CreateItemIcon(i);
            }
        }

        // display default text
        itemName.text = "None";
        itemDescription.text = "Click on an item for more details.";

        // use button shouldn't be displayed immediately since an item hasn't been selected
        useButton.gameObject.SetActive(false);
    }

    private void CreateItemIcon(int i)
    {
        // Instantiate item icons in the inventory bar
        var obj = Instantiate(iconPrefab, Vector3.zero, Quaternion.identity, transform);

        // set iconPrefab's scriptable object to its respective item
        obj.GetComponent<InventoryUIIcon>().SetItem(inventory.Container[i].item);

        // set item icon to its respective icon
        var itemIconObj = obj.transform.GetChild(1).gameObject;
        itemIconObj.GetComponentInChildren<Image>().sprite = inventory.Container[i].item.itemIcon;

        // set item icon positions 
        obj.GetComponent<RectTransform>().localPosition = GetPosition(i);

        // get the amount of items and display it
        obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");

        // add the item to our Dictionary
        itemsDictionary.Add(inventory.Container[i], obj);

        // add item to our list
        itemsList.Add(obj);
    }

    private void RemoveItemIcon(int i)
    {
        Destroy(itemsList[i]);

        itemsList.Remove(itemsList[i]);
        itemsDictionary.Remove(inventory.Container[i]);

        inventory.RemoveItem(inventory.Container[i].item);

        // update item icon positions
        for (int j = 0; j < itemsList.Count; j++)
        {
            itemsList[j].GetComponent<RectTransform>().localPosition = GetPosition(j);
        }
    }

    public void UpdateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            if (itemsDictionary.ContainsKey(inventory.Container[i]))
            {
                itemsDictionary[inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            }
            else
            {
                CreateItemIcon(i);
            }

            InventoryUIIcon inventoryUIIcon = itemsList[i].GetComponent<InventoryUIIcon>();

            if (inventoryUIIcon.GetItem() == inventory.Container[i].item)
            {
                inventoryUIIcon.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            }
            else
            {
                CreateItemIcon(i);
            }

            if (inventoryUIIcon.isSelected)
            {
                if (prevInventoryIndex != -1)
                {
                    int tempValue = currInventoryIndex;
                    prevInventoryIndex = tempValue;
                }

                currInventoryIndex = i;

                if (currInventoryIndex != prevInventoryIndex && prevInventoryIndex != -1)
                {
                    itemsList[prevInventoryIndex].GetComponent<InventoryUIIcon>().isSelected = false;
                }
                else if (prevInventoryIndex == -1)
                {
                    prevInventoryIndex = currInventoryIndex;
                }

                if (inventory.Container[i].amount <= 0)
                {
                    inventoryUIIcon.Deselect();

                    RemoveItemIcon(currInventoryIndex);

                    // set currInventoryIndex to 0 since the item[i] is gone
                    // this is to prevent any indexOutOfRange errors
                    currInventoryIndex = 0;

                    ResetDisplay();
                }
                else
                {
                    inventoryUIIcon.Select();

                    itemDetailsIcon.sprite = inventory.Container[i].item.itemIcon;

                    itemName.text = inventory.Container[i].item.name;
                    itemDescription.text = inventory.Container[i].item.description;

                    useButton.gameObject.SetActive(true);

                    Debug.Log("Current: " + currInventoryIndex + " Previous: " + prevInventoryIndex);
                }
            }
            else
            {
                inventoryUIIcon.Deselect();
            }
        }
    } 

    public void OnUseButtonClick()
    {
        inventory.UseItem(currInventoryIndex);
    }

    public void ResetDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            InventoryUIIcon inventoryUIIcon = itemsList[i].GetComponent<InventoryUIIcon>();

            if (inventoryUIIcon.isSelected)
            {
                inventoryUIIcon.isSelected = false;
            }
        }

        // display default empty icon
        itemDetailsIcon.sprite = iconPrefab.GetComponent<Image>().sprite;

        // display default text
        itemName.text = "None";
        itemDescription.text = "Click on an item for more details.";

        // use button shouldn't be displayed immediately since an item hasn't been selected
        useButton.gameObject.SetActive(false);
    }

    public Vector3 GetPosition(int i)
    {
        return new Vector3(X_START + (X_SPACE_BETWEEN_ITEM * (i % NUMBER_OF_COLUMN)), Y_START + (-Y_SPACE_BETWEEN_ITEMS * (i / NUMBER_OF_COLUMN)), 0f);
    }
}
