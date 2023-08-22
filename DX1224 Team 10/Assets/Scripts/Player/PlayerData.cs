using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerData : ScriptableObject
{
    [Header("Default Player Data")]
    [HideInInspector] public float defaultWalkSpeed = 2f;
    [HideInInspector] public float defaultDashSpeed = 7f;
    [HideInInspector] public float defaultHP = 150f;
    [HideInInspector] public float defaultStamina = 75f;

    [Header("Current Player Data")]
    public float maxStamina;
    public float currentStamina;

    public float maxHP;
    public float currentHP;

    public float coins;
    public float levels;

    public float currentSpeed;
    public float walkSpeed;
    public float dashSpeed;
    public float dashDuration;

    [Header("Other Variables")]
    public float staminaConsume;
    public float staminaRefillRate;
    public float staminaRefillInterval; // number of seconds before stamina is refilled
    public bool hasSpeedBoost;
    public bool hasCrossEquipped;
    public float shieldDuration;

    public Inventory inventory;

    //player position 
    //level saved
    //doors opened 
    //maps unlocked

    public void SetDefaults()
    {
        currentHP = maxHP = defaultHP;
        currentStamina = maxStamina = defaultStamina;
        walkSpeed = defaultWalkSpeed;
        dashSpeed = defaultDashSpeed;

        coins = 0;

        hasSpeedBoost = false;
        hasCrossEquipped = false;

        inventory.Container = new();
    }
}
