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
    [SerializeField] float dodgeSpeed;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    [SerializeField] Transform cam;
    Vector2 input;

    public bool firstButtonPressed = false, reset = true;
    public float timeOfFirstButton = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        PlayerMovementNew();
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpAcceleration, rb.velocity.z);
    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, 0.1f, ground); //verificam daca distanta dintre doua obiecte este de macar 0.1 unitati
    }

    void PlayerMovementNew(){
        float rotateHorizontal = Input.GetAxis ("Mouse X");
        float rotateVertical = Input.GetAxis ("Mouse Y");
        
        rb.angularVelocity = new Vector3(rotateVertical * sensitivity, rotateHorizontal * sensitivity, 0f);

        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        input = Vector2.ClampMagnitude(input, 1);
        Vector3 camF = transform.forward, camR = transform.right;

        camF.y = 0; 
        camR.y = 0;
        
        camR = camR.normalized; 
        camF = camF.normalized;
        rb.velocity = (camF * input.y + camR * input.x) * 24 * Time.deltaTime * 30;

        /*   //Dodge attempt */

        if (Input.GetKeyDown(KeyCode.W) && firstButtonPressed)
        {
            if (Time.time - timeOfFirstButton < 0.1f)
            {
                //rb.MovePosition(transform.position + (camF * input.y + camR * input.x) * 100 );
                // rb.AddForce((camF * input.y + camR * input.x) * dodgeSpeed, ForceMode.Impulse);
                rb.velocity = (camF * input.y + camR * input.x) * dodgeSpeed * 100;
                Debug.Log("Double-tapped");
            }
            reset = true;
        }

        if (Input.GetKeyDown(KeyCode.W) && !firstButtonPressed)
        {
            firstButtonPressed = true;
            timeOfFirstButton = Time.time;
        }

        if (reset)
        {
            firstButtonPressed = false;
            reset = false;
        }

        if (Input.GetKeyDown(KeyCode.A) && firstButtonPressed)
        {
            if (Time.time - timeOfFirstButton < 1f)
            {
                //rb.MovePosition(transform.position + (camF * input.y + camR * input.x) * 100 );
                // rb.AddForce((camF * input.y + camR * input.x) * dodgeSpeed, ForceMode.Impulse);
                rb.velocity = (camF * input.y + camR * input.x) * dodgeSpeed * 100;
                Debug.Log("Double-tapped");
            }
            reset = true;
        }

        if (Input.GetKeyDown(KeyCode.A) && !firstButtonPressed)
        {
            firstButtonPressed = true;
            timeOfFirstButton = Time.time;
        }

        if (reset)
        {
            firstButtonPressed = false;
            reset = false;
        }

        if (Input.GetKeyDown(KeyCode.S) && firstButtonPressed)
        {
            if (Time.time - timeOfFirstButton < 1f)
            {
                //rb.MovePosition(transform.position + (camF * input.y + camR * input.x) * 100 );
                // rb.AddForce((camF * input.y + camR * input.x) * dodgeSpeed, ForceMode.Impulse);
                rb.velocity = (camF * input.y + camR * input.x) * dodgeSpeed * 100;
                Debug.Log("Double-tapped");
            }
            reset = true;
        }

        if (Input.GetKeyDown(KeyCode.S) && !firstButtonPressed)
        {
            firstButtonPressed = true;
            timeOfFirstButton = Time.time;
        }

        if (reset)
        {
            firstButtonPressed = false;
            reset = false;
        }

        if (Input.GetKeyDown(KeyCode.D) && firstButtonPressed)
        {
            if (Time.time - timeOfFirstButton < 1f)
            {
                //rb.MovePosition(transform.position + (camF * input.y + camR * input.x) * 100 );
                // rb.AddForce((camF * input.y + camR * input.x) * dodgeSpeed, ForceMode.Impulse);
                rb.velocity = (camF * input.y + camR * input.x) * dodgeSpeed * 100;
                Debug.Log("Double-tapped");
            }
            reset = true;
        }

        if (Input.GetKeyDown(KeyCode.D) && !firstButtonPressed)
        {
            firstButtonPressed = true;
            timeOfFirstButton = Time.time;
        }

        if (reset)
        {
            firstButtonPressed = false;
            reset = false;
        }

        // if (Input.GetButtonUp("Dodge"))
        // {
        //     float dodge = Input.GetAxis("Dodge");


        //     rb.velocity = new Vector3(dodge, 0, 0);

            
        //     rb.MovePosition(transform.position + (rb.velocity * dodgeSpeed + camR * input.x * dodgeSpeed));
            
        // }


        /////////

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }
	    
        if (Input.GetKey (KeyCode.LeftShift) && Input.GetKey ("w") && IsGrounded()){
            rb.velocity = (camF * input.y + camR * input.x) * speedAcceleration * Time.deltaTime * 30;
        }
    }

    // void dodge(){
        

    //     if(Input.GetKeyDown(KeyCode.A) && firstButtonPressed) {
    //          if(Time.time - timeOfFirstButton < 0.5f) {
    //             rb.velocity = (camR * input.x * dodgeSpeed) * Time.deltaTime;
    //          }
    //          reset = true;
    //      }
 
    //      if(Input.GetKeyDown(KeyCode.A) && !firstButtonPressed) {
    //          firstButtonPressed = true;
    //          timeOfFirstButton = Time.time;
    //      }
 
    //      if(reset) {
    //          firstButtonPressed = false;
    //          reset = false;
    //      }
    // }

}

// void PlayerMovement(){                                       OLD
//         float rotateHorizontal = Input.GetAxis ("Mouse X");
//         float rotateVertical = Input.GetAxis ("Mouse Y");

//         rb.angularVelocity = new Vector3(rotateVertical * sensitivity, rotateHorizontal * sensitivity, 0f);

//         input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
//         input = Vector2.ClampMagnitude(input, 1);

//         Vector3 camF = cam.forward;
//         Vector3 camR = cam.right;

//         camF.y = 0;
//         camR.y = 0;
//         camF = camF.normalized;
//         camR = camR.normalized;

//         rb.transform.position += (camF * input.y * movementSpeed + camR * input.x * movementSpeed) * Time.deltaTime * 5;


//         /*   //Dodge attempt

//         if (Input.GetButtonUp("Dodge"))
//         {
//             float dodge = Input.GetAxis("Dodge");


//             rb.velocity = new Vector3(dodge, 0, 0);

            
//             rb.MovePosition(transform.position + (rb.velocity * dodgeSpeed + camR * input.x * dodgeSpeed));
            
//         }*/


//         /////////

//         if (Input.GetButtonDown("Jump") && IsGrounded())
//         {
//             Jump();
//         }
	    
//         if (Input.GetKey (KeyCode.LeftShift) && Input.GetKey ("w") && IsGrounded()){
//             rb.transform.position += ((camF * input.y + camR * input.x) * speedAcceleration) * Time.deltaTime * 5;
//         }
//     }
