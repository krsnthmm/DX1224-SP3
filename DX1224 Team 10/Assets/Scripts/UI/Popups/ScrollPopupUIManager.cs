using UnityEngine;
using TMPro;

public class ScrollPopupUIManager : MonoBehaviour
{
    [SerializeField] private GameObject scrollPopup;
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

    public void UpdatePopup(string description)
    {
        this.description.text = description;
    }
}
