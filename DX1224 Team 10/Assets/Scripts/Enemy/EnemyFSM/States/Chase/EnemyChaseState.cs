using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : EnemyState
{
    public EnemyChaseState(Enemy enemy, EnemyStateMachine sm, string animBoolName) : base(enemy, sm, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        enemy.ChaseBaseInstance.Enter();
    }

    public override void Exit()
    {
        base.Exit();

        enemy.ChaseBaseInstance.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        enemy.ChaseBaseInstance.LogicUpdate();

        if (!enemy.runsAway)
        {
            if (enemy.isInAttackRange)
            {
                sm.ChangeState(enemy.AttackState);
            }
            else if (!enemy.isAggroed)
            {
                sm.ChangeState(enemy.IdleState);
            }
        }
        else
        {
            if (enemy.isAggroed)
            {
                sm.ChangeState(enemy.AttackState);
            }
            else
            {
                sm.ChangeState(enemy.IdleState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        enemy.ChaseBaseInstance.PhysicsUpdate();
    }
}
