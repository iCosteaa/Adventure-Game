using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rbg;
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float jumpAcceleration = 5f;
    [SerializeField] float speedAcceleration = 2f;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    void Start()
    {
        rbg = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rbg.velocity = new Vector3(horizontalInput * movementSpeed, rbg.velocity.y, verticalInput * movementSpeed);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }
	    
        if (Input.GetKey (KeyCode.LeftShift) && Input.GetKey ("w") && IsGrounded()){
            rbg.velocity = new Vector3(horizontalInput * movementSpeed, rbg.velocity.y, verticalInput * movementSpeed * speedAcceleration);
        }

    }

    void Jump()
    {
        rbg.velocity = new Vector3(rbg.velocity.x, jumpAcceleration, rbg.velocity.z);
    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, 0.1f, ground); //verificam daca distanta dintre doua obiecte este de macar 0.1 unitati
    }
}
