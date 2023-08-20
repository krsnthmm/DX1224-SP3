using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[CreateAssetMenu(fileName = "Chase - Chase Player", menuName = "Enemy States/Chase/Chase Player")]
public class EnemyChasePlayer : EnemyChaseBaseInstance
{
    public float nextWaypointDistance = 0.1f;

    Path path;
    private int currentWaypoint = 0;

    float timer;

    public override void Enter()
    {
        base.Enter();

        enemy.seeker.StartPath(enemy.rb.position, playerTransform.position, OnPathComplete);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        timer += Time.deltaTime;

        if (timer >= 0.5f)
        {
            if (enemy.seeker.IsDone())
            {
                enemy.seeker.StartPath(enemy.rb.position, playerTransform.position, OnPathComplete);
            }

            timer = 0f;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        if (path == null || currentWaypoint >= path.vectorPath.Count)
        {
            return;
        }

        dir = ((Vector2)path.vectorPath[currentWaypoint] - enemy.rb.position).normalized;
        enemy.rb.velocity = dir * enemy.moveSpeed;

        enemy.enemyAnim.SetFloat("x", dir.x);
        enemy.enemyAnim.SetFloat("y", dir.y);

        float distance = Vector2.Distance(enemy.rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
    }

    public override void ResetValues()
    {
        base.ResetValues();
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
}
