using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerData : ScriptableObject
{
    [Header("Default Player Data")]
    [SerializeField] private float defaultSpeed;
    [SerializeField] private float defaultHP;
    [SerializeField] private float defaultStamina;
    [SerializeField] private int defaultLives;

    [Header("Current Player Data")]
    public int maxLives;
    public int currentLives;

    public float maxHP;
    public float currentHP;

    public float maxStamina;
    public float currentStamina;
}
