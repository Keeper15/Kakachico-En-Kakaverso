using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Manager<PlayerManager>
{
    [SerializeField] private GameObject playerRef;
    [SerializeField] private int score;

    private void Awake()
    {
        if (playerRef == null)
        {
            playerRef = Transform.FindObjectOfType<Player>().gameObject;
        }
    }

    public void IncrementScore()
    {
        ++score;
    }

    public int GetScore()
    {
        return score;
    }

    public GameObject GetPlayerRef()
    {
        return playerRef;
    }
}
