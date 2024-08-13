using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerMushEnemy : Enemy,IPoolable
{
    public EnemyStateMachine StateMachine;
    public string PoolName => "DaggerMush";

    public GameObject ObjectPrefab => gameObject;

    protected override void Awake()
    {
        base.Awake();
        StateMachine = new EnemyStateMachine();

        StateMachine.AddState(EnemyEnum.Idle, new GhoulIdleState(this, StateMachine, "Idle"));
        StateMachine.AddState(EnemyEnum.Walk, new GhoulWalkState(this, StateMachine, "Walk"));
        StateMachine.AddState(EnemyEnum.Attack1, new GhoulAttackState(this, StateMachine, "Attack"));
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
}
