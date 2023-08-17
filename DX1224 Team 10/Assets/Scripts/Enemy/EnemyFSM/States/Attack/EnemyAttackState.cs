using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    public EnemyAttackState(Enemy enemy, EnemyStateMachine sm, string animBoolName) : base(enemy, sm, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        enemy.AttackBaseInstance.Enter();
    }

    public override void Exit()
    {
        base.Exit();

        enemy.AttackBaseInstance.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        enemy.AttackBaseInstance.LogicUpdate();

        if (isAnimationFinished)
        {
            enemy.StateMachine.ChangeState(enemy.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        enemy.AttackBaseInstance.PhysicsUpdate();
    }
}
