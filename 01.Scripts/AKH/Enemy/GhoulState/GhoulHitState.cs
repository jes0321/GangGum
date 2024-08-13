using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhoulHitState : EnemyState
{
    public GhoulHitState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }
    public override void UpdateState()
    {
        base.UpdateState();
        Collider2D player = _enemy.GetPlayerInRange();
        if (_endTriggerCalled)
        {
            if (player == null)
                _stateMachine.ChangeState(EnemyEnum.Idle);
            else
                _stateMachine.ChangeState(EnemyEnum.Walk);

        }
    }
}
