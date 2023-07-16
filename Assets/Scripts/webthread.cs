using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class webthread : MonoBehaviour
{
    public GameObject firstthing;
    public GameObject secondthing;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if(firstthing != null && secondthing != null)
        {
            transform.position = Vector3.Lerp(firstthing.transform.position, secondthing.transform.position, 0.5f);


            //whitelaserobject.gameObject.transform.rotation = Quaternion.FromToRotation(this.transform.up, hit1.point - new Vector2(transform.position.x, transform.position.y));

            transform.rotation = Quaternion.LookRotation(firstthing.transform.position - secondthing.transform.position, Vector3.up);
            gameObject.transform.localScale = new Vector3(0.12f, 0.12f, Vector3.Distance(firstthing.transform.position, secondthing.transform.position));



        }
        else
        {
            gameObject.transform.localScale = Vector3.zero;
        }




    }
}
