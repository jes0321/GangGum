using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShielderIdleState : EnemyState
{
    public ShielderIdleState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
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
    }
    public override void UpdateState()
    {
        base.UpdateState();
        Collider2D player = _enemy.GetPlayerInRange();
        if (player != null)
        {
            _enemy.targetTrm = player.transform;
            _stateMachine.ChangeState(EnemyEnum.Walk);
        }
    }
}
