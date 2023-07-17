using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : Manager<GameplayManager>
{
    [SerializeField] private int currentEnemyCount;

    [SerializeField] private GameObject rooftopZonePrefab;
    [SerializeField] private RooftopZone currentRooftopZone;
    [SerializeField] private RooftopZone newRooftopZone;

    public void DeleteOldRooftopZone()
    {

    }

    public void SpawnNewRooftopZone()
    {
        
    }

    public void AddToCurrentEnemyCount(int count)
    {
        currentEnemyCount += count;
    }

    public void DecrementCurrentEnemyCount()
    {
        --currentEnemyCount;

        if (currentEnemyCount == 0)
        {
            SpawnNewRooftopZone();
        }
    }
}
