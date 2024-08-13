using UnityEngine;

public class EnemyAnimationTrigger : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    private void AnimationEndTrigger()
    {
        _enemy.AnimationEndTrigger();
    }

    private void AnimationAttackTrigger()
    {
        _enemy.Attack();
    }
    private void AnimationAttack2Trigger()
    {
        _enemy.Attack2();
    }
    private void AnimationAttack3Trigger()
    {
        ((BossEnemy)_enemy).Attack3();
    }
    private void AnimationAttack4Trigger()
    {
        ((Stage3Boss)_enemy).Attack4();
    }
    private void AnimationStopTrigger()
    {
        _enemy.AnimationStopTrigger();
    }
}
