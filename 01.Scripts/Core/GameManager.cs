using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneName
{
    // public const string (변수명) = "씬이름"
    public const string Dungeon1 = "Dungeon1";
    public const string Dungeon2 = "Dungeon2";
    public const string Dungeon3 = "Dungeon3";
    public const string Base = "BaseCamp";
    public const string Start = "StartScene";
}

public class GameManager : MonoSingleton<GameManager>
{
    public UnityEvent OnStartEvent;
    private Player _player;
    public ItemSO coin;
    public ItemSO bluePrint1;
    public ItemSO bluePrint2;
    public ItemSO bluePrint3;
    public Image panel;
    public NotifyValue<int> Coin = new NotifyValue<int>();
    public NotifyValue<int> BluePrint1 = new NotifyValue<int>();
    public NotifyValue<int> BluePrint2 = new NotifyValue<int>();
    public NotifyValue<int> BluePrint3 = new NotifyValue<int>();
    public Dictionary<ItemType, NotifyValue<int>> notiDic = new Dictionary<ItemType, NotifyValue<int>>();
    public Player Player
    {
        get
        {
            if (_player == null)
                _player = FindObjectOfType<Player>();
            if (_player == null)
                Debug.LogWarning("noPlayer");
            return _player;
        }
    }

    private void Start()
    {
        OnStartEvent?.Invoke();
    }

    private void Update()
    {
        Coin.Value = coin.count;
        
        BluePrint1.Value = bluePrint1.count;
        BluePrint2.Value = bluePrint2.count;
        BluePrint3.Value = bluePrint3.count;
    }

    private void OnEnable()
    {
        coin.count = SaveManager.Instance.saveData.GoldCount;
        bluePrint1.count = SaveManager.Instance.saveData.Evo1PrintCount;
        bluePrint2.count = SaveManager.Instance.saveData.Evo2PrintCount;
        bluePrint3.count = SaveManager.Instance.saveData.Evo3PrintCount;
        
        notiDic.Add(ItemType.Coin,Coin);
        notiDic.Add(ItemType.BluePrint1,BluePrint1);
        notiDic.Add(ItemType.BluePrint2,BluePrint2);
        notiDic.Add(ItemType.BluePrint3,BluePrint3);
        
    }
 
    public void DungeonClear()
    {
        panel.DOFade(1, 1.5f).OnComplete(()=>SceneManager.LoadScene(SceneName.Base));
        SaveManager.Instance.SavingData();
    }

    public Transform PlayerTrm =>Player.transform;
}
