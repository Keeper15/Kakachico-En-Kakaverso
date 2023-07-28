using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : Manager<GameplayManager>
{
    [SerializeField] private int currentEnemyCount = 0;

    [SerializeField] private GameObject rooftopZonePrefab;
    [SerializeField] private RooftopZone currentRooftopZone;

    public void SpawnNewRooftopZone()
    {
        GameObject.Instantiate(rooftopZonePrefab, currentRooftopZone.GetNewBuildingSpawnPoint(), currentRooftopZone.transform.rotation);
    }

    public void SwitchCurrentZone(RooftopZone newRooftopZone)
    {
        if (currentRooftopZone != null) Destroy(currentRooftopZone.gameObject);
        currentRooftopZone = newRooftopZone;
    }

    public void AddToCurrentEnemyCount(int count)
    {
        if (currentEnemyCount < 0)
        {
            currentEnemyCount = 0;
        }
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

    public void TeleportPlayerToSafety()
    {
        PlayerManager.Instance.GetPlayerRef().transform.position = currentRooftopZone.GetPlayerRespawnPoint();
    }
}
