using UnityEngine;

public class PlayerRollState : PlayerDefaultState
{
    public PlayerRollState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (_endTriggerCalled)
        {
            _stateMachine.ChangeState(PlayerEnum.Idle);
        }
    }

    public override void Enter()
    {
        base.Enter();
        _player.AgentVFXCompo.ToggleAfterImage(true);
        _player.MovementCompo._isDash = true;
            
        Vector3 position=_player.PlayerInput.Movement;
        Vector3 velocity = position.normalized*_player.dashSpeed;

        _player.MovementCompo.SetDash(velocity);
    }

    public override void Exit()
    {
        _player.MovementCompo._isDash = false;

        _player.MovementCompo.StopAllCoroutines();
        _player.MovementCompo.rbCompo.velocity = Vector2.zero;
        GameManager.Instance.Player.AgentVFXCompo.ToggleAfterImage(false);
        base.Exit();
    }
}