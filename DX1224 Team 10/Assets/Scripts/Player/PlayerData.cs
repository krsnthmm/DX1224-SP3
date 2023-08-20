using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerData : ScriptableObject
{
    [Header("Default Player Data")]
    [HideInInspector] public float defaultSpeed = 2f;
    [HideInInspector] public float defaultHP = 150f;
    [HideInInspector] public float defaultStamina = 75f;
    [HideInInspector] public int defaultLives = 3;

    [Header("Current Player Data")]
    public int maxLives;
    public int currentLives;

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
    public bool hasCrossEquipped;

    //inventory and items stored 
    //player position 
    //level saved
    //doors opened 
    //maps unlocked

    public float GetMovementSpeed()
    {
        return defaultSpeed;
    }

    public void SetMovementSpeed(float speed)
    {
        defaultSpeed = speed;
    }

    public float GetDashSpeed()
    {
        return dashSpeed;
    }

    public void SetDashDuration(float duration)
    {
        dashDuration = duration;
    }
}
