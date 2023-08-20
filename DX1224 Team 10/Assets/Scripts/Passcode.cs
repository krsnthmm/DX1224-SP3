using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Passcode : MonoBehaviour
{
    string Code = "0853";
    string Nr = null;
    int NrIndex = 0;
    string alpha;
    public TMP_Text UiText = null;
    public GameObject passcodeUI;  // Reference to the UI GameObject

    public InteractiveObject interactiveObject;
    private bool isPromptState = false;

    private void Start()
    {
        passcodeUI.SetActive(false);
    }
    public void CodeFunction(string Numbers)
    {
        NrIndex++;
        Nr = Nr + Numbers;
        UiText.text = Nr;
    }

    public void Enter()
    {
        if (Nr == Code)
        {
            Debug.Log("Entered");
            passcodeUI.SetActive(false);  // Disable the passcode UI GameObject

            interactiveObject.CompletePrompt();
            Time.timeScale = 1f;

            SceneManager.LoadScene(1);
        }
    }

    public void Delete()
    {
        NrIndex++;
        Nr = null;
        UiText.text = Nr;
        passcodeUI.SetActive(false);
        interactiveObject.CompletePrompt();
    }
}
