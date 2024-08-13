using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public abstract class Enemy : Agent
{
    public UnityEvent FinalDeadEvent;
    public event Action EnemyFlipEvent;

    [Header("Attack Settings")]
    public bool havingAttack2 = false;
    public float detectRadius;
    public float attackRadius, attackCooldown, knockbackPower;
    public int attackDamage;
    public int attack2Damage;
    public int knockback2Power;
    //public LayerMask whatIsPlayer;
    public ContactFilter2D contactFilter;

    [HideInInspector] public Transform targetTrm = null;
    [HideInInspector] public float lastAttackTime;


    protected int _enemyLayer;
    public bool CanStateChangeable { get; protected set; } = true;

    public DamageCaster DamageCasterCompo { get; protected set; }
    public CapsuleDamageCaster DamageCaster2Compo { get; protected set; }
    private Collider2D[] _colliders;


    protected override void Awake()
    {
        base.Awake();
        DamageCasterCompo = transform.Find("DamageCaster").GetComponent<DamageCaster>();
        if (havingAttack2)
            DamageCaster2Compo = transform.Find("DamageCaster2").GetComponent<CapsuleDamageCaster>();
        _enemyLayer = LayerMask.NameToLayer("Enemy");
        _colliders = new Collider2D[1];
    }

    public Collider2D GetPlayerInRange()
    {
        int count = Physics2D.OverlapCircle(transform.position, detectRadius, contactFilter, _colliders);

        return count > 0 ? _colliders[0] : null;
    }


    public abstract void AnimationEndTrigger();

    public virtual void AnimationStopTrigger()
    {

    }

    public void SetDead(bool value)
    {
        IsDead = value;
        CanStateChangeable = !value;
    }

    //상속받은 다른 적들이 공격방식을 다르게 만들 수도 있으니

    public Coroutine DelayCall(float time, Action CallbackAction)
    {
        return StartCoroutine(DelayCoroutine(time, CallbackAction));
    }

    private IEnumerator DelayCoroutine(float time, Action CallbackAction)
    {
        yield return new WaitForSeconds(time);
        CallbackAction?.Invoke();
    }
    public abstract void SetHitState();
    public virtual void Attack()
    {
        DamageCasterCompo.CastDamage(attackDamage, knockbackPower);
    }
    public virtual void Attack2()
    {
        DamageCaster2Compo.CastDamage(attack2Damage, knockback2Power);
    }
    public override void HandleSpriteFlip(Vector3 targetPosition)
    {
        bool isRight = IsFacingRight();
        if (targetPosition.x < transform.position.x && isRight)
        {
            DelayCall(0.25f, () =>
            {
                EnemyFlipEvent?.Invoke();
                transform.eulerAngles = new Vector3(0, -180f, 0);
            });
        }
        else if (targetPosition.x > transform.position.x && !isRight)
        {
            DelayCall(0.25f, () =>
            {
                EnemyFlipEvent?.Invoke();
                transform.eulerAngles = Vector3.zero;
            });
        }
    }
#if UNITY_EDITOR
    protected virtual void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
        Gizmos.color = Color.white;
    }

#endif
}
