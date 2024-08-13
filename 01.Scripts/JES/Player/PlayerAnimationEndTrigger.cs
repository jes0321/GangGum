using UnityEngine;

public class PlayerAnimationEndTrigger : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void AnimationEndTrigger()
    {
        _player.AnimationEndTrigger();
    }
 
    private void AnimationAttackTrigger()
    {
        _player.Attack();
    }

    private void AnimationSmashTrigger()
    {
        _player.SkillAttack(1);
    }
    private void AnimationSpinTrigger()
    {
        _player.SkillAttack(2);
    }
}