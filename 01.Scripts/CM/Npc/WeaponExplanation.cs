using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponExplanation : MonoBehaviour
{
    public List<string> txtList = new List<string>();
    private ChangeWeapon changeWeapon;
    public TMP_Text txt1;
    public TMP_Text txt2;

    private void Start()
    {
        changeWeapon = FindObjectOfType<ChangeWeapon>();
    }
    public void Up()
    {
        if (ChangeWeapon.count <= 11)
        {
            txt1.text = txtList[ChangeWeapon.count];
            txt2.text = txtList[ChangeWeapon.count + 1];
        }
    }
}
