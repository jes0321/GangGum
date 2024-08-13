using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhoulDeadState : EnemyState
{
    private readonly int _deadLayer = LayerMask.NameToLayer("DeadBody");
    public GhoulDeadState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        _enemy.gameObject.layer = _deadLayer;
        _enemy.MovementCompo.StopImmediately();
        _enemy.SetDead(true);
    }
    public override void UpdateState()
    {
        base.UpdateState();
        if (_endTriggerCalled)
        {
            PoolManager.Instance.Push(_enemy.GetComponent<IPoolable>());
            _enemy.FinalDeadEvent?.Invoke();
        }
    }
}
