using UnityEngine;
using UnityEngine.UI;

public class LevelUpImageChange : MonoBehaviour
{
    private ChangeWeapon changeWeapon;
    public Image ima1;
    public Image ima2;

    private void Start()
    {
        changeWeapon = FindObjectOfType<ChangeWeapon>();
    }

    public void Up()
    {
        if(ChangeWeapon.count < 11)
        {
            ima1.sprite = changeWeapon.weaponList[ChangeWeapon.count];
            ima2.sprite = changeWeapon.weaponList[ChangeWeapon.count + 1];
        }
    }
}
