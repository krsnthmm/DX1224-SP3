using UnityEngine;

public class EnemyState
{
    protected Enemy enemy;
    protected EnemyStateMachine sm;

    protected bool isAnimEventTriggered;
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
        startTime = Time.time;
        isAnimEventTriggered = false;
        isAnimationFinished = false;

        enemy.enemyAnim.SetBool(animBoolName, true);
    }

    public virtual void Exit()
    {
        // exit the current state
        enemy.enemyAnim.SetBool(animBoolName, false);
    }

    public virtual void LogicUpdate()
    {
        // update logic
    }

    public virtual void PhysicsUpdate()
    {
        // update physics
    }

    public virtual void AnimationTrigger() 
    {
        isAnimEventTriggered = true;
    }

    public virtual void AnimationFinishTrigger()
    {
        isAnimationFinished = true;
    }
}
