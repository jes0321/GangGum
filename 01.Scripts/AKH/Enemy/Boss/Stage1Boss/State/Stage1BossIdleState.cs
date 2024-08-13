using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1BossIdleState : EnemyState
{
    public Stage1BossIdleState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }
    public override void UpdateState()
    {
        base.UpdateState();
        _enemy.MovementCompo.rbCompo.velocity = new Vector2(Random.Range(-1,1),0);
        Collider2D player = _enemy.GetPlayerInRange();
        if (player != null)
        {
            _enemy.targetTrm = player.transform;
            _stateMachine.ChangeState(EnemyEnum.Walk);
        }
    }
}
