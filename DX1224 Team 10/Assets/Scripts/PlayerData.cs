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
    [SerializeField] private int maxLives;
    public int CurrentLives;

    [SerializeField] private float maxHP;
    public float CurrentHP;

    [SerializeField] private float maxStamina;
    public float CurrentStamina;
}
