using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EntityScript : MonoBehaviour
{

    public float HP = 100;

    public float hitstun = 10f;


    public bool debugtest = false;

    [SerializeField]
    private GameObject healthbar;


    [SerializeField]
    private bool useshealthbar = false;



    [SerializeField]
    private float gravityScale = 1.0f;

    private float gravity = -9.8f;

    private CharacterController characterController;

    public Vector3 moveDirectiony;

    public bool grounded = false;

    void Start()
    {
        
    }

    private void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {


        hitstun += 100f * Time.deltaTime;

        if(hitstun >=10)
        {
            hitstun = 10;
        }



        if(debugtest)
        {
            print(HP);
        }


        if(useshealthbar)
        {
            healthbar.transform.localScale = new Vector3(Mathf.Lerp(0f, 2f, HP / 100f), 0.1f, 0.2f);
        }





        if (GetComponent<CharacterController>().isGrounded && moveDirectiony.y < 0)
        {
            moveDirectiony.y = -1f;
        }

        moveDirectiony.y += gravity * Time.deltaTime * gravityScale;


        GetComponent<CharacterController>().Move(moveDirectiony * Time.deltaTime);

    }

    public void TakeDamage(float damagetaken)
    {
        if(hitstun >= 10)
        {
            HP -= damagetaken;
            hitstun = 0;

        }


    }


}
