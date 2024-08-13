using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShielderEnemy : Enemy, IPoolable
{
    public EnemyStateMachine StateMachine;
    [SerializeField] private Transform _firePosTrm;
    public float attack2Radius;
    public string PoolName => "Shielder";

    public GameObject ObjectPrefab => gameObject;

    protected override void Awake()
    {
        base.Awake();
        StateMachine = new EnemyStateMachine();

        StateMachine.AddState(EnemyEnum.Idle, new ShielderIdleState(this, StateMachine, "Idle"));
        StateMachine.AddState(EnemyEnum.Walk, new ShielderWalkState(this, StateMachine, "Walk"));
        StateMachine.AddState(EnemyEnum.Attack1, new GhoulAttackState(this, StateMachine, "Attack1"));
        StateMachine.AddState(EnemyEnum.Attack2, new GhoulAttackState(this, StateMachine, "Attack2"));
        StateMachine.AddState(EnemyEnum.Dead, new GhoulDeadState(this, StateMachine, "Dead"));
        StateMachine.AddState(EnemyEnum.Hit, new GhoulHitState(this, StateMachine, "Hit"));

        StateMachine.Initialize(EnemyEnum.Idle, this);
    }
    private void Update()
    {
        StateMachine.CurrentState.UpdateState();

        if (targetTrm != null && IsDead == false)
            HandleSpriteFlip(targetTrm.position);
    }
    public override void AnimationEndTrigger()
    {
        StateMachine.CurrentState.AnimationEndTrigger();
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
    public override void Attack2()
    {
        var bullet = PoolManager.Instance.Pop("ShielderBullet") as ShielderBullet;
        bullet.transform.position = _firePosTrm.position;
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.rotation.y==0?8:-8,0);
    }
#if UNITY_EDITOR
    protected override void OnDrawGizmosSelected()
    {
        base.OnDrawGizmosSelected();
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attack2Radius);
    }
#endif
}
