using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShielderBullet : MonoBehaviour, IPoolable
{
    public int damage;
    public int knockBack;
    public string PoolName => "ShielderBullet";

    public GameObject ObjectPrefab => gameObject;

    public void ResetItem()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health health;
        if (collision.TryGetComponent(out health))
        {
            health.TakeDamage(damage, Vector2.zero, Vector2.zero, knockBack);
        }
        PoolManager.Instance.Push(this);
    }
}
