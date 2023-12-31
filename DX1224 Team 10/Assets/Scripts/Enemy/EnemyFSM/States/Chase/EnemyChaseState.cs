﻿public class EnemyChaseState : EnemyState
{
    public EnemyChaseState(Enemy enemy, EnemyStateMachine sm, string animBoolName) : base(enemy, sm, animBoolName)
    {
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

        if (enemy.isInAttackRange)
        {
            sm.ChangeState(enemy.AttackState);
        }
        else if (!enemy.isAggroed)
        {
            sm.ChangeState(enemy.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        enemy.ChaseBaseInstance.PhysicsUpdate();
    }
}
