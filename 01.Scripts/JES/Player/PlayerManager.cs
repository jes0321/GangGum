using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoSingleton<PlayerManager>
{
    [SerializeField] private List<int> DamageList,HealthList;
    [SerializeField] private List<RuntimeAnimatorController> PlayerAnimators;
    public int evoCnt;
    [SerializeField] private PlayerDamageSO normalAttackSO,SmashData,SpinData;
    private void Start()
    {
        evoCnt = SaveManager.Instance.saveData.evoCount;
        DamageUpdate();
        AnimatorTrade();
        HealthUpdate();
    }

    private void HealthUpdate()
    {
        GameManager.Instance.Player.HealthCompo.SetMaxAndCurrent(HealthList[evoCnt]);
    }

    public void DamageUpdate()
    {
        normalAttackSO.damage = DamageList[SaveManager.Instance.saveData.CurrentUpgrade];
        SmashData.damage = normalAttackSO.damage + 20;
        SpinData.damage = normalAttackSO.damage + 40;
    }

    public void AnimatorTrade()
    {
        if (evoCnt >= 3)
        {
            GameManager.Instance.Player.AnimatorCompo.runtimeAnimatorController = PlayerAnimators[2];
            return;
        }
        GameManager.Instance.Player.AnimatorCompo.runtimeAnimatorController = PlayerAnimators[evoCnt];
    }
}
