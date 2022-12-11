using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller; 
    public Animator animator;

    public float runSpeed = 60f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));


        if (Input.GetButtonDown("Jump"))
        {
            //Debug.Log(Input.GetButtonDown("Jump"));
            jump = true;
            animator.SetBool("IsJumping", true);
        }


        if(Input.GetButtonDown("Crouch"))
        {
            //Debug.Log(Input.GetButtonDown("Crouch"));
            crouch = true; 
            // animator.SetBool("IsCrouching",true);
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
            // animator.SetBool("IsCrouching",false);
            //Debug.Log(Input.GetButtonUp("Crouch"));
        }

    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching()
    {
        animator.SetBool("IsCrouching", false);
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
        //Debug.Log(Input.GetButtonUp("Jump"));


    }

}