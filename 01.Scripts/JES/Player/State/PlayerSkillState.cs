public class PlayerSkillState : PlayerState
{
    public PlayerSkillState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void UpdateState()
    {
        base.UpdateState();
        
        if(_endTriggerCalled)
        {
            _stateMachine.ChangeState(PlayerEnum.Idle);
        }
    }

    public override void Enter()
    {
        base.Enter();
        _player.PlayerInput.controls.Disable();
    }

    public override void Exit()
    {
        _player.PlayerInput.controls.Enable();
        base.Exit();
    }
}