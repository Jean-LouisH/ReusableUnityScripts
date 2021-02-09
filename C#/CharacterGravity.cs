using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGravity : MonoBehaviour
{
    private CharacterController characterController;
    private Vector3 characterVelocity = Vector3.zero;
    private float gravity = -9.81f;

    void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
    }

    public Vector3 CalculateVelocity()
    {
        if (characterController.isGrounded && characterVelocity.y < 0.0f)
        {
            characterVelocity.y = 0.0f;
        }

        characterVelocity.y += gravity * Time.deltaTime;
        return characterVelocity;
    }
}
