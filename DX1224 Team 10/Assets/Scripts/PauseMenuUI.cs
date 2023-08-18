using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuUI : MonoBehaviour
{
    public static bool IsPaused = false;

    public GameObject panel;
    public GameObject pauseMenuUI;
    public GameObject settingsMenuUI;

    // Update is called once per frame
    void Update()
    {
        // check for player input
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Pause()
    {
        panel.SetActive(true);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }

    public void Resume()
    {
        if (pauseMenuUI.activeSelf)
        {
            pauseMenuUI.SetActive(false);
        }
        
        if (settingsMenuUI.activeSelf)
        {
            settingsMenuUI.SetActive(false);
        }

        if (panel.activeSelf)
        {
            panel.SetActive(false);
        }

        Time.timeScale = 1f;
        IsPaused = false;
    }

    public void Settings()
    {
        // Open settings UI while paused
        if (IsPaused)
        {
            if (!settingsMenuUI.activeSelf)
            {
                pauseMenuUI.SetActive(false);
                settingsMenuUI.SetActive(true);
            }
            else
            {
                pauseMenuUI.SetActive(true);
                settingsMenuUI.SetActive(false);
            }
        }
    }

    public void ReturnToMenu()
    {
        // Load Menu Scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuScene");
    }
}
