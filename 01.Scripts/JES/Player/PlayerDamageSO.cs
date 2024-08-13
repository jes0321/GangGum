using UnityEngine;


[CreateAssetMenu(menuName = "SO/Player/DamageData")]
public class PlayerDamageSO : ScriptableObject
{
    public int damage;
    public float knockPower;

    public Vector2 damagePos;
    public Vector2 damageRadius;

    public float attackCooldown;
}