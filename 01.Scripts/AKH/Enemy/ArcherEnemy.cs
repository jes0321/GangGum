using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherEnemy : Enemy, IPoolable
{
    public EnemyStateMachine StateMachine;
    [SerializeField] private float bulletSpeed = 1.5f; // �Ѿ� �ӵ�

    public GameObject BulletPrefab;
    public Transform FirePosTrm;
    public string PoolName => "Archer";

    public GameObject ObjectPrefab => gameObject;

    protected override void Awake()
    {
        base.Awake();
        FirePosTrm = transform.Find("FirePos");


        StateMachine = new EnemyStateMachine();

        StateMachine.AddState(EnemyEnum.Idle, new SpitterIdleState(this, StateMachine, "Idle"));
        StateMachine.AddState(EnemyEnum.Attack1, new SpitterAttackState(this, StateMachine, "Attack"));
        StateMachine.AddState(EnemyEnum.Dead, new SpitterDeadState(this, StateMachine, "Dead"));
        StateMachine.AddState(EnemyEnum.Walk, new SpitterWalkState(this, StateMachine, "Walk"));
        StateMachine.AddState(EnemyEnum.Hit, new SpitterHitState(this, StateMachine, "Hit"));

        StateMachine.Initialize(EnemyEnum.Idle, this);
    }
    public override void AnimationEndTrigger()
    {
        StateMachine.CurrentState.AnimationEndTrigger();
    }
    private void Update()
    {
        StateMachine.CurrentState.UpdateState();

        if (targetTrm != null && IsDead == false)
            HandleSpriteFlip(targetTrm.position);
    }
    public void ResetItem()
    {
    }
    public override void SetDeadState()
    {
        StateMachine.ChangeState(EnemyEnum.Dead);
    }

    public override void SetHitState()
    {
        StateMachine.ChangeState(EnemyEnum.Hit);
    }
    public override void Attack()
    {
        // �Ѿ� �ν��Ͻ� ����
        Arrow bullet = PoolManager.Instance.Pop("Arrow") as Arrow;
        bullet.transform.position = FirePosTrm.position;
        bullet.damage = attackDamage;
        bullet.knockBackPower = knockbackPower;
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.velocity = (targetTrm.position - transform.position).normalized * bulletSpeed;
    }
}
