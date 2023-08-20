using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack - Single Ranged Projecile", menuName = "Enemy States/Attack/Single Ranged Projectile")]
public class EnemySingleRangedProjectile : EnemyAttackBaseInstance
{
    public override void Enter()
    {
        base.Enter();

        // direction = destination - origin;
        Vector3 direction = GameObject.FindGameObjectWithTag("Player").transform.position - enemy.projLauncher.transform.position;

        // how many degrees the weapon must be rotated to reach that direction
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // set weapon rotation
        enemy.projLauncher.transform.rotation = Quaternion.Euler(0f, 0f, rotZ - enemy.weaponOffset);

        enemy.rb.velocity = Vector2.zero;

        enemy.enemyAnim.SetFloat("x", direction.x);
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
