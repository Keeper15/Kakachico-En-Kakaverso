using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebSling : MonoBehaviour
{
    [SerializeField]
    private GameObject webshot;


    [SerializeField]
    private GameObject webspread;

    public bool landed = false;


    void Start()
    {
        GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 2699f);
    }

    // Update is called once per frame
    void Update()
    {



    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Platform")
        {

            GetComponent<Rigidbody>().velocity = Vector3.zero;
            webshot.SetActive(false);

            this.transform.position = other.ClosestPointOnBounds(this.transform.position);
            webspread.SetActive(true);

            landed = true;
        }
    }
}
