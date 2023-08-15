using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    protected Enemy enemy;
    protected EnemyStateMachine sm;

    protected bool isAnimationFinished;

    protected float startTime; // set every time we enter a state

    private string animBoolName;

    public EnemyState(Enemy enemy, EnemyStateMachine sm, string animBoolName)
    {
        this.enemy = enemy;
        this.sm = sm;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        // enter a specific state
        DoChecks();
        startTime = Time.time;
        isAnimationFinished = false;
    }

    public virtual void Exit()
    {
        // exit the current state
    }

    public virtual void LogicUpdate()
    {
        // update logic
    }

    public virtual void PhysicsUpdate()
    {
        // update physics
        DoChecks();
    }

    public virtual void DoChecks()
    {
        // look for ground, look for walls, etc.
    }

    public virtual void AnimationTrigger() { }

    public virtual void AnimationFinishTrigger()
    {
        isAnimationFinished = true;
    }
}
