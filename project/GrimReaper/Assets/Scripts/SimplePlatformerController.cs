using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlatformerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 8f;
    public float gravity = 20f;

    private CharacterController characterController;
    private Vector3 velocity;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Get the horizontal input (left/right arrow keys, A/D keys, or joystick)
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate movement direction based on input
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, 0f);

        // Move the player
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);

        // Handle jumping
        if (characterController.isGrounded)
        {
            velocity.y = -0.5f; // Reset vertical velocity when grounded

            if (Input.GetButtonDown("Jump"))
            {
                velocity.y = Mathf.Sqrt(2f * jumpForce * gravity);
            }
        }

        // Apply gravity
        velocity.y -= gravity * Time.deltaTime;

        // Move the player vertically
        characterController.Move(velocity * Time.deltaTime);
    }
}
