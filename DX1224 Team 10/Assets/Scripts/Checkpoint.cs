using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using TMPro;

public class Checkpoint : MonoBehaviour
{
    public GameObject checkpointUI;
    public GameObject interactablePrompt;
    private bool playerInRange;

    public Button Lvl2;
    public Button Lvl3;
    public Button Lvl4;
    public Button Lvl5;
    public Button Lvl6;
    public Button Lvl7;
    public Button Lvl8;
    public Button Lvl9;
    public Button Lvl10;

    void Start()
    {
        checkpointUI.SetActive(false);
        Lvl2.interactable = false;
        Lvl3.interactable = false;
        Lvl4.interactable = false;
        Lvl5.interactable = false;
        Lvl6.interactable = false;
        Lvl7.interactable = false;
        Lvl8.interactable = false;
        Lvl9.interactable = false;
        Lvl10.interactable = false;
    }

    void Update()
    {
        if (!PauseMenuUIManager.IsPaused && playerInRange && Input.GetKey(KeyCode.F))
        {
            ToggleCheckpointUI(true);
        }

        //GameObject checkpointpos = GameObject.FindGameObjectWithTag("Checkpoint");
        //checkpointpos.transform.position = gameObject.transform.position;

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (PlayerPrefs.HasKey("sceneLoaded"))
        {
            string boolContainer = PlayerPrefs.GetString("sceneLoaded");

            if (boolContainer.ToLower() == "true" && player != null)
            {
                player.transform.position = gameObject.transform.position;
                PlayerPrefs.SetString("sceneLoaded", "false");
            }
        }

        if (PlayerPrefs.HasKey("CP2Unlocked"))
        {
            string boolContainer = PlayerPrefs.GetString("CP2Unlocked");

            if (boolContainer.ToLower() == "true")
            {
                Lvl2.interactable = true;
            }
        }

        if (PlayerPrefs.HasKey("CP3Unlocked"))
        {
            string boolContainer = PlayerPrefs.GetString("CP3Unlocked");

            if (boolContainer.ToLower() == "true")
            {
                Lvl3.interactable = true;
            }
        }

        if (PlayerPrefs.HasKey("CP4Unlocked"))
        {
            string boolContainer = PlayerPrefs.GetString("CP4Unlocked");

            if (boolContainer.ToLower() == "true")
            {
                Lvl4.interactable = true;
            }
        }

        if (PlayerPrefs.HasKey("CP5Unlocked"))
        {
            string boolContainer = PlayerPrefs.GetString("CP5Unlocked");

            if (boolContainer.ToLower() == "true")
            {
                Lvl5.interactable = true;
            }
        }

        if (PlayerPrefs.HasKey("CP6Unlocked"))
        {
            string boolContainer = PlayerPrefs.GetString("CP6Unlocked");

            if (boolContainer.ToLower() == "true")
            {
                Lvl6.interactable = true;
            }
        }

        if (PlayerPrefs.HasKey("CP7Unlocked"))
        {
            string boolContainer = PlayerPrefs.GetString("CP7Unlocked");

            if (boolContainer.ToLower() == "true")
            {
                Lvl7.interactable = true;
            }
        }

        if (PlayerPrefs.HasKey("CP8Unlocked"))
        {
            string boolContainer = PlayerPrefs.GetString("CP8Unlocked");

            if (boolContainer.ToLower() == "true")
            {
                Lvl8.interactable = true;
            }
        }

        if (PlayerPrefs.HasKey("CP9Unlocked"))
        {
            string boolContainer = PlayerPrefs.GetString("CP9Unlocked");

            if (boolContainer.ToLower() == "true")
            {
                Lvl9.interactable = true;
            }
        }

        if (PlayerPrefs.HasKey("CP10Unlocked"))
        {
            string boolContainer = PlayerPrefs.GetString("CP10Unlocked");

            if (boolContainer.ToLower() == "true")
            {
                Lvl10.interactable = true;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
            interactablePrompt.SetActive(true);

            if (gameObject.CompareTag("CP2"))
            {
                PlayerPrefs.SetString("CP2Unlocked", "true");
            }

            else if (gameObject.CompareTag("CP3"))
            {
                PlayerPrefs.SetString("CP3Unlocked", "true");
            }

            else if (gameObject.CompareTag("CP4"))
            {
                PlayerPrefs.SetString("CP4Unlocked", "true");
            }

            else if (gameObject.CompareTag("CP5"))
            {
                PlayerPrefs.SetString("CP5Unlocked", "true");
            }

            else if (gameObject.CompareTag("CP6"))
            {
                PlayerPrefs.SetString("CP6Unlocked", "true");
            }

            else if (gameObject.CompareTag("CP7"))
            {
                PlayerPrefs.SetString("CP7Unlocked", "true");
            }

            else if (gameObject.CompareTag("CP8"))
            {
                PlayerPrefs.SetString("CP8Unlocked", "true");
            }

            else if (gameObject.CompareTag("CP9"))
            {
                PlayerPrefs.SetString("CP9Unlocked", "true");
            }

            else if (gameObject.CompareTag("CP10"))
            {
                PlayerPrefs.SetString("CP10Unlocked", "true");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
            ToggleCheckpointUI(false);
            interactablePrompt.SetActive(false);
        }
    }

    public void ToggleCheckpointUI(bool b)
    {
        checkpointUI.SetActive(b);
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneRoutine(sceneName));
    }

    IEnumerator LoadSceneRoutine(string sceneName)
    {
        AsyncOperationHandle op = Addressables.LoadSceneAsync(sceneName);

        while (!op.IsDone)
        {
            float PercentComplete = Mathf.Clamp01(op.PercentComplete / .9f);
            PlayerPrefs.SetString("sceneLoaded", "true");
            yield return null;
        }
        
    }
}
