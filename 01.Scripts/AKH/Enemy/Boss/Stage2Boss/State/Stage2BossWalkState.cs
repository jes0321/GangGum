using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Stage2BossWalkState : EnemyState
{
    public Stage2BossWalkState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
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
            switch (Random.Range(0, 7))
            {
                case 0:
                    _stateMachine.ChangeState(EnemyEnum.Attack2);
                    break;
                case 1:
                    _stateMachine.ChangeState(EnemyEnum.Attack2);
                    break;
                case 2:
                    _stateMachine.ChangeState(EnemyEnum.Attack3);
                    break;
                case 3:
                    _stateMachine.ChangeState(EnemyEnum.Attack1);
                    break;
                case 4:
                    _stateMachine.ChangeState(EnemyEnum.Attack3);
                    break;
                case 5:
                    _stateMachine.ChangeState(EnemyEnum.Attack2);
                    break;
                case 6:
                    _stateMachine.ChangeState(EnemyEnum.Attack1);
                    break;
            }
            return true;
        }
        return false;
    }
}
