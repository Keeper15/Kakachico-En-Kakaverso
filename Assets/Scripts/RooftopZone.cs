using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RooftopZone : MonoBehaviour
{
    private Vector3 newBuildingSpawnPoint;
    [SerializeField] private Transform enemyContainer;
    [SerializeField] private Transform[] enemySpawnPoints;
    [SerializeField] private int enemyCount;

    [SerializeField] private GameObject enemyMeleePrefab;
    [SerializeField] private GameObject enemyRangedPrefab;

    private void Awake()
    {
        enemyCount = enemySpawnPoints.Length;
    }

    private void SpawnEnemies()
    {
        //Spawn an enemy in each spawn point
        foreach (Transform spawnPoint in enemySpawnPoints)
        {
            //50% chance for an enemy to be a ranged unit, 50% chance for an enemy to be a melee unit
            int coinFlip = Random.Range(0, 2);
            if (coinFlip == 0)
            {
                GameObject.Instantiate(enemyMeleePrefab, spawnPoint.position, spawnPoint.rotation, enemyContainer);
            }
            else
            {
                GameObject.Instantiate(enemyRangedPrefab, spawnPoint.position, spawnPoint.rotation, enemyContainer);
            }
        }

        //Add to GameplayManager the current enemy count
        GameplayManager.Instance.AddToCurrentEnemyCount(enemyCount);
    }

    private void OnTriggerEnter(Collider other)
    {
        SpawnEnemies();
    }

    public Vector3 GetNewBuildingSpawnPoint()
    {
        return newBuildingSpawnPoint;
    }

    public int GetEnemyCount()
    {
        return enemyCount;
    }
}
