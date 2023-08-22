using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Passcode : MonoBehaviour
{
    private string code = "0853";
    private string codeInput = null;
    private int maxLength = 4;

    [SerializeField] private TMP_Text uiText = null;
    [SerializeField] private GameObject passcodeUI;  // Reference to the UI GameObject
    [SerializeField] private PasscodeTriggerObject passcodeTriggerObj;
    [SerializeField] private GameObject exitDoor;
    [SerializeField] private AudioPlayer audioPlayer;

    private void Start()
    {
        codeInput = "";
        passcodeUI.SetActive(false);
    }

    public void CodeFunction(string numbers)
    {
        if (codeInput.Length < maxLength)
        {
            codeInput += numbers;
            uiText.text = codeInput;
        }
    }

    public void Enter()
    {
        if (codeInput == code)
        {
            passcodeTriggerObj.enteredCorrectCode = true;
            audioPlayer.PlayClip(3);
            Destroy(exitDoor);
        }
        else
        {
            codeInput = "";
            uiText.text = codeInput;
        }

        passcodeUI.SetActive(false);  // Disable the passcode UI GameObject
        Time.timeScale = 1f;
    }

    public void Delete()
    {
        if (codeInput.Length <= 0)
        {
            passcodeUI.SetActive(false);  // Disable the passcode UI GameObject
            Time.timeScale = 1f;
        }
        else if (codeInput.Length > 0)
        {
            codeInput = codeInput.Substring(0, codeInput.Length - 1);
            uiText.text = codeInput;
        }
    }
}
