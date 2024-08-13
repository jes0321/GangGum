using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField]
    private List<Transform> SpawnPoint;
    [SerializeField]
    private List<String> enemyNames;

    private void Awake()
    {
        foreach (var point in SpawnPoint)
        {
            int ranNum = Random.Range(0, enemyNames.Count);
            Enemy enemy = PoolManager.Instance.Pop(enemyNames[ranNum]) as Enemy;
            enemy.transform.position = point.position;
        }
    }
}
