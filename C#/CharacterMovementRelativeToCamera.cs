using System.Collections;
using UnityEngine;

public class CharacterMovementRelativeToCamera : MonoBehaviour
{
    public float movementSpeed_m_per_s;
    private Transform cameraTransform;

    void Start()
    {
        cameraTransform = gameObject.transform.Find("Camera");
    }

    public Vector3 CalculateVelocity()
    {
        float horizontalAxis = Input.GetAxisRaw("LEFT_AXIS_X");
        float verticalAxis = Input.GetAxisRaw("LEFT_AXIS_Y");
        Vector3 cameraForward = cameraTransform.forward;
        Vector3 cameraRight = cameraTransform.right;
        cameraForward.y = 0.0f;
        cameraRight.y = 0.0f;
        cameraForward.Normalize();
        cameraRight.Normalize();
        return ((cameraForward * verticalAxis) + (cameraRight * horizontalAxis)) * movementSpeed_m_per_s;
    }
}