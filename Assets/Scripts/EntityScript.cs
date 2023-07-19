using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EntityScript : MonoBehaviour
{

    public float HP = 100;
    public float hitstun = 10f;

    public bool debugtest = false;

    [SerializeField] private GameObject healthBar;
    [SerializeField] private bool usesHealthBar = false;

    [SerializeField] private float gravityScale = 1.0f;
    private static float gravity = 9.8f;
    [SerializeField] private float movementSpeed = 3.5f;
    private CharacterController controller;
    private bool isMovementAllowed;
    [SerializeField] private float moveDirectionY;
    [SerializeField] private Transform targetTransform;
    public bool grounded = false;

    [SerializeField] private float rotationSpeed;
    [SerializeField] private bool isRotatingViaScript = false;

    private Animator animator;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        targetTransform = PlayerManager.Instance.GetPlayerRef().transform;
    }

    private void Start()
    {
        UpdateHPBar();
    }

    // Update is called once per frame
    void Update()
    {
        RotateViaScript();
        Walk();
        HandleHitstun();

        if(debugtest)
        {
            print(HP);
        }
    }

    private void Walk()
    {
        Vector3 characterMovement = Vector3.zero;
        if (isMovementAllowed && animator.GetBool("isAggroed"))
        {
            characterMovement += transform.forward * movementSpeed;
        }
        
        if (!controller.isGrounded)
        {
            characterMovement += Vector3.down * (gravity * gravityScale);
        }

        controller.Move(characterMovement * Time.deltaTime);
    }

    private void RotateViaScript()
    {
        if (!isRotatingViaScript) return;

        Vector3 targetPositionWithoutY = new Vector3(targetTransform.position.x, transform.position.y, targetTransform.position.z);
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
            animator.SetTrigger("Die");
        }
    }

    private void UpdateHPBar()
    {
        if (!usesHealthBar) return;
        healthBar.transform.localScale = new Vector3(Mathf.Lerp(0f, 1f, HP / 100f), 0.1f, 0.05f);
    }

    private void HandleHitstun()
    {
        hitstun += 100f * Time.deltaTime;
        if (hitstun >= 10)
        {
            hitstun = 10;
        }
    }

    public void AllowMovement()
    {
        isMovementAllowed = true;
    }

    public void DisallowMovement()
    {
        isMovementAllowed = false;
    }

    public void SetIsRotatingViaScriptToTrue()
    {
        isRotatingViaScript = true;
    }
    public void SetIsRotatingViaScriptToFalse()
    {
        isRotatingViaScript = false;
    }

    public void Die()
    {
        GameplayManager.Instance.DecrementCurrentEnemyCount();
        Destroy(this.gameObject);
    }

    public Transform GetTargetTransform()
    {
        return targetTransform;
    }

    public void TriggerDeath()
    {
        animator.SetTrigger("Die");
    }
}
