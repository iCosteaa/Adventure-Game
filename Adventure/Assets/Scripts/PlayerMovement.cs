using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rbg;
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float jumpAcceleration = 5f;
    [SerializeField] float speedAcceleration = 2f;
    [SerializeField] float sensitivity = 2f;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    void Start()
    {
        rbg = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // float horizontalInput = Input.GetAxis("Horizontal");
        // float verticalInput = Input.GetAxis("Vertical");

        // rbg.velocity = new Vector3(horizontalInput * movementSpeed, rbg.velocity.y, verticalInput * movementSpeed);

        // if (Input.GetButtonDown("Jump") && IsGrounded())
        // {
        //     Jump();
        // }
	    
        // if (Input.GetKey (KeyCode.LeftShift) && Input.GetKey ("w") && IsGrounded()){
        //     rbg.velocity = new Vector3(horizontalInput * movementSpeed, rbg.velocity.y, verticalInput * movementSpeed * speedAcceleration);
        // }
        MovePlayer();
        MouseRotate();
    }

    void Jump()
    {
        rbg.velocity = new Vector3(rbg.velocity.x, jumpAcceleration, rbg.velocity.z);
    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, 0.1f, ground); //verificam daca distanta dintre doua obiecte este de macar 0.1 unitati
    }

    void MouseRotate(){
        float rotateHorizontal = Input.GetAxis ("Mouse X");
        float rotateVertical = Input.GetAxis ("Mouse Y");        
        rbg.angularVelocity = new Vector3(rotateVertical * sensitivity, rotateHorizontal * sensitivity,0f);

    }

    void MovePlayer(){
        if(Input.GetKey(KeyCode.W)) {
            rbg.position += Vector3.forward * Time.deltaTime * movementSpeed;
         }
         else if(Input.GetKey(KeyCode.S)) {
             rbg.position += Vector3.back * Time.deltaTime * movementSpeed;
         }
         else if(Input.GetKey(KeyCode.A)) {
             rbg.position += Vector3.left * Time.deltaTime * movementSpeed;
         }
         else if(Input.GetKey(KeyCode.D)) {
             rbg.position += Vector3.right * Time.deltaTime * movementSpeed;
         }
    }
}
