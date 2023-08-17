using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Chase - Chase Player", menuName = "Enemy States/Chase/Chase Player")]
public class EnemyChasePlayer : EnemyChaseBaseInstance
{
    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        destination = GameObject.FindGameObjectWithTag("Player").transform.position;
        dir = (destination - enemy.transform.position).normalized;
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        Vector2 vel = dir * enemy.moveSpeed;

        enemy.enemyAnim.SetFloat("x", dir.x);
        enemy.enemyAnim.SetFloat("y", dir.y);

        enemy.rb.velocity = vel;
    }

    public override void ResetValues()
    {
        base.ResetValues();
    }
}
