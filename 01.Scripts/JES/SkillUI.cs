using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour
{
    [SerializeField] private Image coolUI;
    [SerializeField] private GameObject LockImage;
    [SerializeField] protected Skill _skill;

    private void Start()
    {
        _skill.OnCooldownEvent += HandleSkillCoolUI;
        LockOnOff();
    }

    public void LockOnOff()
    {
        LockImage.SetActive(!_skill.skillEnabled);
    }
    private void HandleSkillCoolUI(float current, float total)
    {
        coolUI.fillAmount = current / total;
    }
}
