using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Tilt : MonoBehaviour
{
    public Transform transform;
    public Transform cameraTransform;
    public float tiltSpeed;
    public float tiltExtent;

    private Vector3 previousTiltDirection;

    void Start()
    {
        previousTiltDirection = Vector3.zero;
    }

    void FixedUpdate()
    {
        float horizontalAxis = Input.GetAxisRaw("Horizontal");
        float verticalAxis = Input.GetAxisRaw("Vertical");
        Vector3 cameraForward = cameraTransform.forward;
        Vector3 cameraRight = cameraTransform.right;
        cameraForward.y = 0.0f;
        cameraRight.y = 0.0f;
        cameraForward.Normalize();
        cameraRight.Normalize();
        Vector3 tiltDirection = - (cameraForward * horizontalAxis) + (cameraRight * verticalAxis);
        //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles - (previousTiltDirection * tiltExtent));
        //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + (tiltDirection * tiltExtent));
        transform.Rotate(-(previousTiltDirection * tiltExtent));
        transform.Rotate((tiltDirection * tiltExtent));
        this.previousTiltDirection = tiltDirection;
        //transform.Rotate(moveDirection * tiltSpeed * Time.deltaTime);

    }
}
