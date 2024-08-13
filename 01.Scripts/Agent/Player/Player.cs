using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : Agent
{
    public PlayerStateMachine stateMachine;
    public bool CanStateChangeable { get; private set; } = true;

    public UnityEvent JumpEvent;
    public UnityEvent RollEvent;
    public UnityEvent AttackEvent;
    [field:SerializeField] public InputReader PlayerInput { get; private set; }
    
    [Header("Normal Attack")] 
    private int _damage;
    private float _knockPower;
    public float attackCoolDown;
    public float lastAttackTime;

    [Header("Combo Attack")] 
    public PlayerDamageSO damageData;
    public List<PlayerDamageSO> damageDataList;
    public int comboCount= 0;

    public float dashSpeed = 30f;
    
    #region Component Regeion
    public AgentVFX AgentVFXCompo { get; private set; }
    public CapsuleDamageCaster DamageCasterCompo { get; private set; }

    #endregion


    protected override void Awake()
    {
        base.Awake();
        stateMachine = new PlayerStateMachine(); 
        
        stateMachine.AddState(PlayerEnum.Idle,new PlayerIdleState(this,stateMachine,"Idle"));
        stateMachine.AddState(PlayerEnum.Run,new PlayerRunState(this,stateMachine,"Run"));
        stateMachine.AddState(PlayerEnum.Jump,new PlayerJumpState(this,stateMachine,"Jump"));
        stateMachine.AddState(PlayerEnum.Fall,new PlayerFallState(this,stateMachine,"Fall"));
        stateMachine.AddState(PlayerEnum.Attack1,new PlayerAttack1State(this,stateMachine,"Attack1"));
        stateMachine.AddState(PlayerEnum.Attack2,new PlayerAttack2State(this,stateMachine,"Attack2"));
        stateMachine.AddState(PlayerEnum.Hit,new PlayerHitState(this,stateMachine,"Hit"));
        stateMachine.AddState(PlayerEnum.Roll,new PlayerRollState(this,stateMachine,"Roll"));
        stateMachine.AddState(PlayerEnum.Smash,new PlayerSmashState(this,stateMachine,"Smash"));
        stateMachine.AddState(PlayerEnum.Spin,new PlayerSpinState(this,stateMachine,"Spin"));
        stateMachine.AddState(PlayerEnum.Dead,new PlayerDeadState(this,stateMachine,"Dead"));
        
        stateMachine.Initialize(PlayerEnum.Idle,this);
        
        PlayerInput.JumpKeyEvent += HandleJumpKeyEvent;
        PlayerInput.DashKeyEvent += HandleDashKeyEvent;
        PlayerInput.SmashSkillKeyEvent += HandleSmashSkillKeyEvent;
        PlayerInput.SpinSkillKeyEvent += HandleSpinSkillKeyEvent;
        PlayerInput.NormalAttackKeyEvent += HandleAttackEvent;
        
        DamageCasterCompo = transform.Find("DamageCaster").GetComponent<CapsuleDamageCaster>();

        AgentVFXCompo = transform.Find("AgentVFX").GetComponent<AgentVFX>();
        AgentVFXCompo.Initalize(this);
        
        PlayerInput.controls.Enable();
    }

    #region HandlingEvent
    private void HandleAttackEvent()
    {
        if (lastAttackTime + attackCoolDown < Time.time)
        {
            stateMachine.ChangeState((PlayerEnum)comboCount);
        }
    }
    
    private void HandleSpinSkillKeyEvent()
    {
        if (SkillManager.Instance.GetSkill<SpinSkill>().AttemptUseSkill())
        {
            stateMachine.ChangeState(PlayerEnum.Spin);
        }
    }
    private void HandleSmashSkillKeyEvent()
    {
        if (SkillManager.Instance.GetSkill<SmashSkill>().AttemptUseSkill())
        {
            stateMachine.ChangeState(PlayerEnum.Smash);
        }
    }
    private void HandleDashKeyEvent()
    {
        if (SkillManager.Instance.GetSkill<DashSkill>().AttemptUseSkill())
        {
            stateMachine.ChangeState(PlayerEnum.Roll);
            RollEvent?.Invoke();
        }
    }
    private void HandleJumpKeyEvent()
    {
        if (MovementCompo.isGround.Value)
        {
            JumpProcess();
        }
    }

    #endregion
    

    public void Attack()
    {
        damageData = damageDataList[0];
        
        attackCoolDown = 0;
        
        AttackSetting();

        comboCount++;
    }

    private void AttackSetting()
    {
        DamageCasterCompo.transform.localPosition = damageData.damagePos;
        DamageCasterCompo.damageRadius = damageData.damageRadius;

        _damage = damageData.damage;
        _knockPower = damageData.knockPower;
        AttackEvent?.Invoke();
        DamageCasterCompo.CastDamage(_damage, _knockPower);
    }


    public void SkillAttack(int index)
    {
        damageData = damageDataList[index];

        AttackSetting();
    }

    private void OnDestroy()
    {
        PlayerInput.NormalAttackKeyEvent -= HandleAttackEvent;
        PlayerInput.JumpKeyEvent -= HandleJumpKeyEvent;
        PlayerInput.DashKeyEvent -= HandleDashKeyEvent;
        PlayerInput.SmashSkillKeyEvent -= HandleSmashSkillKeyEvent;
        PlayerInput.SpinSkillKeyEvent -= HandleSpinSkillKeyEvent;
    }
    private void JumpProcess()
    {
        JumpEvent?.Invoke();
        MovementCompo.Jump();
    }
    public void SpriteFlip(float x)
    {
        bool isRight = IsFacingRight();
        if (x < 0 && isRight)
        {
            transform.eulerAngles = new Vector3(0, -180f, 0);
        }
        else if (x> 0 && !isRight)
        {
            transform.eulerAngles = Vector3.zero;
        }
    }

    private void Update()
    {
        stateMachine.CurrentState.UpdateState();
        float movementX = PlayerInput.Movement.x;
        
        MovementCompo.SetMovement(movementX);
        SpriteFlip(movementX);
    }
    public override void SetDeadState()
    {
        stateMachine.ChangeState(PlayerEnum.Dead);
    }
    
    public void AnimationEndTrigger()
    {
        stateMachine.CurrentState.AnimationEndTrigger();
    }
    public void HitStateChange()
    {
        stateMachine.ChangeState(PlayerEnum.Hit);
    }
}
