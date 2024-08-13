using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CraftPrint : MonoBehaviour
{
    public List<int> necessaryValue = new List<int>();
    public List<string> Text = new List<string>();
    public TMP_Text txt;
    public Image me;
    public void Btn1() 
    {
        if (necessaryValue[0] <= SaveManager.Instance.items[0].count && necessaryValue[1] <= SaveManager.Instance.items[1].count && necessaryValue[2] <= SaveManager.Instance.items[2].count && necessaryValue[3] <= SaveManager.Instance.items[3].count)
        {
            StartCoroutine(DelayText(Text[0]));
            SaveManager.Instance.items[0].count -= necessaryValue[0];
            SaveManager.Instance.items[1].count -= necessaryValue[1];
            SaveManager.Instance.items[2].count -= necessaryValue[2];
            SaveManager.Instance.items[3].count -= necessaryValue[3];
            GameManager.Instance.bluePrint1.count++;
        }
        else
        {
            StartCoroutine(DelayText(Text[1]));
        }
    }
    public void Btn2()
    {
        if (necessaryValue[4] <= SaveManager.Instance.items[0].count && necessaryValue[5] <= SaveManager.Instance.items[1].count && necessaryValue[6] <= SaveManager.Instance.items[2].count && necessaryValue[7] <= SaveManager.Instance.items[3].count)
        {
            StartCoroutine(DelayText(Text[0]));
            SaveManager.Instance.items[0].count -= necessaryValue[4];
            SaveManager.Instance.items[1].count -= necessaryValue[5];
            SaveManager.Instance.items[2].count -= necessaryValue[6];
            SaveManager.Instance.items[3].count -= necessaryValue[7];
            GameManager.Instance.bluePrint2.count++;
        }
        else
        {
            StartCoroutine(DelayText(Text[1]));
        }
    }
    public void Btn3()
    {
        if (necessaryValue[8] <= SaveManager.Instance.items[2].count && necessaryValue[9] <= SaveManager.Instance.items[3].count && necessaryValue[10] <= SaveManager.Instance.items[4].count && necessaryValue[11] <= SaveManager.Instance.items[5].count)
        {
            StartCoroutine(DelayText(Text[0]));
            SaveManager.Instance.items[2].count -= necessaryValue[8];
            SaveManager.Instance.items[3].count -= necessaryValue[9];
            SaveManager.Instance.items[4].count -= necessaryValue[10];
            SaveManager.Instance.items[5].count -= necessaryValue[11];
            GameManager.Instance.bluePrint3.count++;
        }
        else
        {
            StartCoroutine(DelayText(Text[1]));
        }
    }

    public void ExitPanel()
    {
        txt.text = null;
        GameManager.Instance.Player.PlayerInput.controls.Enable();
        UIManager.Instance._difUION = false;
        me.gameObject.SetActive(false);
    }

    private IEnumerator DelayText(string str)
    {
        txt.text = null;
        txt.text = str;
        yield return new WaitForSeconds(1.5f);
        txt.text = null;
    }
}
