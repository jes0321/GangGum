using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeadState : PlayerState
{
    public PlayerDeadState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _player.PlayerInput.controls.Disable();
        
        GameManager.Instance.panel.DOFade(1, 1.5f).OnComplete(()=>SceneManager.LoadScene(SceneName.Base));
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (_endTriggerCalled)
        {
            _player.PlayerInput.controls.Enable();
            SaveManager.Instance.SavingData();
        }
    }
}
