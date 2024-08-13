using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeWeapon : MonoBehaviour
{
    public List<Sprite> weaponList = new List<Sprite>();
    public Image weaponImage;
    public static int count = 0;

    private void Awake()
    {
        count = SaveManager.Instance.saveData.CurrentUpgrade; 
        ChangeWeaponImage();
    }

    public void ChangeWeaponImage()
    {
        weaponImage.sprite = weaponList[count];
    }
}
