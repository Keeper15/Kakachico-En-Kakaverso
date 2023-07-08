using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KakachicoFunctions : MonoBehaviour
{
    [SerializeField]
    private GameObject kakachico;


    [SerializeField]
    private GameObject armleft;

    [SerializeField]
    private GameObject armright;

    [SerializeField]
    private GameObject webthread1;


    public GameObject webtarget1;



    [SerializeField]
    private GameObject webthread2;


    public GameObject webtarget2;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Punchie();


        WebShot2();

        WebShot1();

        if((webtarget1 != null && webtarget1.GetComponent<WebSling>().landed) || (webtarget2 != null && webtarget2.GetComponent<WebSling>().landed))
        {
            kakachico.GetComponent<KakachicoMovement>().kakachicoselfgravity = 0;
            kakachico.GetComponent<Rigidbody>().AddForce((Vector3.down * 5f) * Time.deltaTime, ForceMode.Force);
        }


    }

    void Punchie()
    {
        if(Input.GetMouseButton(0))
        {
            armleft.GetComponent<Animator>().Play("punch");


        }

        if (Input.GetMouseButton(1))
        {
            armright.GetComponent<Animator>().Play("punch");

        }

    }


    void WebShot1()
    {

        if (Input.GetKey(KeyCode.Q))
        {


            armleft.GetComponent<Animator>().SetBool("WebShoot", true);


            webthread1.SetActive(true);

            webthread1.GetComponent<webthread>().secondthing = webtarget1;


            if (webtarget1 != null && webtarget1.GetComponent<WebSling>().landed)
            {
                kakachico.GetComponent<Rigidbody>().AddForce((kakachico.transform.position - webtarget1.transform.position) * Mathf.Lerp(-1230f, -5760f, (Vector3.Distance(kakachico.transform.position,webtarget1.transform.position)/ 50f) )* Time.deltaTime, ForceMode.Force);
            }

            //so that you dont have infinite web length
            if (webtarget1 != null && (Vector3.Distance(kakachico.transform.position, webtarget1.transform.position) > 50f))
            {
                WebRelease1();

            }

        }

        if( Input.GetKeyUp(KeyCode.Q))
        {
            WebRelease1();
        }
    }



    void WebRelease1()
    {

        armleft.GetComponent<Animator>().SetBool("WebShoot", false);

        if (webtarget1 != null && webtarget1.GetComponent<WebSling>().landed)
        {
            kakachico.GetComponent<Rigidbody>().AddForce((kakachico.transform.position - webtarget1.transform.position) * -10f , ForceMode.Impulse);
            kakachico.GetComponent<Rigidbody>().AddForce(kakachico.transform.forward * 60f, ForceMode.Impulse);
            kakachico.GetComponent<Rigidbody>().AddForce(kakachico.transform.up * 10f, ForceMode.Impulse);
        }



        webthread1.SetActive(false);
        Destroy(webtarget1);



    }





    void WebShot2()
    {

        if (Input.GetKey(KeyCode.E))
        {


            armright.GetComponent<Animator>().SetBool("WebShoot", true);


            webthread2.SetActive(true);

            webthread2.GetComponent<webthread>().secondthing = webtarget2;


            if (webtarget2 != null && webtarget2.GetComponent<WebSling>().landed)
            {
                kakachico.GetComponent<Rigidbody>().AddForce((kakachico.transform.position - webtarget2.transform.position) * Mathf.Lerp(-1230f, -5760f, (Vector3.Distance(kakachico.transform.position, webtarget2.transform.position) / 50f)) * Time.deltaTime, ForceMode.Force);

            }

            //so that you dont have infinite web length
            if (webtarget2!= null && (Vector3.Distance(kakachico.transform.position, webtarget2.transform.position) > 50f))
            {
                WebRelease2();

            }

        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            WebRelease2();
        }
    }



    void WebRelease2()
    {

        armright.GetComponent<Animator>().SetBool("WebShoot", false);

        if (webtarget2 != null && webtarget2.GetComponent<WebSling>().landed)
        {
            kakachico.GetComponent<Rigidbody>().AddForce((kakachico.transform.position - webtarget2.transform.position) * -10f, ForceMode.Impulse);
            kakachico.GetComponent<Rigidbody>().AddForce(kakachico.transform.forward * 60f, ForceMode.Impulse);
            kakachico.GetComponent<Rigidbody>().AddForce(kakachico.transform.up * 10f, ForceMode.Impulse);
        }



        webthread2.SetActive(false);
        Destroy(webtarget2);



    }
}
