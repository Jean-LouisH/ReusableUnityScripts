using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translation_Relative_To_Camera : MonoBehaviour
{
    public Transform transform;
    public float movementSpeed_m_per_s;
    public Transform cameraTransform;

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
        Vector3 moveDirection = (cameraForward * verticalAxis) + (cameraRight * horizontalAxis);
        transform.Translate(moveDirection * movementSpeed_m_per_s * Time.deltaTime);
    }
}
