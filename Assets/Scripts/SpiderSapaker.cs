using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderSapaker : MonoBehaviour
{
    [SerializeField] private Renderer modelRenderer;
    [SerializeField] private bool isSapaking;
    [SerializeField] private Material matDormant;
    [SerializeField] private Material matActive;

    private void Awake()
    {
        modelRenderer.material = matDormant;
    }

    public void ActivateSapaker()
    {
        isSapaking = true;
        modelRenderer.material = matActive;
    }

    public void DeactivateSapaker()
    {
        isSapaking = false;
        modelRenderer.material = matDormant;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isSapaking)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                collision.transform.position += (Vector3.up * 5);
                collision.transform.GetComponent<EntityScript>().TakeDamage(12f);
                collision.transform.GetComponent<CharacterImpactStuff>().AddImpact(transform.position - collision.transform.position, -5f);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isSapaking)
        {
            if (other.gameObject.tag == "Enemy")
            {
                other.GetComponent<EntityScript>().TakeDamage(12f);
                other.GetComponent<CharacterImpactStuff>().AddImpact(transform.position - other.transform.position, -5f);
            }
        }
    }
}
