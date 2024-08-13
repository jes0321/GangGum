using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Coin,Item1,Item2,Item3,Item4,Item5,Item6,BluePrint1,BluePrint2,BluePrint3
}
[CreateAssetMenu(menuName ="SO/Item/Data")]
public class ItemSO : ScriptableObject
{
    public ItemType itemType;
    public Sprite itemSprite;

    public int Amount;
    public PoolItemSO prefab;

    public int count;

}
