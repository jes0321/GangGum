using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePrint1 : Collectable, IPoolable
{
    [SerializeField] private string _poolingName = "BluePrint1";
    public string PoolName => _poolingName;

    public GameObject ObjectPrefab => gameObject;

    public override void Collect(Transform collector, float magneticPower)
    {
        if (_alreadyCollected || !_canCollectable) return;
        _colliderCompo.enabled = false;
        _alreadyCollected = true;

        _itemData.count += 1;
        PoolManager.Instance.Push(this);
    }

    public void ResetItem()
    {
        _alreadyCollected = false;
        _canCollectable = false;
        _colliderCompo.enabled = true;
    }
}
