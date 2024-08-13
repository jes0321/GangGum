using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NpcTalk : MonoBehaviour
{
    private float _distance;
    [SerializeField] private float _minDistance;
    private GameObject _npc;
    private GameObject _F;
    public TMP_Text _txt;
    public List<string> chatText = new List<string>();
    public GameObject Btn;
    public Image image;
    public static bool isTalk = false;


    private void Start()
    {
        _npc = NpcManager.Instance.Npc;
        _F = NpcManager.Instance.fKey;
    }
    private void Update()
    {
        _distance = Vector2.Distance(gameObject.transform.position, _npc.transform.position);
        if (_minDistance > _distance)
        {
            _F.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F) && isTalk == false&&!UIManager.Instance._onUI)
            {
                EvolutionSword();
            }
        }
        else
        {
            _F.SetActive(false);
        }
    }
    private void EvolutionSword()
    {
        int rand = UnityEngine.Random.Range(0, chatText.Count);
        StartCoroutine(Chat(chatText[rand]));
    }

    private IEnumerator Chat(string text)
    {
        isTalk = true;
        UIManager.Instance._difUION = true;
        GameManager.Instance.Player.PlayerInput.controls.Disable();
        image.gameObject.SetActive(true);
        _txt.text = null;
        _txt.DOText(text, 3f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(4f);
        _txt.text = null;
        Btn.gameObject.SetActive(true);
    }
}
