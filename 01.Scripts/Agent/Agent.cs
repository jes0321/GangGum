using System;
using UnityEngine;

public abstract class Agent : MonoBehaviour
{
    //[Header("Settings")]
    //[SerializeField] private float _extraGravity = 30f, _gravityDelay = 0.15f;

    #region Component section
    public AgentMovement MovementCompo { get; protected set; }
    public Animator AnimatorCompo { get; protected set; }
    public Health HealthCompo { get; protected set; }
    #endregion

    public bool IsDead { get; protected set; }

    protected float _timeInAir;

    public event Action OnFlipEvent;

    protected virtual void Awake()
    {
        MovementCompo = GetComponent<AgentMovement>();
        MovementCompo.Initialize(this);
        AnimatorCompo = transform.Find("Visual").GetComponent<Animator>();
        
        HealthCompo = GetComponent<Health>();
        HealthCompo.Initialize(this);
    }

    public abstract void SetDeadState();

    #region Flip Character
    public bool IsFacingRight()
    {
        return Mathf.Approximately(transform.eulerAngles.y, 0);
    }

    public virtual void HandleSpriteFlip(Vector3 targetPosition)
    {
        bool isRight = IsFacingRight();
        if (targetPosition.x < transform.position.x && isRight)
        {
            transform.eulerAngles = new Vector3(0, -180f, 0);
            OnFlipEvent?.Invoke();
        }
        else if (targetPosition.x > transform.position.x && !isRight)
        {
            transform.eulerAngles = Vector3.zero;
            OnFlipEvent?.Invoke();
        }
    }
    #endregion
}
