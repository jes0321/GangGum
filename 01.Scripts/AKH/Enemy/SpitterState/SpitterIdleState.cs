using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpitterIdleState : EnemyState
{
    public SpitterIdleState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
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
