using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
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

        enemy.IdleBaseInstance.Enter();
    }

    public override void Exit()
    {
        base.Exit();

        enemy.IdleBaseInstance.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        enemy.IdleBaseInstance.LogicUpdate();

        if (enemy.isAggroed)
        {
            sm.ChangeState(enemy.ChaseState);
        }
        else if (enemy.isInAttackRange)
        {
            sm.ChangeState(enemy.AttackState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        enemy.IdleBaseInstance.PhysicsUpdate();
    }
}
