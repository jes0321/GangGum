using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2BossEnemy : BossEnemy
{
    public EnemyStateMachine StateMachine;
    protected override void Awake()
    {
        base.Awake();

        StateMachine = new EnemyStateMachine();

        StateMachine.AddState(EnemyEnum.Idle, new Stage1BossIdleState(this, StateMachine, "Idle"));
        StateMachine.AddState(EnemyEnum.Walk, new Stage1BossWalkState(this, StateMachine, "Walk"));
        StateMachine.AddState(EnemyEnum.Dead, new Stage1BossDeadState(this, StateMachine, "Dead"));
        StateMachine.AddState(EnemyEnum.Attack1, new Stage1BossAttack1State(this, StateMachine, "Attack1"));
        StateMachine.AddState(EnemyEnum.Attack2, new Stage1BossAttack1State(this, StateMachine, "Attack2"));
        StateMachine.AddState(EnemyEnum.Attack3, new Stage1BossAttack1State(this, StateMachine, "Attack3"));

        StateMachine.Initialize(EnemyEnum.Idle,this);

    }
    private void Update()
    {
        StateMachine.CurrentState.UpdateState();
        if (targetTrm != null && !StateMachine.CurrentState._stopTriggerCalled)
        {
            HandleSpriteFlip(targetTrm.position);
        }
    }
    public override void AnimationEndTrigger()
    {
        StateMachine.CurrentState.AnimationEndTrigger();
    }
    public override void AnimationStopTrigger()
    {
        base.AnimationStopTrigger();
        StateMachine.CurrentState.AnimationStopTrigger();
    }
    public override void SetDeadState()
    {
        StateMachine.ChangeState(EnemyEnum.Dead);
    }

    public override void SetHitState()
    {
    }
}