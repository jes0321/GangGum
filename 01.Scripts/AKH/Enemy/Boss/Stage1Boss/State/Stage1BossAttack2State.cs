using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Stage1BossAttack2State : EnemyState
{
    private bool _done = false;
    public Stage1BossAttack2State(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }
    private Stage1BossEnemy _boss;
    public override void Enter()
    {
        base.Enter();
        _done = false;
        _enemy.MovementCompo.StopImmediately();
        _boss = _enemy as Stage1BossEnemy;
    }
    public override void Exit()
    {
        base.Exit();
        _stopTriggerCalled = false;
        _enemy.lastAttackTime = Time.time;
    }
    public override void UpdateState()
    {
        base.UpdateState();
        if (_stopTriggerCalled && !_done)
        {
            GameObject energy = _boss.transform.Find("Energy").gameObject;
            _enemy.AnimatorCompo.speed = 0;
            _boss.effectPrefab.SetActive(true);
            _enemy.DelayCall(2, () =>
            {
                _boss.effectPrefab.SetActive(false);
                energy.gameObject.SetActive(true);
                _enemy.AnimatorCompo.speed = 1;
            });
            _done = true;
        }
        if (_endTriggerCalled)
        {
            _stateMachine.ChangeState(EnemyEnum.Walk);
        }
    }
}
