using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constant_Rotation : MonoBehaviour
{
    public Transform transform;
    public float rotationSpeed;

    void Update()
    {
        transform.Rotate(0.0f, rotationSpeed, 0.0f);
    }
}
