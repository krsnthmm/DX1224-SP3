using UnityEngine;

[CreateAssetMenu(fileName = "Idle - Static", menuName = "Enemy States/Idle/Static")]
public class EnemyIdleStatic : EnemyIdleBaseInstance
{
    public override void Enter()
    {
        base.Enter();

        enemy.rb.velocity = Vector2.zero;
    }

    public override void Exit()
    {
        base.Exit();
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
