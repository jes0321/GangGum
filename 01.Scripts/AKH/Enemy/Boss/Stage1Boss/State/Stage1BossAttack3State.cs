using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1BossAttack3State : EnemyState
{
    private Stage1BossEnemy _boss;
    public Stage1BossAttack3State(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        _boss = _enemy as Stage1BossEnemy;
    }
    public override void UpdateState()
    {
        base.UpdateState();
        if (_stopTriggerCalled)
        {
            _enemy.AnimatorCompo.speed = 0;
            _enemy.MovementCompo.SetMovement(Mathf.Sign((_enemy.targetTrm.position - _enemy.transform.position).x) * 0.3f);
            _boss.warningZone.SetActive(true);
            _enemy.GetComponent<Health>().enabled = false;
            _enemy.MovementCompo.rbCompo.gravityScale = 0;
            _enemy.DelayCall(3, () =>
            {
                _enemy.GetComponent<Health>().enabled = true;
                _enemy.MovementCompo.rbCompo.gravityScale = 1;
                _enemy.AnimatorCompo.speed = 1;
                _boss.warningZone.SetActive(false);
                _stopTriggerCalled = false;
            });
        }
        if (_endTriggerCalled)
        {
            _stateMachine.ChangeState(EnemyEnum.Walk);
        }
    }
    public override void Exit()
    {
        base.Exit();
        _enemy.lastAttackTime = Time.time;
    }
}
