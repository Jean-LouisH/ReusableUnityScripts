using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraControls : MonoBehaviour
{
    public float maxOrbitSpeed_deg_per_s = 180.0f;
    public float maxOrbitAcceleration_deg_per_s_sq = 700.0f;
    public float OrbitDeceleration_deg_per_s_sq = 400.0f;

    private Transform targetTransform;
    private Vector2 inclinationVelocity = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        targetTransform = gameObject.transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        OrbitParent();
    }

    private void OrbitParent()
    {
        float horizontalAxis = Input.GetAxisRaw("RIGHT_AXIS_X");
        float verticalAxis = Input.GetAxisRaw("RIGHT_AXIS_X");

        Vector2 targetVelocity = Vector2.right * maxOrbitSpeed_deg_per_s * horizontalAxis;
        float targetAcceleration = maxOrbitAcceleration_deg_per_s_sq * horizontalAxis;

        this.inclinationVelocity += (Vector2.right * targetAcceleration * Time.deltaTime);

        if (this.inclinationVelocity.magnitude > targetVelocity.magnitude &&
           !IsAxisWithinDeadzone(horizontalAxis, verticalAxis, 0.1f))
        {
            this.inclinationVelocity *= targetVelocity.magnitude / this.inclinationVelocity.magnitude;
        }
        else if (IsAxisWithinDeadzone(horizontalAxis, verticalAxis, 0.1f))
        {
            if (this.inclinationVelocity.x > 0)
            {
                this.inclinationVelocity -= Vector2.right * OrbitDeceleration_deg_per_s_sq * Time.deltaTime;
                if (this.inclinationVelocity.x < 0)
                    this.inclinationVelocity.x = 0;
            }
            else
            {
                this.inclinationVelocity += Vector2.right * OrbitDeceleration_deg_per_s_sq * Time.deltaTime;
                if (this.inclinationVelocity.x > 0)
                    this.inclinationVelocity.x = 0;
            }
        }

        transform.RotateAround(targetTransform.position, Vector3.up, this.inclinationVelocity.x * Time.deltaTime);
    }

    private bool IsAxisWithinDeadzone(float horizontalAxis, float verticalAxis, float deadzone)
    {
        return (Mathf.Abs(horizontalAxis) < deadzone && Mathf.Abs(verticalAxis) < deadzone);
    }
}
