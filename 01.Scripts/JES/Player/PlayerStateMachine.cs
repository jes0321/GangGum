using System.Collections.Generic;

public enum PlayerEnum
{
    Attack1,
    Attack2,
    Idle,
    Run,
    Jump,
    Fall,
    Dead,
    Hit,
    Roll,
    Smash,
    Spin
}

public class PlayerStateMachine
{
    public PlayerState CurrentState{ get; private set; }

    public Dictionary<PlayerEnum, PlayerState> stateDictionary= new Dictionary<PlayerEnum, PlayerState>();
    
    public Player _player;
    
    public void Initialize(PlayerEnum startState, Player player)
    {
        _player = player;
        CurrentState = stateDictionary[startState];
        CurrentState.Enter();
    }

    public void ChangeState(PlayerEnum newState, bool forceMode = false)
    {
        if (_player.CanStateChangeable == false && forceMode == false) return;
        if (_player.IsDead) return; //사망한 적에게는 적용하지 않는다.

        CurrentState.Exit();
        CurrentState = stateDictionary[newState];
        CurrentState.Enter();
    }

    public void AddState(PlayerEnum stateEnum, PlayerState agentState)
    {
        stateDictionary.Add(stateEnum, agentState);
    }
}
