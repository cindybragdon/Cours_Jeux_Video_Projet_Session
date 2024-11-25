using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaireController : MonoBehaviour {

    Animator claireAnimator;

    CapsuleCollider claireCapsule;

    float axisH, axisV;

    [SerializeField]
    float walkSpeed = 2f, runSpeed = 8f, rotSpeed = 100f;

    Rigidbody rb;

    const float timeout = 60.0f;
    [SerializeField] float countdown = timeout;

   

    bool switchFoot = false;

    [SerializeField] bool isJumping = false;

    private void Awake()
    {
        claireAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        claireCapsule = GetComponent<CapsuleCollider>();
    }

    void Update () {

        axisH = Input.GetAxis("Horizontal");
        axisV = Input.GetAxis("Vertical");

        if(axisV>0)
        {
            if(Input.GetKey(KeyCode.LeftControl))
            {
                transform.Translate(Vector3.forward * runSpeed * axisV * Time.deltaTime);
                claireAnimator.SetFloat("run", axisV);
            }
            else
            {
                transform.Translate(Vector3.forward * walkSpeed * axisV * Time.deltaTime);
                claireAnimator.SetBool("walk", true);
                claireAnimator.SetFloat("run", 0);
            }            
        }
        else
        {
            claireAnimator.SetBool("walk", false);
        }

        if (axisH != 0 && axisV == 0)
        {
            claireAnimator.SetFloat("h", axisH);
        }
        else
        {
            claireAnimator.SetFloat("h", 0);
        }


        transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime * axisH);

        if(axisV < 0)
        {            
            claireAnimator.SetBool("walkBack", true);
            claireAnimator.SetFloat("run", 0);
            transform.Translate(Vector3.forward * walkSpeed * axisV * Time.deltaTime);
        }
        else
        {
            claireAnimator.SetBool("walkBack", false);            

        }

        //Debug Dead 

        if(Input.GetKeyDown(KeyCode.AltGr))
        {
            ClaireDead();
        }

        //curve de saut
        if(isJumping)
        claireCapsule.height = claireAnimator.GetFloat("colheight");
              
    }



    public void ClaireDead()
    {
        claireAnimator.SetTrigger("dead");
        GetComponent<ClaireController>().enabled = false;

    }



    public void SwitchIsJumping()
    {
        isJumping = false;
    }
}
