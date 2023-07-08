using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    private Material red;

    [SerializeField]
    private Material white;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if(GetComponent<EntityScript>().hitstun < 10)
        {
            this.GetComponent<MeshRenderer>().material = red;
        }
        else
        {
            this.GetComponent<MeshRenderer>().material = white;
        }
    }
}
