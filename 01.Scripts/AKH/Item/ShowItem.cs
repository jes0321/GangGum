using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowItem : MonoSingleton<ShowItem>
{
    [SerializeField] public List<ItemSO> items;

    private void Start()
    {
        int cnt = 0;
        foreach(Transform item in transform)
        {
            int count = SaveManager.Instance.saveData.resorceCountList[cnt];
            items[cnt].count = count;
            
            item.GetComponent<Image>().sprite = items[cnt].itemSprite;
            item.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = items[cnt].count.ToString();
            cnt++;
        }
    
    }

    private void OnEnable()
    {
        int cnt = 0;
        foreach(Transform item in transform)
        {
            item.GetComponent<Image>().sprite = items[cnt].itemSprite;
            item.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = items[cnt].count.ToString();
            cnt++;
        }
    }
}
