using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    public EnemyAttackState(Enemy enemy, EnemyStateMachine sm, string animBoolName) : base(enemy, sm, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();

        //if (enemy.isNearWall)
        //{
        //    enemy.Flip();
        //    enemy.isNearWall = false;
        //}
    }

    public override void Enter()
    {
        base.Enter();

        //enemy.AttackBaseInstance.Enter();

        enemy.rb.velocity = Vector2.zero;
    }

    public override void Exit()
    {
        base.Exit();

        //enemy.AttackBaseInstance.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        //enemy.AttackBaseInstance.LogicUpdate();

        //if (!enemy.sfxAudioSrc.isPlaying)
        //{
        //    enemy.sfxAudioSrc.clip = enemy.attackAudioClip;
        //    enemy.sfxAudioSrc.Play();
        //}

        if (isAnimationFinished)
        {
            enemy.StateMachine.ChangeState(enemy.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        //enemy.AttackBaseInstance.PhysicsUpdate();
    }
}
