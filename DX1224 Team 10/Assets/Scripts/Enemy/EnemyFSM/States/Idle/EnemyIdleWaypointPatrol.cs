using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Idle - Waypoint Patrol", menuName = "Enemy States/Idle/Waypoint Patrol")]
public class EnemyIdleWaypointPatrol : EnemyIdleBaseInstance
{
    public override void Enter()
    {
        base.Enter();

        enemy.rb.velocity = Vector2.zero;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void ResetValues()
    {
        base.ResetValues();
    }
}
