using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyStateMachine StateMachine { get; private set; }
    public EnemyIdleState IdleState { get; private set; }
    public EnemyChaseState ChaseState { get; private set; }
    public EnemyAttackState AttackState { get; private set; }

    [Header("Enemy Base Stats")]
    [SerializeField] private float attack;
    public float moveSpeed;
    public bool runsAway; // does the enemy run from the player?

    [Header("State Change Triggers")]
    [HideInInspector] public bool isAggroed; // idle/patrol => chase
    [HideInInspector] public bool isInAttackRange; // chase => attack

    [Header("Components")]
    public Rigidbody2D rb;
    public Animator enemyAnim;

    private void Awake()
    {
        StateMachine = new EnemyStateMachine();

        IdleState = new EnemyIdleState(this, StateMachine, "idle");
        ChaseState = new EnemyChaseState(this, StateMachine, "walk");
        AttackState = new EnemyAttackState(this, StateMachine, "attack");
    }

    private void Start()
    {
        StateMachine.Init(IdleState);
    }

    private void Update()
    {
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    private void AnimationTrigger()
    {
        StateMachine.CurrentState.AnimationTrigger();
    }

    private void AnimationFinishTrigger()
    {
        StateMachine.CurrentState.AnimationFinishTrigger();
    }
}
