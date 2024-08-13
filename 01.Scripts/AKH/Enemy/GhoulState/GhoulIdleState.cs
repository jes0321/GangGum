using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhoulIdleState : EnemyState
{
    public GhoulIdleState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
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
            if (!_enemy.havingAttack2)
                _stateMachine.ChangeState(EnemyEnum.Wake);
            else
                _stateMachine.ChangeState(EnemyEnum.Walk);
        }
    }
}
