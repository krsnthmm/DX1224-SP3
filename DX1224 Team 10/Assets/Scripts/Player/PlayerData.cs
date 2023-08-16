using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerData : ScriptableObject
{
    [Header("Default Player Data")]
    [HideInInspector] public float defaultSpeed =1f;
    [HideInInspector] public float defaultHP;
    [HideInInspector] public float maxStamina=100f;
    [HideInInspector] public float defaultStamina;
    [HideInInspector] public int defaultLives;

    [Header("Current Player Data")]
    public int maxLives;
    public int currentLives;

    public float maxHP;
    public float currentHP;

    [HideInInspector] public float currentSpeed;
    [HideInInspector] public float dashSpeed;
    [HideInInspector] public float dashDuration;
    [HideInInspector] public float staminaConsume;
    [HideInInspector] public float staminaRefillRate=25f;
    [HideInInspector] public float staminaRefillInterval = 15f;

    public float maxStamina;
    public float currentStamina;

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

