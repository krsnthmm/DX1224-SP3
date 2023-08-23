using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private Shop shop;
    public GameObject settingsMenuUI;
    public GameObject mainMenuUI;

    public void NewGame()
    {
        // Create new save data?
        // Open game with new player data
        sceneLoader.LoadScene("LoadingScreen");
        playerData.SetDefaults();
    }

    public void LoadGame()
    {
        // Load previous player data
        // Load game scene
        sceneLoader.LoadScene("LoadingScreen");
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
