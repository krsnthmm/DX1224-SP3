using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public string mainGameScene;
    public GameObject settingsMenuUI;
    public GameObject mainMenuUI;

    // Start is called before the first frame update
    public void NewGame()
    {
        // Create new save data?
        // Open game with new player data
        SceneManager.LoadScene(mainGameScene);
    }

    public void LoadGame()
    {
        // Load previous player data
        // Load game scene
        SceneManager.LoadScene(mainGameScene);
    }

    // settings UI may not be working on some branches
    // uncomment on main
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
