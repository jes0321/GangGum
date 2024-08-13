using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelUpCostText : MonoBehaviour
{
    public List<string> Cost = new List<string>();
    public TMP_Text txt;
    private void Start()
    {
        txt.text = null;
        txt.text = Cost[ChangeWeapon.count];
    }
    public void TextChange()
    {
        txt.text = null;
        txt.text = Cost[ChangeWeapon.count];
    }
}
