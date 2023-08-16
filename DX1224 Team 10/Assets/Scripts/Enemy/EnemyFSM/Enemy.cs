using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyIdleBaseInstance IdleBase;
    [SerializeField] private EnemyChaseBaseInstance ChaseBase;
    [SerializeField] private EnemyAttackBaseInstance AttackBase;

    public EnemyStateMachine StateMachine { get; private set; }
    public EnemyIdleState IdleState { get; private set; }
    public EnemyChaseState ChaseState { get; private set; }
    public EnemyAttackState AttackState { get; private set; }

    public EnemyIdleBaseInstance IdleBaseInstance { get; set; }
    public EnemyChaseBaseInstance ChaseBaseInstance { get; set; }
    public EnemyAttackBaseInstance AttackBaseInstance { get; set; }

    [Header("Enemy Base Stats")]
    [SerializeField] private int attack;
    public float moveSpeed;
    public bool runsAway; // does the enemy run from the player?
    public float thrust;
    public float knockbackTime;

    [Header("State Change Triggers")]
    [HideInInspector] public bool isAggroed; // idle/patrol => chase
    [HideInInspector] public bool isInAttackRange; // chase => attack

    [Header("Components")]
    public Rigidbody2D rb;
    public Animator enemyAnim;
    public Seeker seeker;
    public Transform aggroCheck;
    public Transform attackRangeCheck;

    [Header("Ranged Variables")]
    public GameObject projLauncher;
    public GameObject projPrefab;
    public float weaponOffset;

    public LayerMask whatIsPlayer;

    private void Awake()
    {
        IdleBaseInstance = Instantiate(IdleBase);
        ChaseBaseInstance = Instantiate(ChaseBase);
        AttackBaseInstance = Instantiate(AttackBase);

        StateMachine = new EnemyStateMachine();

        IdleState = new EnemyIdleState(this, StateMachine, "idle");
        ChaseState = new EnemyChaseState(this, StateMachine, "walk");
        AttackState = new EnemyAttackState(this, StateMachine, "attack");
    }

    private void Start()
    {
        IdleBaseInstance.Init(gameObject, this);
        ChaseBaseInstance.Init(gameObject, this);
        AttackBaseInstance.Init(gameObject, this);

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

    public void SpawnProjectile()
    {
        Instantiate(projPrefab, projLauncher.transform.position, projLauncher.transform.rotation);
    }

    public void Knockback() 
    {
        Collider2D target = Physics2D.OverlapCircle(attackRangeCheck.position, attackRangeCheck.GetComponent<CircleCollider2D>().radius, whatIsPlayer);
        if (target != null)
        {
            PlayerController player = target.GetComponent<PlayerController>();
            player.knockedBack = true;

            Rigidbody2D playerRb = target.GetComponent<Rigidbody2D>();
            if (playerRb != null) 
            {
                Vector2 direction = (target.transform.position - transform.position).normalized * thrust;
                playerRb.AddForce(direction, ForceMode2D.Impulse);
                StartCoroutine(KnockbackCo(playerRb));
            }
        }
    }

    private IEnumerator KnockbackCo(Rigidbody2D target) 
    {
        PlayerController player = target.GetComponent<PlayerController>();

        if (target != null) 
        {

            yield return new WaitForSeconds(knockbackTime);
            target.velocity = Vector2.zero;
            player.knockedBack = false;
        }
    }
}
