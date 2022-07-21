using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDodge : MonoBehaviour
{

    Rigidbody rb;
    [SerializeField] float dodgeSpeed;
    /*[SerializeField] float dodgeTime;*/
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

        
    void Update()
    {
       
       
        if (Input.GetButtonUp("Dodge"))
        {
            float dodge = Input.GetAxis("Dodge");
            

            rb.velocity = new Vector3(dodge, 0, 0);

            
            rb.MovePosition(transform.position + rb.velocity * /* Time.deltaTime * */ dodgeSpeed);
            

        }
    }

    /*IEnumerator Dodge()
    {
        float startTime = Time.time;

        while(Time.time < startTime + dodgeTime)
        {
            rb.velocity = new Vector3(dodgeSpeed * Time.deltaTime,0,dodgeSpeed * Time.deltaTime);

            yield return null;
        }
    }*/
}
