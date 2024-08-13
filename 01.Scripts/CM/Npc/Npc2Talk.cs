using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Npc2Talk : MonoBehaviour
{
    private float _distance;
    [SerializeField] private float _minDistance;
    private Transform _player;
    public GameObject _F;
    public Image panel;


    private void Start()
    {
        _player = GameManager.Instance.PlayerTrm;
    }
    private void Update()
    {
        _distance = Vector2.Distance(gameObject.transform.position, _player.transform.position);
        if (_minDistance > _distance&&!UIManager.Instance._onUI)
        {
            _F.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                UIManager.Instance._difUION = true;
                GameManager.Instance.Player.PlayerInput.controls.Disable();
                panel.gameObject.SetActive(true);
            }
        }
        else
        {
            _F.SetActive(false);
        }
    }
}
