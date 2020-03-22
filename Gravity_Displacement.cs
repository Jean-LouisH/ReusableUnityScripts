using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity_Displacement : MonoBehaviour
{
    public Transform transform;
    public float gravity;

    private float yVelocity = 0.0f;

    void Start()
    {
        yVelocity = -gravity;
    }

    void FixedUpdate()
    {
        transform.Translate(0.0f, yVelocity * Time.deltaTime, 0.0f);
    }

    void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.tag == "Ground")
        {
            transform.position.Set(transform.position.x, 
                otherCollider.transform.position.y + otherCollider.bounds.size.y, transform.position.z);
            yVelocity = 0.0f;
        }
    }

    void OnTriggerExit(Collider otherCollider)
    {
        if (otherCollider.tag == "Ground")
        {
            transform.Translate(0.0f, gravity * Time.deltaTime, 0.0f);
            yVelocity = -gravity;
        }
    }
}
