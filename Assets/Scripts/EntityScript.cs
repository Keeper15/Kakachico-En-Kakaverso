using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.AI;

public class EntityScript : MonoBehaviour
{

    public float HP = 100;
    public float hitstun = 10f;

    public bool debugtest = false;

    [SerializeField] private GameObject healthBar;
    [SerializeField] private bool usesHealthBar = false;

    [SerializeField] private float gravityScale = 1.0f;
    private float gravity = -9.8f;
    private NavMeshAgent entityAgent;
    [SerializeField] private float moveDirectionY;
    [SerializeField] private Transform targetTransform;
    public bool grounded = false;

    [SerializeField] private float rotationSpeed;
    [SerializeField] private bool isRotatingViaScript = false;

    [SerializeField] private Animator animator;

    private void Awake()
    {
        entityAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        UpdateHPBar();
        entityAgent.isStopped = false;
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
        RotateViaScript();
        HandleHitstun();

        if(debugtest)
        {
            print(HP);
        }
    }

    private void Walk()
    {
        if (entityAgent.isStopped || !animator.GetBool("isAggroed"))
        {
            return;
        }
        entityAgent.SetDestination(targetTransform.position);
    }

    private void RotateViaScript()
    {
        if (!isRotatingViaScript) return;

        Vector3 targetPositionWithoutY = new Vector3(targetTransform.position.x, transform.rotation.y, targetTransform.position.z);
        Quaternion targetRotation = Quaternion.LookRotation(targetPositionWithoutY - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    public void TakeDamage(float damagetaken)
    {
        if(hitstun >= 10)
        {
            HP -= damagetaken;
            UpdateHPBar();
            hitstun = 0;
        }

        if (HP <= 0)
        {
            Die();
        }
    }

    private void UpdateHPBar()
    {
        if (!usesHealthBar) return;
        healthBar.transform.localScale = new Vector3(Mathf.Lerp(0f, 2f, HP / 100f), 0.1f, 0.05f);
    }

    private void HandleHitstun()
    {
        hitstun += 100f * Time.deltaTime;
        if (hitstun >= 10)
        {
            hitstun = 10;
        }
    }

    public void SetIsStoppedToTrue()
    {
        entityAgent.isStopped = true;
    }

    public void SetIsStoppedToFalse()
    {
        entityAgent.isStopped = false;
    }

    public void SetIsRotatingViaScriptToTrue()
    {
        entityAgent.updateRotation = false;
        isRotatingViaScript = true;
    }
    public void SetIsRotatingViaScriptToFalse()
    {
        entityAgent.updateRotation = true;
        isRotatingViaScript = false;
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }

    public Transform GetTargetTransform()
    {
        return targetTransform;
    }
}
