using UnityEngine;
using Pathfinding;

[CreateAssetMenu(fileName = "Idle - Waypoint Patrol", menuName = "Enemy States/Idle/Waypoint Patrol")]
public class EnemyIdleWaypointPatrol : EnemyIdleBaseInstance
{
    public float nextWaypointDistance = 0.1f;

    Path path;
    private int currentWaypoint = 0;

    private Vector3 dir;
    private int targetIndex;

    private float idleTimer = 0f;

    private bool isIdle;

    public override void Enter()
    {
        base.Enter();

        enemy.seeker.StartPath(enemy.rb.position, enemy.waypoints[targetIndex].transform.position, OnPathComplete);

        enemy.enemyAnim.SetBool("idle", false);
        enemy.enemyAnim.SetBool("walk", true);
    }

    public override void Exit()
    {
        base.Exit();

        enemy.enemyAnim.SetBool("idle", false);
        enemy.enemyAnim.SetBool("walk", false);

        enemy.rb.velocity = Vector2.zero;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isIdle)
        {
            idleTimer += Time.deltaTime;

            if (idleTimer >= 1.0f)
            {
                isIdle = false;
            }
        }
        else
        {
            idleTimer = 0f;
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        if (isIdle)
        {
            enemy.rb.velocity = Vector2.zero;
        }
        else
        {
            if (path == null)
            {
                return;
            }

            if (currentWaypoint >= path.vectorPath.Count)
            {
                currentWaypoint = 0;

                targetIndex++;
                targetIndex %= enemy.waypoints.Count;

                enemy.seeker.StartPath(enemy.rb.position, enemy.waypoints[targetIndex].transform.position, OnPathComplete);

                isIdle = true;

                enemy.enemyAnim.SetBool("idle", true);
                enemy.enemyAnim.SetBool("walk", false);
            }
            else
            {
                enemy.enemyAnim.SetBool("idle", false);
                enemy.enemyAnim.SetBool("walk", true);
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
