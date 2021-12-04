using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{

    [SerializeField] private float JumpForce = 15f;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private LayerMask WhatIsGround;
    float timer = 15;    //for Double Jump
    

    private bool m_FacingRight = true;  // For determining which way the player is currently facing.
    private bool m_Grounded;            // Whether or not the player is grounded.
    //public CharacterController2D controller;
    private Rigidbody2D rb;
    public Animator animator;

    private Vector3 respawnPoint;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        respawnPoint = transform.position;
    }

    void Update()
    {
        //left and right
        var movement = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(movement));
        // If the input is moving the player right and the player is facing left...
        if (movement > 0 && !m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (movement < 0 && m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        //deltaTime stuff to smooth out movement
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * moveSpeed;

        //jumping
        //checks to see, firstly, if player is pressing jump button, AND that the player isn't already moving thru the air.
        if(Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.0001)
        {
            FindObjectOfType<AudioManager>().Play("Jump"); // Play sound
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
	        animator.SetBool("isJumping", true);

        }else if(Mathf.Abs(rb.velocity.y) < 0.000001)
        {
            animator.SetBool("isJumping", false);
        }

        //crouch
        if (Input.GetButtonDown("Crouch"))
        {
            animator.SetBool("isCrouching", true);
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            animator.SetBool("isCrouching", false);
        }

        //Reset Jumpforce if Double Jump is on
        if (JumpForce == 8) 
        {
            timer -= Time.deltaTime;
             
            if (timer <= 0)
            {
                JumpForce = 6;
                timer = 0;
                
            }
            
        }
     

    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    //If interacting with doubleJump Token
    void OnTriggerEnter2D(Collider2D other)
    {
        //player collides w/ doublejump
        if (other.CompareTag("DoubleJump"))
        {
            JumpForce = 8;
        }
        //player collides w/ enemy or trap
        if (other.gameObject.tag == "Trap" || other.gameObject.tag == "Enemy")
        {
            transform.position = respawnPoint;
        }
        //redundant code?
        if(other.gameObject.tag =="Enemy")
        {
            transform.position = respawnPoint;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag =="Enemy")
        {
            transform.position = respawnPoint;
        }
        
    }


}
