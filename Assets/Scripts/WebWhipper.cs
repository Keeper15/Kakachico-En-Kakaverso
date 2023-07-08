using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebWhipper : MonoBehaviour
{
    [SerializeField] private GameObject webthread;
    [SerializeField] private GameObject webtarget;
    [SerializeField] private GameObject websling;
    [SerializeField] private GameObject kakachico;

    [SerializeField] private Transform webShootSpawn;

    private void Update()
    {
        ReelWeb();
    }

    public void ShootWeb()
    {
        //instantiate projectile
        //add velocity to projectile       

        if (webtarget == null)
        {
            GameObject webshot = Instantiate(websling, webShootSpawn.position, webShootSpawn.rotation);
            webtarget = webshot;
        }

        webthread.SetActive(true);
        webthread.GetComponent<webthread>().secondthing = webtarget;
    }

    public void ReleaseWeb()
    {
        //destroy projectile
        //if projectile has stuck to something, add velocity burst to kakachico
        if (webtarget != null && webtarget.GetComponent<WebSling>().landed)
        {
            kakachico.GetComponent<Rigidbody>().AddForce((kakachico.transform.position - webtarget.transform.position) * -2f, ForceMode.Impulse);
            kakachico.GetComponent<Rigidbody>().AddForce(kakachico.transform.forward * 4f, ForceMode.Impulse);
            kakachico.GetComponent<Rigidbody>().AddForce(kakachico.transform.up * 2f, ForceMode.Impulse);
        }

        webthread.SetActive(false);
        Destroy(webtarget);
    }

    private void ReelWeb()
    {
        if (webtarget == null) return;

        if (webtarget.GetComponent<WebSling>().landed)
        {
            kakachico.GetComponent<Rigidbody>().AddForce((kakachico.transform.position - webtarget.transform.position) * Mathf.Lerp(-30f, -100f, (Vector3.Distance(kakachico.transform.position, webtarget.transform.position) / 50f)) * Time.deltaTime, ForceMode.Force);
        }

        if (Vector3.Distance(kakachico.transform.position, webtarget.transform.position) > 50f)
        {
            ReleaseWeb();
        }
    }
}
