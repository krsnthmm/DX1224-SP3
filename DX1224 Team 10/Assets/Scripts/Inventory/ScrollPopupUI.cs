using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScrollPopupUI : MonoBehaviour
{
    [SerializeField] private GameObject scrollPopup;
    public TMP_Text title;
    public TMP_Text description;
    public static bool isUp;

    public void ToggleScrollPopup()
    {
        if (!scrollPopup.activeSelf)
        {
            scrollPopup.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            scrollPopup.SetActive(false);
            Time.timeScale = 1f;
        }

        isUp = !isUp;
    }

    public void UpdatePopup(string title, string description)
    {
        this.title.text = title;
        this.description.text = description;
    }
}
