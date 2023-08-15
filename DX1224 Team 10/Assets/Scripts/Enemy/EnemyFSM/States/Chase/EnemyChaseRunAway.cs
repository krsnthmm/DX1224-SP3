using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Chase - Run Away", menuName = "Enemy States/Chase/Run Away")]
public class EnemyChaseRunAway : EnemyChaseBaseInstance
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
        dir = (enemy.transform.position - destination).normalized;
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        Vector2 vel = new(dir.x * enemy.moveSpeed, dir.y * enemy.moveSpeed);

        enemy.enemyAnim.SetFloat("x", dir.x);
        enemy.enemyAnim.SetFloat("y", dir.y);

        enemy.rb.velocity = vel;
    }

    public override void ResetValues()
    {
        base.ResetValues();
    }
}
