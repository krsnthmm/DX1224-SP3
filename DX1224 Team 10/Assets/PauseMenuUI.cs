using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuUI : MonoBehaviour
{
    public static bool IsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject settingsMenuUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

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
        Time.timeScale = 1f;
        IsPaused = false;
    }

    public void Settings()
    {
        // Open settings UI while paused
        if (IsPaused)
        {
            pauseMenuUI.SetActive(false);
            settingsMenuUI.SetActive(true);
        }
    }

    public void ReturnToMenu()
    {
        // Load Menu Scene
    }
}
