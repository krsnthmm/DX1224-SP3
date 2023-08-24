using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private Shop shop;
    public GameObject settingsMenuUI;
    public GameObject mainMenuUI;

    public void PlayGame()
    {
        // Open game with new player data
        sceneLoader.LoadScene("LoadingScreen");
        playerData.SetDefaults();
        shop.SetDefaults();

        // set timeScale to 1
        // this is so that the scene to load isn't paused after returning to the main menu from the pause menu
        Time.timeScale = 1f;
    }

    public void Settings()
    {
        Debug.Log("!");
        //check if the settings menu is active
        if (!settingsMenuUI.activeSelf)
        {
            mainMenuUI.SetActive(false);
            settingsMenuUI.SetActive(true);
        }
        else if (settingsMenuUI.activeSelf)
        {
            settingsMenuUI.SetActive(false);
            mainMenuUI.SetActive(true);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
