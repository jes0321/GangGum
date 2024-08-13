using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState
{
    protected Enemy _enemy;
    protected EnemyStateMachine _stateMachine;

    public int _animBoolHash { protected set; get; }
    protected bool _endTriggerCalled;
    public bool _stopTriggerCalled { protected set; get; }

    public EnemyState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName)
    {
        _enemy = enemy;
        _stateMachine = stateMachine;
        _animBoolHash = Animator.StringToHash(animBoolName);
    }

    public virtual void UpdateState()
    {

    }

    public virtual void Enter()
    {
        _enemy.AnimatorCompo.SetBool(_animBoolHash, true);
        _stopTriggerCalled = false;
        _endTriggerCalled = false;
    }

    public virtual void Exit()
    {
        _enemy.AnimatorCompo.SetBool(_animBoolHash, false);
    }

    public void AnimationEndTrigger()
    {
        _endTriggerCalled = true;
    }
    public void AnimationStopTrigger()
    {
        _stopTriggerCalled = true;
    }

}
