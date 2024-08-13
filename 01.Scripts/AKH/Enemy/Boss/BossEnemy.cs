using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BossEnemy : Enemy
{
    public DamageCaster damageCaster3Compo;
    [SerializeField] protected int attack3Damage;
    [SerializeField] protected float attack3Knockback;

    private HealthBar _healthBar;

    protected override void Awake()
    {
        base.Awake();
        damageCaster3Compo = transform.Find("DamageCaster3").GetComponent<DamageCaster>();
        _healthBar = transform.Find("GageBackground").GetComponentInChildren<HealthBar>();
        EnemyFlipEvent += _healthBar.Endure;
    }
    public void EarnMoney(int money)
    {
        GameManager.Instance.coin.count = money;
    }
    public virtual void Attack3()
    {
        damageCaster3Compo.CastDamage(attack3Damage, attack3Knockback);
    }
    public abstract override void AnimationEndTrigger();

    public abstract override void SetDeadState();

    public abstract override void SetHitState();
}
