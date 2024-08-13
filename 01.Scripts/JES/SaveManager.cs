using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasySave.Json;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class SaveData
{
    public int CurrentUpgrade;
    
    public int GoldCount, Evo1PrintCount, Evo2PrintCount,Evo3PrintCount;

    public List<int> resorceCountList;
    
    public bool canSmash = false, canSpin = false;

    public bool isFirst = true;

    public int evoCount;

    public float sfxVol, bgmVol;

    public SaveData()
    {
        CurrentUpgrade = 0;
        GoldCount = 0;
        Evo1PrintCount = 0;
        Evo2PrintCount = 0;
        Evo3PrintCount = 0;
        resorceCountList = new List<int>(){0,0,0,0,0,0};
        canSmash = false;
        canSpin = false;
        isFirst = true;
        evoCount = 0;
        sfxVol = 1;
        bgmVol = 1;
    }
} 
public class SaveManager : MonoBehaviour
{
    public SaveData saveData;

    public string fileName = "SaveFile";

    public static SaveManager Instance;
    
    [SerializeField] public List<ItemSO> items;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        saveData = EasyToJson.FromJson<SaveData>(fileName);
    }

    public void SaveDataToJson()
    {
        EasyToJson.ToJson(saveData,fileName,true);
    }
    public void SavingData()
    {
        saveData.CurrentUpgrade = ChangeWeapon.count;
        
        saveData.canSmash = SkillManager.Instance.GetSkill<SmashSkill>().skillEnabled;
        saveData.canSpin = SkillManager.Instance.GetSkill<SpinSkill>().skillEnabled;

        GameManager gameManager = GameManager.Instance;

        saveData.GoldCount = gameManager.coin.count;
        saveData.Evo1PrintCount = gameManager.bluePrint1.count;
        saveData.Evo2PrintCount = gameManager.bluePrint2.count;
        saveData.Evo3PrintCount = gameManager.bluePrint3.count;
        saveData.evoCount = PlayerManager.Instance.evoCnt;
        
        for (int i = 0; i < saveData.resorceCountList.Count; i++)
        {
            saveData.resorceCountList[i] = items[i].count;
        }

        saveData.sfxVol = UIManager.Instance.sfxSlider.value;
        saveData.bgmVol = UIManager.Instance.bgmSlider.value;
        
        SaveDataToJson();
    }
}
