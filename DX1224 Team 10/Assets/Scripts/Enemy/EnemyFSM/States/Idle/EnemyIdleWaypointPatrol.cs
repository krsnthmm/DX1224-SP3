using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Idle - Waypoint Patrol", menuName = "Enemy States/Idle/Waypoint Patrol")]
public class EnemyIdleWaypointPatrol : EnemyIdleBaseInstance
{
    private Vector3 destination;
    private Vector3 dir;
    private int targetIndex;

    private float timer = 0f;

    private bool hasReachedPoint;

    public override void Enter()
    {
        base.Enter();

        destination = enemy.waypoints[targetIndex].transform.position;
        dir = (destination - enemy.transform.position).normalized;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!hasReachedPoint)
        {
            timer = 0f;

            if (Vector3.Distance(destination, enemy.transform.position) <= 0.5f)
            {
                targetIndex++;
                targetIndex %= enemy.waypoints.Count;

                hasReachedPoint = true;

                enemy.enemyAnim.SetBool("idle", true);
                enemy.enemyAnim.SetBool("walk", false);
            }
        }
        else
        {
            timer += Time.deltaTime;

            if (timer >= 1.0f)
            {
                hasReachedPoint = false;

                destination = enemy.waypoints[targetIndex].transform.position;
                dir = (destination - enemy.transform.position).normalized;

                enemy.enemyAnim.SetBool("idle", false);
                enemy.enemyAnim.SetBool("walk", true);

                Debug.Log(timer + " " + destination);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        if (!hasReachedPoint)
        {
            enemy.rb.velocity = dir * enemy.moveSpeed;

            enemy.enemyAnim.SetFloat("x", enemy.rb.velocity.x);
            enemy.enemyAnim.SetFloat("y", enemy.rb.velocity.y);
        }
        else
        {
            enemy.rb.velocity = Vector2.zero;
        }
    }

    public override void ResetValues()
    {
        base.ResetValues();
    }
}
