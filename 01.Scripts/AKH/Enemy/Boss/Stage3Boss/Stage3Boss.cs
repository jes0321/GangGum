using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3Boss : Stage2BossEnemy
{
    public CapsuleDamageCaster damageCaster;
    public CapsuleDamageCaster damageCaster1;
    public CapsuleDamageCaster damageCaster2;
    public CapsuleDamageCaster damageCaster3;
    public override void Attack3()
    {
        damageCaster.CastDamage(attack3Damage, attack3Knockback);
        damageCaster1.CastDamage(attack3Damage, attack3Knockback);
    }
    public void Attack4()
    {
        damageCaster2.CastDamage(attack3Damage, attack3Knockback);
        damageCaster3.CastDamage(attack3Damage, attack3Knockback);
    }
    private void Update()
    {
        StateMachine.CurrentState.UpdateState();
        if (targetTrm != null && !StateMachine.CurrentState._stopTriggerCalled)
        {
            HandleSpriteFlip(targetTrm.position);
        }
    }
    public override void AnimationEndTrigger()
    {
        base.AnimationEndTrigger();
    }
    public override void AnimationStopTrigger()
    {
        base.AnimationStopTrigger();
    }
    public override void SetDeadState()
    {
        base.SetDeadState();
    }

    public override void SetHitState()
    {
    }
}
