using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour,IPoolable
{
    Rigidbody2D rb;
    public int damage;
    public float knockBackPower;
    public string PoolName => "Arrow";

    public GameObject ObjectPrefab => gameObject;

    public void ResetItem()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health health;
        if(collision.TryGetComponent(out health))
        {
            health.TakeDamage(damage, Vector2.zero, Vector2.zero, knockBackPower);
        }
        PoolManager.Instance.Push(this);
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        transform.right = rb.velocity;
    }
}
