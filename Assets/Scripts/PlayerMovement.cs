using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float walkSpeed = 3f;
    public CharacterController controller;
    private float gravity = -16.38f;
    private float jumpHight;

    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;
    bool isGround;

    Vector3 velocity;

    void Update()
    {
        isGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGround && velocity.y < 0)
            velocity.y = -2f; 

        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");

        Vector3 move = transform.right * xMove + transform.forward * zMove;
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
        controller.Move(move * walkSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGround)
            velocity.y = Mathf.Sqrt(jumpHight * -2f * gravity);
    }
}
