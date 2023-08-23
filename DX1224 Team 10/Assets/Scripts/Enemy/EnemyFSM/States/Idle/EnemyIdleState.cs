using UnityEngine;

public class EnemyIdleState : EnemyState
{
    private float timer;

    public EnemyIdleState(Enemy enemy, EnemyStateMachine sm, string animBoolName) : base(enemy, sm, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        enemy.IdleBaseInstance.Enter();

        timer = 0f;
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

        timer += Time.deltaTime;

        if (timer > enemy.idleTime)
        {
            if (enemy.isAggroed)
            {
                sm.ChangeState(enemy.ChaseState);
            }
            else if (enemy.isInAttackRange)
            {
                sm.ChangeState(enemy.AttackState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        enemy.IdleBaseInstance.PhysicsUpdate();
    }
}
