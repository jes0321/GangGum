using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfoBox : MonoBehaviour
{
    [SerializeField] private Image _iconImage;
    [SerializeField] private TextMeshProUGUI _countText;

    [field: SerializeField] public ItemSO DisPlayItem { get; private set; }
    public RectTransform RectTrm { get; private set; }

    private void Awake()
    {
        RectTrm = transform as RectTransform;
    }

    public void SetUpData(ItemSO item)
    {
        DisPlayItem = item;
        UpdateVisual();

        GameManager.Instance.notiDic[item.itemType].OnValueChanged += HandleNotifyChange;
        HandleNotifyChange(0,GameManager.Instance.notiDic[item.itemType].Value);
    }

    private void HandleNotifyChange(int prev, int next)
    {
        _countText.text=next.ToString();
    }

    private void UpdateVisual()
    {
        if(_iconImage != null && DisPlayItem != null) 
            _iconImage.sprite=DisPlayItem.itemSprite;
    }

    private void OnValidate()
    {
        UpdateVisual();
    }
}
