using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterControllerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 2.0f;
    [SerializeField]
    private float gravityScale = 1.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    

    private float gravity = -9.8f;

    private bool injump = false;


    private CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {



        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");

        Vector3 moveDirectionx = (transform.right * xMove) + (transform.forward * zMove);



        moveDirectionx *= moveSpeed * Time.deltaTime;

        if (Input.GetButton("Jump") && GetComponent<CharacterController>().isGrounded)
        {
            //GetComponent<EntityScript>().moveDirectiony.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }

        GetComponent<CharacterController>().Move(moveDirectionx);

    }


}
