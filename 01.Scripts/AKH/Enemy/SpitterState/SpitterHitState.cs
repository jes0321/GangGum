using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpitterHitState : EnemyState
{
    public SpitterHitState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }
    public override void UpdateState()
    {
        base.UpdateState();
        if (_endTriggerCalled)
        {
            _stateMachine.ChangeState(EnemyEnum.Idle);
        }
    }
}