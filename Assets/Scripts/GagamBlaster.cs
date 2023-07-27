using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GagamBlaster : MonoBehaviour
{
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Animator gunAnimator;
    [SerializeField] private EnemyRanged enemyRanged;

    [SerializeField] private int maxAmmo;
    [SerializeField] private int currentAmmo;
    [SerializeField] private TextMeshProUGUI ammoCountDisplay;

    [SerializeField] private float damage;

    private void Awake()
    {
        currentAmmo = maxAmmo;
    }

    public void ShootBullet()
    {
        //Do a raycast
        //Check if hit has Enemy tag, do damage if yes

        gunAnimator.SetTrigger("Fire");

        if (currentAmmo <= 0) return;

        RaycastHit hit;

        if (Physics.Raycast(bulletSpawn.position, bulletSpawn.forward, out hit, Mathf.Infinity, layerMask))
        {
            if (hit.transform.GetComponent<EntityScript>() != null)
            {
                Transform enemyHitRef = hit.transform;

                enemyHitRef.GetComponent<EntityScript>().TakeDamage(damage);
                //enemyHitRef.GetComponent<CharacterImpactStuff>().AddImpact(transform.position - enemyHitRef.transform.position, -5f);
            }
        }

        --currentAmmo;
        UpdateAmmoCount();
    }

    public void HandleStolenGunFromEnemy()
    {
        UpdateAmmoCount();
        enemyRanged.SetHasGun(false);
    }

    public void UpdateAmmoCount()
    {
        ammoCountDisplay.text = currentAmmo.ToString();
    }
}
