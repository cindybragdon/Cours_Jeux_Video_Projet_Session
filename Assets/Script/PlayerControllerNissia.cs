using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    float axisH, axisV;
    Rigidbody rb;
    [SerializeField] float speed = 2f, rotSpeed = 20f, jumpForce = 500f;
 
 
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update () {
 
        axisH = Input.GetAxis("Horizontal");
        axisV = Input.GetAxis("Vertical");
 
        transform.Translate(Vector3.forward * speed * axisV * Time.deltaTime);        
        transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime * axisH);
    }
 
    private void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = Vector3.zero;
            rb.AddForce(Vector3.up * jumpForce );
        }
    }
}
