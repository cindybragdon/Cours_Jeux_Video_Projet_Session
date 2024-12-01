// Ce script permet de contrôler un joueur en vue à la première personne dans Unity. Il gère le déplacement du joueur
// en fonction des entrées de l'utilisateur et permet au joueur de sauter s'il est au sol.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonPlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    public float gravity = -9.81f;

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Prevents the player from tipping over
    }

    void Update()
    {
        MovePlayer();
        // HandleJump();
    }

    void MovePlayer()
    {
        // Get input for movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Calculate movement direction relative to player orientation
        Vector3 move = transform.right * x + transform.forward * z;
        Vector3 moveVelocity = move * speed;

        // Apply movement
        rb.linearVelocity = new Vector3(moveVelocity.x, rb.linearVelocity.y, moveVelocity.z);
    }

    void HandleJump()
    {
        // Check if player is grounded
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);

        // Jump logic
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
