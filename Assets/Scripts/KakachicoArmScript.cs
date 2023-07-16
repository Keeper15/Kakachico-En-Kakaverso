using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KakachicoArmScript : MonoBehaviour
{
    [SerializeField]
    private bool punchmode = false;

    [SerializeField]
    private GameObject kakachico;

    [SerializeField]
    private GameObject kakachicofunctions;

    [SerializeField]
    private GameObject webshot;

    [SerializeField]
    private GameObject webshootspawn;


    [SerializeField]
    private GameObject webthread;

    [SerializeField]
    private bool leftarm;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void Punch()
    {


    }

    private void OnTriggerEnter(Collider collision)
    {
        if (punchmode == true)
        {
            if(collision.gameObject.tag == "Enemy")
            {

                collision.GetComponent<EntityScript>().TakeDamage(12f);
                collision.GetComponent<CharacterImpactStuff>().AddImpact(kakachico.transform.position - collision.transform.position, -5f);
            }
        }
    }


    void WebSpawn()
    {

        if(kakachicofunctions.GetComponent<KakachicoFunctions>().webtarget1 == null && leftarm == true)
        {
            GameObject webtobeshot = Instantiate(webshot, webshootspawn.transform.position, webshootspawn.transform.rotation);

            kakachicofunctions.GetComponent<KakachicoFunctions>().webtarget1 = webtobeshot;



        }
        else if (kakachicofunctions.GetComponent<KakachicoFunctions>().webtarget2 == null && leftarm == false)
        {
            GameObject webtobeshot = Instantiate(webshot, webshootspawn.transform.position, webshootspawn.transform.rotation);


            kakachicofunctions.GetComponent<KakachicoFunctions>().webtarget2 = webtobeshot;
        }







    }
}
