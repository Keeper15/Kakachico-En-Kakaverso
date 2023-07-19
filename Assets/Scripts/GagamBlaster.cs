using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GagamBlaster : MonoBehaviour
{
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Animator gunAnimator;
    [SerializeField] private EnemyRanged enemyRanged;

    public void ShootBullet()
    {
        //Do a raycast
        //Check if hit has Enemy tag, do damage if yes

        gunAnimator.SetTrigger("Fire");

        RaycastHit hit;

        if (Physics.Raycast(bulletSpawn.position, bulletSpawn.forward, out hit, Mathf.Infinity, layerMask))
        {
            if (hit.transform.GetComponent<EntityScript>() != null)
            {
                Transform enemyHitRef = hit.transform;

                enemyHitRef.GetComponent<EntityScript>().TakeDamage(10f);
                //enemyHitRef.GetComponent<CharacterImpactStuff>().AddImpact(transform.position - enemyHitRef.transform.position, -5f);
            }
        }
    }

    public void HandleStolenGunFromEnemy()
    {
        enemyRanged.SetHasGun(false);
    }
}
