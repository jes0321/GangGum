using System.Collections.Generic;

public class EnemyStateMachine
{
    public EnemyState CurrentState { get; private set; }

    public Dictionary<EnemyEnum, EnemyState> stateDictionary = new Dictionary<EnemyEnum, EnemyState>();

    public Enemy _enemy;
    public void Initialize(EnemyEnum startState, Enemy enemy)
    {
        _enemy = enemy;
        CurrentState = stateDictionary[startState];
        CurrentState.Enter();
    }

    public void ChangeState(EnemyEnum newState, bool forceMode = false)
    {
        if (_enemy.CanStateChangeable == false && forceMode == false) return;
        if (_enemy.IsDead) return; //사망한 적에게는 적용하지 않는다.

        CurrentState.Exit();
        CurrentState = stateDictionary[newState];
        CurrentState.Enter();
    }

    public void AddState(EnemyEnum stateEnum, EnemyState enemyState)
    {
        stateDictionary.Add(stateEnum, enemyState);
    }
}
