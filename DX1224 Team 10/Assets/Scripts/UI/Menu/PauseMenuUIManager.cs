using UnityEngine;

public class PauseMenuUIManager : MonoBehaviour
{
    public static bool isPaused = false;

    public GameObject panel;
    public GameObject pauseMenuUI;
    public GameObject settingsMenuUI;
    public SceneLoader sceneLoader;

    // Update is called once per frame
    private void Update()
    {
        // check for player input
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GetComponent<AudioPlayer>().PlayClip(0);
            if (isPaused)
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
        isPaused = true;
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
        isPaused = false;
    }

    public void Settings()
    {
        // Open settings UI while paused
        if (isPaused)
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
        isPaused = false;

        // Load Menu Scene
        sceneLoader.LoadScene("MenuScene");
    }
}
