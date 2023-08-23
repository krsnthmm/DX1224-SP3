using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIManager : MonoBehaviour
{
    [SerializeField] private GameObject inventoryMenu;
    public Inventory inventory;
    
    // Start is called before the first frame update
    void Start()
    {
        inventoryMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenuUIManager.isPaused && !ScrollPopupUIManager.isUp && !ShopUIManager.isShopOpen)
        {
            if (Input.GetKeyDown(KeyCode.E) && !inventoryMenu.activeSelf)
            {
                ShowMenu();
            }
            else if (Input.GetKeyDown(KeyCode.E) && inventoryMenu.activeSelf)
            {
                HideMenu();
            }
        }
    }

    private void ShowMenu()
    {
        inventoryMenu.SetActive(true);
    }
    private void HideMenu()
    {
        inventoryMenu.GetComponent<InventoryUI>().ResetDisplay();
        inventoryMenu.SetActive(false);
    }
}
