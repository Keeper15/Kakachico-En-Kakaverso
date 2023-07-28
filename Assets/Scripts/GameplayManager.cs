using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : Manager<GameplayManager>
{
    [SerializeField] private int currentEnemyCount = 0;

    [SerializeField] private GameObject[] rooftopZonePrefabs;
    [SerializeField] private RooftopZone currentRooftopZone;

    public void SpawnNewRooftopZone()
    {
        int i = Random.Range(0, rooftopZonePrefabs.Length);
        GameObject.Instantiate(rooftopZonePrefabs[i], currentRooftopZone.GetNewBuildingSpawnPoint(), currentRooftopZone.transform.rotation);
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
