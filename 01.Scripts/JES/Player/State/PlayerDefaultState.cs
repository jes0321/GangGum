using UnityEngine;

public abstract class PlayerDefaultState : PlayerState
{
    protected PlayerDefaultState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    

    public override void UpdateState()
    {
        base.UpdateState();
   
        if(_player.comboCount<=0) return;
        
        ComboResetTimer();
    }

    private void ComboResetTimer()
    {
        if (_player.lastAttackTime + 0.7 < Time.time)
        {
            _player.comboCount = 0;
            _player.attackCoolDown = _player.damageData.attackCooldown;
            _player.lastAttackTime = Time.time;
        }
    }
}