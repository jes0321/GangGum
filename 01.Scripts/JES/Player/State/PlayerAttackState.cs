using UnityEngine;

public class PlayerAttackState : PlayerSkillState
{
    public PlayerAttackState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }
    
    public override void UpdateState()
    {
        base.UpdateState();
        _player.MovementCompo.StopImmediately(false);

    }
    public override void Enter()
    {
        base.Enter();
        _player.MovementCompo.StopImmediately(false);
    }
    public override void Exit()
    {
        _player.lastAttackTime = Time.time;
        base.Exit();
    }
}