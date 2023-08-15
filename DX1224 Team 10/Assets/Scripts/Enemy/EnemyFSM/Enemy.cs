using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyStateMachine StateMachine { get; private set; }
    public EnemyIdleState IdleState { get; private set; }
    //public EnemyChaseState ChaseState { get; private set; }
    //public EnemyAttackState AttackState { get; private set; }

    [Header("Enemy Base Stats")]
    [SerializeField] private float atk;
    [SerializeField] private float moveSpeed;

    [Header("State Change Triggers")]
    [HideInInspector] public bool isAggroed; // idle/patrol => chase
    [HideInInspector] public bool isInAttackRange; // chase => attack

    [Header("Components")]
    public Rigidbody2D rb;
    public Animator enemyAnim;

    private void Awake()
    {
        StateMachine = new EnemyStateMachine();
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
