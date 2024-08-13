using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpitterBullet : MonoBehaviour, IPoolable
{

    public string PoolName => "SpitterBullet";
    public int damage = 0;
    public float knockBack = 0;

    public GameObject ObjectPrefab => gameObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health health;
        collision.TryGetComponent<Health>(out health);
        if (health != null)
            health.TakeDamage(damage, Vector2.zero, Vector2.zero, knockBack);
        PoolManager.Instance.Push(this);
    }

    public void ResetItem()
    {
    }
}