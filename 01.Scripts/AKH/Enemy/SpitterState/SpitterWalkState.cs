using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpitterWalkState : EnemyState
{
    public SpitterWalkState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }
    public override void UpdateState()
    {
        base.UpdateState();
        Vector3 direction = _enemy.targetTrm.position - _enemy.transform.position;
        float distance = direction.magnitude;
        if (CheckChangeToIdle(distance)) return;
        _enemy.MovementCompo.SetMovement(Mathf.Sign(direction.x) * 0.3f);
        if (CheckAttackAttempt(distance)) return;

    }
    private bool CheckChangeToIdle(float distance)
    {
        if (distance > 3 + _enemy.detectRadius)
        {
            _stateMachine.ChangeState(EnemyEnum.Idle);
            return true;
        }
        return false;
    }

    private bool CheckAttackAttempt(float distance)
    {
        if (distance < _enemy.attackRadius && _enemy.lastAttackTime + _enemy.attackCooldown < Time.time)
        {
            _stateMachine.ChangeState(EnemyEnum.Attack1);
            return true;
        }
        return false;
    }
}
