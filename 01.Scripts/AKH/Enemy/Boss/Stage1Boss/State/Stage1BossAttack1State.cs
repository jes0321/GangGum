using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1BossAttack1State : EnemyState
{
    public Stage1BossAttack1State(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        _stopTriggerCalled = true;
        _enemy.MovementCompo.StopImmediately();
    }
    public override void Exit()
    {
        base.Exit();
        _stopTriggerCalled = false;
        _enemy.lastAttackTime = Time.time;
    }
    public override void UpdateState()
    {
        base.UpdateState();
        if (_endTriggerCalled)
        {
            _stateMachine.ChangeState(EnemyEnum.Walk);
        }
    }
}
