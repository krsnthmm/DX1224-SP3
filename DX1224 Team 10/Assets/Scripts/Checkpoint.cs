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

    public bool Lvl2Unlocked;
    public bool Lvl3Unlocked;
    public bool Lvl4Unlocked;
    public bool Lvl5Unlocked;
    public bool Lvl6Unlocked;
    public bool Lvl7Unlocked;
    public bool Lvl8Unlocked;
    public bool Lvl9Unlocked;
    public bool Lvl10Unlocked;

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

        if (playerInRange && Input.GetKey(KeyCode.F))
        {
            checkpointUI.SetActive(true);
        }

        GameObject checkpointpos = GameObject.FindGameObjectWithTag("Checkpoint");
        checkpointpos.transform.position = gameObject.transform.position;

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (PlayerPrefs.HasKey("sceneLoaded"))
        {
            string boolContainer = PlayerPrefs.GetString("sceneLoaded");

            if (boolContainer.ToLower() == "true" && player != null)
            {
                player.transform.position = checkpointpos.transform.position;
                PlayerPrefs.SetString("sceneLoaded", "false");
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
            if (gameObject.CompareTag("CP1"))
            {
                //checkpointUnlocked = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
            checkpointUI.SetActive(false);
        }
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
