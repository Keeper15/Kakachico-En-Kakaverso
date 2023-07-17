using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRanged : MonoBehaviour
{
    [SerializeField] private EntityScript entityScript;
    [SerializeField] private Animator animator;
    [SerializeField] private float damage = 5f;
    [SerializeField] private float attackTriggerDistance;
    [SerializeField] private LayerMask attackLayerMask;
    [SerializeField] private Transform shootTransform;
    [SerializeField] private Vector3 aimPosition;
    [SerializeField] private bool isAiming;

    private void Awake()
    {
        entityScript = GetComponent<EntityScript>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("isAggroed", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, entityScript.GetTargetTransform().position) <= attackTriggerDistance)
        {
            RaycastHit hit;
            Vector3 direction = entityScript.GetTargetTransform().position - transform.position;
            if (Physics.Raycast(transform.position, direction, out hit, Mathf.Infinity, attackLayerMask))
            {
                if (hit.transform.tag == "Player")
                {
                    animator.SetTrigger("Attack");
                }

                Debug.DrawRay(transform.position, direction, Color.magenta);
            }
        }
    }

    public void StartAiming()
    {
        Debug.Log("StartAiming is called");
        aimPosition = entityScript.GetTargetTransform().position;
        isAiming = true;
       
    }

    //MIGHT REMOVE
    private void Aim()
    {
        if (!isAiming) return;
        //Handle rotation of joints to aimPosition so that it points at the player's direction
    }

    private void StopAiming()
    {
        isAiming = false;
    }

    public void ShootBullet()
    {
        RaycastHit hit;
        Vector3 direction = aimPosition - shootTransform.position;
        if (Physics.Raycast(shootTransform.position, direction, out hit, Mathf.Infinity, attackLayerMask))
        {
            if (hit.transform.GetComponent<Player>() != null)
            {
                hit.transform.GetComponent<Player>().TakeDamage(damage);
            }

            Debug.DrawRay(shootTransform.position, direction, Color.cyan);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackTriggerDistance);
    }
}
