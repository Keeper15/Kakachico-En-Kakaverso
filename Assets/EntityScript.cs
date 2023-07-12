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
    private CharacterController characterController;
    private NavMeshAgent entityAgent;
    [SerializeField] private float moveDirectionY;
    [SerializeField] private Transform targetPosition;
    public bool grounded = false;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        entityAgent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        UpdateHPBar();
    }

    // Update is called once per frame
    void Update()
    {
        entityAgent.SetDestination(targetPosition.position);
        entityAgent.isStopped = false;

        hitstun += 100f * Time.deltaTime;
        if(hitstun >=10)
        {
            hitstun = 10;
        }

        if(debugtest)
        {
            print(HP);
        }

        //if (characterController.isGrounded && moveDirectionY < 0)
        //{
        //    moveDirectionY = -1f;
        //}
        //moveDirectionY += gravity * Time.deltaTime * gravityScale;
        //characterController.Move((Vector3.up * moveDirectionY) * Time.deltaTime);
    }

    public void TakeDamage(float damagetaken)
    {
        if(hitstun >= 10)
        {
            HP -= damagetaken;
            UpdateHPBar();
            hitstun = 0;
        }
    }

    private void UpdateHPBar()
    {
        if (!usesHealthBar) return;
        healthBar.transform.localScale = new Vector3(Mathf.Lerp(0f, 2f, HP / 100f), 0.1f, 0.2f);
    }
}
