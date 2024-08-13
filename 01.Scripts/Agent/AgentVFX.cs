using System;
using UnityEngine;

public class AgentVFX : MonoBehaviour
{
    [SerializeField] private bool _canGenerateAfterImage;
    [SerializeField]
    private float _generateTerm;

    private float _currentTime;
    private Player _player;
    public void Initalize(Player player)
    {
        _player = player;
    }
    public void ToggleAfterImage(bool value)
    {
        _canGenerateAfterImage = value;
    }

    private void Update()
    {
        if(!_canGenerateAfterImage) return;

        _currentTime += Time.deltaTime;
        if (_currentTime >= _generateTerm)
        {
            _currentTime = 0;
            AfterImage img =PoolManager.Instance.Pop("AfterImage") as AfterImage;
            
            Transform visualTrm = _player.transform.Find("Visual");
            Sprite sprite= visualTrm.GetComponent<SpriteRenderer>().sprite;
            
            bool isFlip = !_player.IsFacingRight();
            img.SetAfterImage(sprite,transform.position,0.2f,isFlip);
        }
    }
}