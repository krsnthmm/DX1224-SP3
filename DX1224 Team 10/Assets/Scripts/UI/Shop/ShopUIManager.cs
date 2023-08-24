using UnityEngine;

public class ShopUIManager : MonoBehaviour
{
    public static bool isShopOpen = false;

    [SerializeField] private GameObject shopUI;

    // Update is called once per frame
    void Update()
    {
        if (isShopOpen)
        {
            OpenShop();

            // prevent audio from playing when it isn't meant to
            shopUI.GetComponent<AudioSource>().Stop();
        }
        else
        {
            CloseShop();
        }
    }

    private void OpenShop()
    {
        shopUI.SetActive(true);
        Time.timeScale = 0f;
    }

    private void CloseShop()
    {
        shopUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OnCloseButtonClick()
    {
        isShopOpen = false;
    }
}
