using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RooftopZone : MonoBehaviour
{
    [SerializeField] private Vector3 newBuildingSpawnPoint;
    [SerializeField] private Vector3 playerRespawnPoint;
    [SerializeField] private Transform enemyContainer;
    [SerializeField] private Transform[] enemySpawnPoints;
    [SerializeField] private int enemyCount;
    private bool hasSpawned;

    [SerializeField] private GameObject enemyMeleePrefab;
    [SerializeField] private GameObject enemyRangedPrefab;

    private void Awake()
    {
        enemyCount = enemySpawnPoints.Length;
    }

    private void SpawnEnemies()
    {
        if (hasSpawned) return;

        hasSpawned = true;

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
        GameplayManager.Instance.SwitchCurrentZone(this);
    }

    public Vector3 GetNewBuildingSpawnPoint()
    {
        return transform.position + newBuildingSpawnPoint;
    }

    public int GetEnemyCount()
    {
        return enemyCount;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        { 
            SpawnEnemies(); 
        }
    }

    public Vector3 GetPlayerRespawnPoint()
    {
        return transform.position + playerRespawnPoint;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(GetNewBuildingSpawnPoint(), 2f);

        Gizmos.color = Color.green;
        Gizmos.DrawSphere(GetPlayerRespawnPoint(), 0.75f);
    }
}
