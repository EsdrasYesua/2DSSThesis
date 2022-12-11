using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
   public Rigidbody2D playerRb;
   public float speed;
   public float input;
   public SpriteRenderer spriteRenderer;
   public float jumpForce;

   public LayerMask groundLayer;
   private bool isGrounded;
   public Transform feetPosition;
   public float groundCheckCircle;

   public float jumpTime = 0.35f;
   public float jumpTimeCounter;
   private bool isJumping;

   public Animator animator;

  void Update()
   {
    input = Input.GetAxisRaw("Horizontal");


    animator.SetFloat("Speed", Mathf.Abs(input));

        if(input<0)
        {
            spriteRenderer.flipX = true;
        }
        else if (input>0)
        {
            spriteRenderer.flipX= false;
        }

        isGrounded = Physics2D.OverlapCircle(feetPosition.position, groundCheckCircle,groundLayer);

        if (isGrounded == true && Input.GetButton("Jump"))
        {   
            isJumping = true;
            jumpTimeCounter = jumpTime;
            playerRb.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetButton("Jump") && isJumping == true)
        {
            if(jumpTimeCounter>0)
            {
                
             playerRb.velocity = Vector2.up * jumpForce;
             jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
          
        }

        if(Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }


   }

  void FixedUpdate()
   {
    playerRb.velocity = new Vector2 (input * speed, playerRb.velocity.y);
   }

}
