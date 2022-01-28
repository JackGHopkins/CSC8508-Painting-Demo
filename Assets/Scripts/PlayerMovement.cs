using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public CharacterController controller;
    public float speed = 12;
    public float g = -9.81f;

    private Vector3 fallingVelocity;
    private bool isGrounded;
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && fallingVelocity.y < 0)
            fallingVelocity.y = -2f;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        fallingVelocity.y += g * Time.deltaTime;

        controller.Move(fallingVelocity * Time.deltaTime);
    }
}
