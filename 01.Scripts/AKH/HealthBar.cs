using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    
    public void ChangeGage()
    {
        transform.localScale = new Vector3(Mathf.Clamp(_health.GetNormalizeHealth(),0,1),1,1);
    }
    public void Endure()
    {
        {
            if (transform.parent.parent.GetComponent<BossEnemy>().IsFacingRight())
            {
                transform.parent.localRotation = Quaternion.identity;
            }
            else
            {
                transform.parent.localRotation = Quaternion.Euler(0, -180f, 0);
            }
        }
    }
}
