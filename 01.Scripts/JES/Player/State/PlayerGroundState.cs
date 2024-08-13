using UnityEngine;

public class PlayerGroundState : PlayerDefaultState
{
    public PlayerGroundState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }
    
    private void HandleGroundChange(bool prev, bool next)
    {
        if(next == false)
        {
            _stateMachine.ChangeState(PlayerEnum.Jump);
        }
    }

    public override void Enter()
    {
        base.Enter();
        _player.MovementCompo.isGround.OnValueChanged += HandleGroundChange;
        HandleGroundChange(false,_player.MovementCompo.isGround.Value);
        
    }
    
    public override void Exit(){
        
        _player.MovementCompo.isGround.OnValueChanged -= HandleGroundChange;
        base.Exit();
    }
}