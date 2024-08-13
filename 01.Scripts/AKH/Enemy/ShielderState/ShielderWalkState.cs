using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShielderWalkState : EnemyState
{
    public ShielderWalkState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }
    public override void UpdateState()
    {
        base.UpdateState();
        Vector3 direction = _enemy.targetTrm.position - _enemy.transform.position;
        float distance = direction.magnitude;
        if (CheckChangeToIdle(distance)) return;
        _enemy.MovementCompo.SetMovement(Mathf.Sign(direction.x) * 0.5f);
        if (CheckAttackAttempt(distance)) return;
        if(CheckAttack2Attempt(distance)) return;
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
    private bool CheckAttack2Attempt(float distance)
    {
        if(distance<((ShielderEnemy)_enemy).attack2Radius && _enemy.lastAttackTime + _enemy.attackCooldown < Time.time)
        {
            _stateMachine.ChangeState(EnemyEnum.Attack2);
            return true;
        }
        return false;
    }
}
