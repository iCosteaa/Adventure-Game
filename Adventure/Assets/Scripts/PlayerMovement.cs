using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float jumpAcceleration = 5f;
    [SerializeField] float speedAcceleration = 2f;
    [SerializeField] float sensitivity = 2f;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    [SerializeField] Transform cam;
    Vector2 input;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        PlayerMovement2();
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpAcceleration, rb.velocity.z);
    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, 0.1f, ground); //verificam daca distanta dintre doua obiecte este de macar 0.1 unitati
    }

    void PlayerMovement2(){
        float rotateHorizontal = Input.GetAxis ("Mouse X");
        float rotateVertical = Input.GetAxis ("Mouse Y");  

        rb.angularVelocity = new Vector3(rotateVertical * sensitivity, rotateHorizontal * sensitivity, 0f);

        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        input = Vector2.ClampMagnitude(input, 1);

        Vector3 camF = cam.forward;
        Vector3 camR = cam.right;

        camF.y = 0;
        camR.y = 0;
        camF = camF.normalized;
        camR = camR.normalized;

        rb.transform.position += (camF * input.y * movementSpeed + camR * input.x * movementSpeed) * Time.deltaTime * 5;

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }
	    
        if (Input.GetKey (KeyCode.LeftShift) && Input.GetKey ("w") && IsGrounded()){
            rb.transform.position += ((camF * input.y + camR * input.x) * speedAcceleration) * Time.deltaTime * 5;
        }
    }

}
