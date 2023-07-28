using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebSling : MonoBehaviour
{
    [SerializeField]
    private GameObject webshot;

    [SerializeField]
    private GameObject webspread;

    [SerializeField]
    private float startupIntangibility;

    public bool landed = false;


    void Start()
    {
        GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 2699f);
    }

    // Update is called once per frame
    void Update()
    {

        if (startupIntangibility > 0)
        {
            startupIntangibility -= Time.deltaTime;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Platform" && startupIntangibility <= 0)
        {

            GetComponent<Rigidbody>().velocity = Vector3.zero;
            webshot.SetActive(false);

            this.transform.position = other.ClosestPointOnBounds(this.transform.position);
            webspread.SetActive(true);

            landed = true;
        }
    }
}
