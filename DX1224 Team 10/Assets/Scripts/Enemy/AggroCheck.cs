using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggroCheck : MonoBehaviour
{
    private Enemy enemy;
    RaycastHit2D raycastHit;

    private void Awake()
    {
        enemy = GetComponentInParent<Enemy>();
        enemy.isAggroed = false;
        enemy.isInAttackRange = false;
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        Vector2 start = enemy.rb.position;
        Vector2 dir = ((Vector2)GameObject.FindGameObjectWithTag("Player").transform.position - enemy.rb.position).normalized;
        float distance = GetComponent<CircleCollider2D>().radius * enemy.transform.localScale.x;

        Debug.DrawRay(start, dir * distance, Color.red);

        raycastHit = Physics2D.Raycast(start, dir, distance, enemy.whatIsPlayer + enemy.whatIsObstacle);

        if (raycastHit.collider != null)
        {
            if (1 << raycastHit.collider.gameObject.layer == enemy.whatIsPlayer.value)
            {
                enemy.isAggroed = true;
            }
            else if (1 << raycastHit.collider.gameObject.layer == enemy.whatIsObstacle.value)
            {
                enemy.isAggroed = false;
                return;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            enemy.isAggroed = false;
        }
    }
}
