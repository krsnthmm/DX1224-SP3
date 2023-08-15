using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRangeCheck : MonoBehaviour
{
    private Enemy enemy;
    private void Awake()
    {
        enemy = GetComponentInParent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enemy.isInAttackRange = true;
            Debug.Log("!!!");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enemy.isInAttackRange = false;
            Debug.Log("!!!");
        }
    }
}
