using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : EnemyState
{
    private Vector3 destination;
    private Vector3 dir;
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

        //enemy.ChaseBaseInstance.Enter();
    }

    public override void Exit()
    {
        base.Exit();

        //enemy.ChaseBaseInstance.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        //enemy.ChaseBaseInstance.LogicUpdate();

        destination = GameObject.FindGameObjectWithTag("Player").transform.position;
        dir = (destination - enemy.transform.position).normalized;

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

        //enemy.ChaseBaseInstance.PhysicsUpdate();

        Vector2 vel = new(dir.x * enemy.moveSpeed, dir.y * enemy.moveSpeed);

        enemy.enemyAnim.SetFloat("x", dir.x);
        enemy.enemyAnim.SetFloat("y", dir.y);

        enemy.rb.velocity = vel;
    }
}
