using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
    [SerializeField] private float idleTime;
    public EnemyIdleState(Enemy enemy, EnemyStateMachine sm, string animBoolName) : base(enemy, sm, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        idleTime = 0.0f;
        enemy.rb.velocity = Vector2.zero;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        idleTime += Time.deltaTime;

        //if (idleTime >= 1.0f)
        //{
        //    if (enemy.isAggro && !enemy.isNearWall)
        //    {
        //        sm.ChangeState(enemy.ChaseState);
        //    }
        //    else if (enemy.isAttackDist)
        //    {
        //        sm.ChangeState(enemy.AttackState);
        //    }
        //    else
        //    {
        //        sm.ChangeState(enemy.PatrolState);
        //    }
        //}
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
