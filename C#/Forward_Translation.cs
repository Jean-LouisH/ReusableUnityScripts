using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forward_Translation : MonoBehaviour
{
    public Transform transform;
    public float forwardSpeed;
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * forwardSpeed);
    }
}
