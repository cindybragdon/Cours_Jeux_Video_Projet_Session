// Ce script contrôle un joueur dans un jeu Unity. Il permet au joueur de se déplacer horizontalement et verticalement à l'aide des axes d'entrée, de tourner autour de l'axe vertical et de sauter lorsqu'une touche est enfoncée.

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
