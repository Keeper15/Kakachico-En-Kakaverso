using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KakachicoMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public float kakachicoselfgravity = 0;


    bool istouchingplatform = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        kakachicoselfgravity += 4.8f * Time.deltaTime;

        //if (kakachicoselfgravity >= 6f)
        //{
        //    kakachicoselfgravity = 6f;
        //}



        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");



        GetComponent<Rigidbody>().AddRelativeForce(15220f * xMove * Vector3.right * Time.deltaTime);
        GetComponent<Rigidbody>().AddRelativeForce(15220f * zMove * Vector3.forward * Time.deltaTime);



        if (GetComponent<Rigidbody>().velocity.y > 1f)
        {

            GetComponent<Rigidbody>().AddRelativeForce(-510f * Vector3.up * Time.deltaTime * kakachicoselfgravity);
        }
        else
        {
            GetComponent<Rigidbody>().AddRelativeForce(-5520f * Vector3.up * Time.deltaTime * kakachicoselfgravity);

        }



        if(Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddRelativeForce(80f *Vector3.up, ForceMode.VelocityChange);
        }


    }


    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            kakachicoselfgravity = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, 0f , GetComponent<Rigidbody>().velocity.z);
        }
    }


}
