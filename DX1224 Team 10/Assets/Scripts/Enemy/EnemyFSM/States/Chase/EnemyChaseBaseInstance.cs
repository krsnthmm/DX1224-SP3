using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseBaseInstance : ScriptableObject
{
    protected Enemy enemy;
    protected Transform transform;
    protected GameObject gameObject;

    protected Transform playerTransform;

    protected Vector3 dir;

    public virtual void Init(GameObject gameObject, Enemy enemy)
    {
        this.gameObject = gameObject;
        transform = gameObject.transform;
        this.enemy = enemy;

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public virtual void Enter() { }
    public virtual void Exit()
    {
        ResetValues();
    }
    public virtual void LogicUpdate() { }
    public virtual void PhysicsUpdate() { }
    public virtual void ResetValues() { }
}
