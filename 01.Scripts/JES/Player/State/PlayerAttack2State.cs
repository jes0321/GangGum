using UnityEngine;

public class PlayerAttack2State : PlayerAttackState
{
    public PlayerAttack2State(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }
    public override void Exit()
    {
        base.Exit();
        _player.lastAttackTime -= 0.7f;
    }
}