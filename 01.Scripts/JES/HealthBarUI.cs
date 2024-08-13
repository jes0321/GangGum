using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUi : PlayerCunnectUI
{
    private Image _barImage;
    private Image _backBarImage;
    private Health _playerHealth;

    private float _lastHitTime;
    private bool _isChaseFill;
    public override void AfterFindPlayer()
    {
        _barImage = transform.Find("Bar").GetComponent<Image>();
        _backBarImage = transform.Find("BackBar").GetComponent<Image>();

        _playerHealth = _player.HealthCompo;

        _playerHealth.OnHitEvent.AddListener(HandleHitEvent);
    }
    private void Update()
    {
        BackBarImage();
    }
    private void HandleHitEvent()
    {
        _lastHitTime=Time.time;
        _barImage.fillAmount = _playerHealth.GetNormalizeHealth();
        transform.DOShakePosition(0.3f,1f,100);
    }

    private void BackBarImage()
    {
        if (_player == null) return;
        if(!_isChaseFill&&_lastHitTime+1f>Time.time)
            _backBarImage.DOFillAmount(_barImage.fillAmount, 0.8f).SetEase(Ease.InCubic).OnComplete(() => _isChaseFill = false);
    }
}