using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpitterAttackState : EnemyState
{
    public SpitterAttackState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        _enemy.MovementCompo.StopImmediately();
    }
    public override void Exit()
    {
        base.Exit();
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
