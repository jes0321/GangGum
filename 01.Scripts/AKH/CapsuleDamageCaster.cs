using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleDamageCaster : MonoBehaviour
{
    public ContactFilter2D filter;
    public Vector2 damageRadius;
    public float degree;
    public int detectCount = 1; //몇마리까지 데미지

    private Collider2D[] _colliders;

    private void Awake()
    {
        _colliders = new Collider2D[detectCount];
    }

    public bool CastDamage(int damage, float knockbackPower)
    {
        int cnt = Physics2D.OverlapBox(transform.position, damageRadius,degree, filter, _colliders);

        for (int i = 0; i < cnt; i++)
        {
            if (_colliders[i].TryGetComponent(out Health health))
            {
                Vector2 direction = _colliders[i].transform.position - transform.position;

                RaycastHit2D hit = Physics2D.Raycast(transform.position, direction.normalized, direction.magnitude, filter.layerMask);

                health.TakeDamage(damage, hit.normal, hit.point, knockbackPower);
            }
        }

        return cnt > 0;
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, damageRadius);
        Gizmos.color = Color.white;
    }
#endif
}
