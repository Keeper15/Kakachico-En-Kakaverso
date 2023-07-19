using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() != null)
        {
            GameplayManager.Instance.TeleportPlayerToSafety();
        }
        else if (other.GetComponent<EntityScript>() != null)
        {
            other.GetComponent<EntityScript>().TriggerDeath();
        }
    }
}
