using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[CreateAssetMenu(fileName = "Chase - Run Away", menuName = "Enemy States/Chase/Run Away")]
public class EnemyChaseRunAway : EnemyChaseBaseInstance
{
    public float nextWaypointDistance = 0.1f;

    Path path;
    private int currentWaypoint = 0;
    private bool reachedEndOfPath = false;

    float timer;

    public override void Enter()
    {
        base.Enter();

        enemy.seeker.StartPath((Vector2)playerTransform.position, enemy.rb.position - (Vector2)playerTransform.position, OnPathComplete);
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
                enemy.seeker.StartPath((Vector2)playerTransform.position, enemy.rb.position - (Vector2)playerTransform.position, OnPathComplete);
            }

            timer = 0f;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        if (path == null)
        {
            return;
        }

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        dir = (enemy.rb.position - (Vector2)path.vectorPath[currentWaypoint]).normalized;
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
