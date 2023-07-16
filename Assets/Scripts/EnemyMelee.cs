using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    [SerializeField] private EntityScript entityScript;
    [SerializeField] private Animator animator;
    [SerializeField] private float damage = 10f;
    [SerializeField] private float attackTriggerDistance;

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
            animator.SetTrigger("Attack");
        }
    }

    public float GetDamageValue()
    {
        return damage;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackTriggerDistance);
    }
}
