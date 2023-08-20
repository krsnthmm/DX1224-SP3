using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerData playerData;

    [Header("UI Components")]
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private TMP_Text staminaText;
    [SerializeField] private Slider staminaSlider;
    [SerializeField] private TMP_Text speedText;
    [SerializeField] private TMP_Text coinText;
    [SerializeField] private GameObject crossIcon;

    // Update is called once per frame
    void Update()
    {
        UpdateHealthBar();
        UpdateStaminaBar();
        UpdateCrossIcon();

        speedText.text = "" + playerData.currentSpeed;
        coinText.text = "" + playerData.coins;
    }

    private void UpdateCrossIcon()
    {
        if (playerData.hasCrossEquipped)
            crossIcon.SetActive(true);
        else
            crossIcon.SetActive(false);
    }

    private void UpdateHealthBar()
    {
        healthSlider.value = playerData.currentHP;
        healthSlider.maxValue = playerData.maxHP;
        healthText.text = Mathf.CeilToInt(playerData.currentHP) + " / " + Mathf.CeilToInt(playerData.maxHP);
    }

    private void UpdateStaminaBar()
    {
        staminaSlider.value = playerData.currentStamina;
        staminaSlider.maxValue = playerData.maxStamina;
        staminaText.text = Mathf.CeilToInt(playerData.currentStamina) + " / " + Mathf.CeilToInt(playerData.maxStamina);
    }
}
