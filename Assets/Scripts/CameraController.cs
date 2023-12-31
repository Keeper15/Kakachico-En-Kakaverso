using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject target;

    private float rotationX, rotationY;

    [SerializeField]
    private float headRotationLimit = 60f;

    // Start is called before the first frame update
    void Start()
    {
        //Make sure the cursor stays in the center of the screen
        //Change the lock state of our cursor
        Cursor.lockState = CursorLockMode.Locked;
    }


    // Update is called once per frame
    private void Update()
    {
        //look up and down is based on the x-axis rotation
        rotationX += Input.GetAxis("Mouse Y") * 2.6f;
        //look left and right is based on the y-axis rotation
        rotationY += Input.GetAxis("Mouse X") * 2.6f;

        //Limit the value of our lookup/down based on the head rotation value
        rotationX = Mathf.Clamp(rotationX, -headRotationLimit, headRotationLimit);
    }

    private void LateUpdate()
    {
        //rotate the camera to face our mouse direction
        Quaternion rotation = Quaternion.Euler(-rotationX, rotationY, 0);
        transform.rotation = rotation;

        //make the camera follow the target
        transform.position = new Vector3( target.transform.position.x, target.transform.position.y + 0.4f, target.transform.position.z);
        //rotate the target to face the camera direction
        target.transform.rotation = Quaternion.Euler(
            target.transform.rotation.x,
            rotationY,
            target.transform.rotation.z);
    }
}
