using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPanel : MonoBehaviour
{
    [SerializeField] private List<ItemSO> _panelItems;
    [SerializeField] private InfoBox _infoBoxPrefab;
    [SerializeField] private float _padding = 16.5f, _gap = 10f, _paddingY = 13f;

    private RectTransform _rectTram;

    private void Awake()
    {
        _rectTram = transform as RectTransform;
    }

    private void Start()
    {
        float offset = _padding;
        foreach (var item in _panelItems)
        {
            InfoBox box = Instantiate(_infoBoxPrefab, transform);
            box.SetUpData(item);
            box.RectTrm.anchoredPosition = new Vector2(offset, -_paddingY);
            Vector2 sizeDelta = box.RectTrm.sizeDelta;
            offset += sizeDelta.x + _gap;
        }
/*
        offset += _padding;
        Vector2 parentSizeDelta = _rectTram.sizeDelta;
        parentSizeDelta.x = offset;
        _rectTram.sizeDelta = parentSizeDelta;
        */
    }
}
