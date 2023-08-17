using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIManager : MonoBehaviour
{
    [SerializeField] private GameObject inventoryMenu;
    public Inventory inventory;
    //private int inventoryIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        inventoryMenu.SetActive(false);
        //inventoryIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !inventoryMenu.activeSelf)
        {
            Debug.Log("!");
            ShowMenu();
        }
        else if (Input.GetKeyDown(KeyCode.E) && inventoryMenu.activeSelf)
        {
            Debug.Log("!");
            HideMenu();
        }

        //SelectObject(inventoryIndex);
    }

    //private void SelectObject(int index)
    //{
    //    for (int i = 0; i < inventory.Container.Count; i++)
    //    {
    //        if (index == i)
    //        {
    //            inventory.Container[i].item.isSelected = true;
    //        }
    //        else
    //        {
    //            inventory.Container[i].item.isSelected = false;
    //        }
    //    }
    //}

    private void ShowMenu()
    {
        inventoryMenu.SetActive(true);
    }
    private void HideMenu()
    {
        inventoryMenu.SetActive(false);

    }
}
