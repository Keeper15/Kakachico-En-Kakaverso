using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class KakachicoHand : MonoBehaviour
{
    [SerializeField] private GameObject webthread;
    [SerializeField] private GameObject webtarget;
    [SerializeField] private GameObject websling;
    [SerializeField] private GameObject kakachico;

    [SerializeField] private Transform webShootSpawn;

    [SerializeField] private bool isPunchReady;

    [SerializeField] InputActionReference inputActionReference_Activate;
    [SerializeField] InputActionReference inputActionReference_Select;
    [SerializeField] private bool isHoldingSomething = false;

    [SerializeField] private ActionBasedController controller;
    [SerializeField] private Animator handAnimator;

    private void OnEnable()
    {
        inputActionReference_Activate.action.performed += Activate;
        inputActionReference_Activate.action.canceled += Deactivate;

        inputActionReference_Select.action.performed += Select;
        inputActionReference_Select.action.canceled += Deselect;
    }

    private void OnDisable()
    {
        inputActionReference_Activate.action.performed -= Activate;
        inputActionReference_Activate.action.canceled -= Deactivate;

        inputActionReference_Select.action.performed -= Select;
        inputActionReference_Select.action.canceled -= Deselect;
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (handAnimator == null)
            handAnimator = controller.model.GetComponent<Animator>();
        ReelWeb();
    }

    public void Activate(InputAction.CallbackContext obj)
    {
        if (isHoldingSomething)
        {

        }

        else
        {
            ShootWeb();
        }
    }

    public void Deactivate(InputAction.CallbackContext obj)
    {
        if (isHoldingSomething)
        {

        }

        else
        {
            ReleaseWeb();
        }
    }

    public void Select(InputAction.CallbackContext obj)
    {
        ReadyPunch();
    }

    public void Deselect(InputAction.CallbackContext obj)
    {
        UnreadyPunch();
    }

    private void ShootWeb()
    {
        Debug.Log("ShootWeb is called");   

        if (webtarget == null)
        {
            GameObject webshot = Instantiate(websling, webShootSpawn.position, webShootSpawn.rotation);
            webtarget = webshot;
        }

        handAnimator.SetBool("isShootingWeb", true);

        webthread.SetActive(true);
        webthread.GetComponent<webthread>().secondthing = webtarget;
    }

    private void ReleaseWeb()
    {
        Debug.Log("ReleaseWeb is called");
        if (webtarget == null) return;

        if (webtarget.GetComponent<WebSling>().landed)
        {
            kakachico.GetComponent<Rigidbody>().AddForce((kakachico.transform.position - webtarget.transform.position) * -2f, ForceMode.Impulse);
            kakachico.GetComponent<Rigidbody>().AddForce(kakachico.transform.forward * 1f, ForceMode.Impulse);
            kakachico.GetComponent<Rigidbody>().AddForce(kakachico.transform.up * 10f, ForceMode.Impulse);
        }

        handAnimator.SetBool("isShootingWeb", false);

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

    private void ReadyPunch()
    {
        isPunchReady = true;
        handAnimator.SetBool("isPunching", true);
    }

    private void UnreadyPunch()
    {
        isPunchReady = false;
        handAnimator.SetBool("isPunching", false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isPunchReady && !isHoldingSomething)
        {
            if (other.transform.GetComponent<EntityScript>() != null)
            {
                other.transform.GetComponent<EntityScript>().TakeDamage(12f);
                //other.transform.GetComponent<CharacterImpactStuff>().AddImpact(transform.position - other.transform.position, -10f);
            }
        }
    }

    public void SetIsHoldingSomething(bool val)
    {
        isHoldingSomething = val;
        handAnimator.SetBool("isHoldingGun", val);
    }
}
