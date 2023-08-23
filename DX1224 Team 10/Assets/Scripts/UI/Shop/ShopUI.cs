using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    [Header("Reference to Player Data")]
    [SerializeField] private PlayerData playerData;
    [Header("Reference to Player's Inventory")]
    [SerializeField] private Inventory playerInventory;
    [Header("Reference to Audio Player")]
    [SerializeField] private AudioPlayer audioPlayer;

    [Header("Shop Display")]
    // Shop Inventory SO
    [SerializeField] private Shop shop;
    // Shop Icon Prefab
    [SerializeField] private GameObject iconPrefab;
    // Shop Item List
    [SerializeField] private List<GameObject> itemsList = new();

    [Header("Item Details Display")]
    [SerializeField] private TMP_Text itemName;
    [SerializeField] private TMP_Text itemDescription;
    [SerializeField] private Button buyButton;
    [SerializeField] private TMP_Text buyButtonText;

    [Header("Item Box Placements")]
    [SerializeField] private int X_START;
    [SerializeField] private int Y_START;
    [SerializeField] private int X_SPACE_BETWEEN_ITEM;
    [SerializeField] private int NUMBER_OF_COLUMN;
    [SerializeField] private int Y_SPACE_BETWEEN_ITEMS;

    private int prevShopIndex;
    private int currShopIndex;
    Dictionary<ShopSlot, GameObject> itemsDictionary = new();

    void Start()
    {
        CreateDisplay();        
    }

    void Update()
    {
        UpdateDisplay();
    }

    public void CreateDisplay()
    {
        // loop through items in the shop obj
        for (int i = 0; i < shop.Container.Count; i++)
        {
            // Create Item Icon
            CreateItemIcon(i);
        }
        // display default text
        itemName.text = "None";
        itemDescription.text = "Click on an item for more details.";
    }

    private void CreateItemIcon(int i)
    {
        // Instantiate item icons in shop
        var obj = Instantiate(iconPrefab, Vector3.zero, Quaternion.identity, transform);
        // Set iconPrefab SO to its respective item
        obj.GetComponent<ShopUIIcon>().SetItem(shop.Container[i].item);
        // set item icon to its respective icon
        var itemIconObj = obj.transform.GetChild(1).gameObject;
        itemIconObj.GetComponentInChildren<Image>().sprite = shop.Container[i].item.itemIcon;
        // set item icon positions
        obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
        // get the amount of items and display it
        obj.GetComponentInChildren<TextMeshProUGUI>().text = shop.Container[i].amount.ToString("n0");
        // set item price to its respective one
        var itemPriceObj = obj.transform.GetChild(3).gameObject;
        itemPriceObj.GetComponentInChildren<TextMeshProUGUI>().text = shop.Container[i].price.ToString("n0");
        // add item to our Dictionary
        itemsDictionary.Add(shop.Container[i], obj);
        // add item to list
        itemsList.Add(obj);
    }

    public void UpdateDisplay()
    {
        // loop through all items in the shop obj
        for (int i = 0; i < shop.Container.Count; i++)
        {
            // update the quantity after an amount is removed in the dictionary
            if (itemsDictionary.ContainsKey(shop.Container[i]))
            {
                itemsDictionary[shop.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text
                    = shop.Container[i].amount.ToString("n0");
            }
            // update the quantity after an amount is removed in the List
            ShopUIIcon shopUIIcon = itemsList[i].GetComponent<ShopUIIcon>();
            if (shopUIIcon.GetItem() == shop.Container[i].item)
            {
                shopUIIcon.GetComponentInChildren<TextMeshProUGUI>().text = shop.Container[i].amount.ToString("n0");
            }

            // check if a certain icon is selected
            if (shopUIIcon.isSelected)
            {
                // if prevInventoryIndex is, -1 (empty)
                if (prevShopIndex != -1)
                {
                    // make a temporary value to store currInventoryIndex
                    int tempValue = currShopIndex;
                    // set it to prevInventoryIndex
                    prevShopIndex = tempValue;
                }

                // set currInventoryIndex to i in the loop
                currShopIndex = i;

                // deselect the previous icon
                if (currShopIndex != prevShopIndex && prevShopIndex != -1)
                {
                    // select the current icon
                    itemsList[prevShopIndex].GetComponent<ShopUIIcon>().isSelected = false;
                }
                else if (prevShopIndex == -1)
                {
                    // set the description to its respective name and description in the details page
                    prevShopIndex = currShopIndex;
                }

                // check if item is out of stock
                if (shop.Container[i].amount <= 0)
                {
                    shopUIIcon.Select();

                    itemName.text = shop.Container[i].item.name;
                    itemDescription.text = shop.Container[i].item.description;

                    // make the current icon semi-transparent
                    var itemIconObj = itemsList[i].transform.GetChild(1).gameObject;
                    var itemIconImage = itemIconObj.GetComponentInChildren<Image>();
                    var tempColor = itemIconImage.color;
                    tempColor.a = 0.5f;
                    itemIconImage.color = tempColor;
                    // Change button text to Sold Out
                    buyButtonText.text = "Sold Out";
                }
                else
                {
                    shopUIIcon.Select();

                    itemName.text = shop.Container[i].item.name;
                    itemDescription.text = shop.Container[i].item.description;

                    buyButton.gameObject.SetActive(true);

                    if (playerData.coins >= shop.Container[i].price)
                    {
                        buyButtonText.text = "Buy";
                        buyButton.interactable = true;
                    }
                    else
                    {
                        buyButtonText.text = "Not enough money!";
                        buyButton.interactable = false;
                    }
                }
            } else
            {
                // else deselect it
                shopUIIcon.Deselect();
            }
        }
    }

    public void BuyItem()
    {
        int i = currShopIndex;

        // check if the selected item is still in stock and if the player can afford it
        if (shop.Container[i].amount > 0 && playerData.coins >= shop.Container[i].price)
        {
            // Add to Player's inventory
            playerInventory.AddItem(shop.Container[i].item, 1);

            // Deduct the amount from the shop
            shop.Container[i].amount -= 1;

            // deduct from the player's coins
            playerData.coins -= shop.Container[i].price;

            // play buy item SFX
            audioPlayer.PlayClip(1);
        } 
        else
        {
            Debug.Log("Not enough money! / Out of Stock!");
        }
    }

    public Vector3 GetPosition(int i)
    {
        return new Vector3(X_START + (X_SPACE_BETWEEN_ITEM * (i % NUMBER_OF_COLUMN)), Y_START + (-Y_SPACE_BETWEEN_ITEMS * (i / NUMBER_OF_COLUMN)), 0f);
    }
}
