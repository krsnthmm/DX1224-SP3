using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack - Multi Ranged Projectile", menuName = "Enemy States/Attack/Multi Ranged Projectile")]
public class EnemyMultiRangedProjectile : EnemyAttackBaseInstance
{
    public override void Enter()
    {
        base.Enter();

        float startDirection = enemy.projectileSpread / 2;
        float angleIncrease = enemy.projectileSpread / enemy.numOfProjectiles;

        for (int i = 0; i < enemy.numOfProjectiles; i++)
        {
            float tempDirection = startDirection + angleIncrease * i;

            // set weapon rotation
            enemy.projLauncher.transform.rotation = Quaternion.Euler(0f, 0f, tempDirection - enemy.weaponOffset);
            enemy.SpawnProjectile();
        }

        enemy.rb.velocity = Vector2.zero;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Init(GameObject gameObject, Enemy enemy)
    {
        base.Init(gameObject, enemy);
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
