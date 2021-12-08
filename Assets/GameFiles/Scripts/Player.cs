using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{

    [SerializeField] private float JumpForce = 15f;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private LayerMask WhatIsGround;
    [SerializeField] private GameObject pickaxeSwing;
    float timer = 0;    //for Double Jump
    public GameObject jumpText;
    public static bool jumpTimer = false;
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.
    private bool m_Grounded;            // Whether or not the player is grounded.
    private bool hasPickaxe = false;
    //public CharacterController2D controller;
    private Rigidbody2D rb;
    public Animator animator;

    private Vector3 respawnPoint;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        respawnPoint = transform.position;
        jumpText.SetActive(false);
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
        //swing pickaxe
        if(Input.GetButtonDown("pickaxe") && hasPickaxe)
        {
            //putting these here so unity doesn't throw a fit
            if (pickaxeSwing != null)
            {
                //grabbing mouse pos
                Vector3 mousePosition = Input.mousePosition;
                mousePosition = UnityEngine.Camera.main.ScreenToWorldPoint(mousePosition);

                //grabbing direction that swing should face
                Vector3 direction = new Vector3(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

                //creating swing sprite
                var swing = Instantiate(pickaxeSwing, transform.position + (transform.forward * 2), transform.rotation);
                swing.transform.up = direction;
                swing.transform.Translate(0, 0.75f, 0);
                //destroying it after 1 sec
                Destroy(swing, 0.15f);
            }
            //Destroy(swing, 1);
        }

        //Reset Jumpforce if Double Jump is on
        if (JumpForce == 8) 
        {
            timer -= Time.deltaTime;
             
            if (timer <= 0)
            {
                JumpForce = 6;
                timer = 15;
                jumpText.SetActive(false);
                jumpTimer = false;

            }
            
        }
    }
    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        // Vector3 theScale = transform.localScale;
        //theScale.x *= -1;
        //transform.localScale = theScale;
        transform.Rotate(0f, 180f, 0f);
    }

    //If interacting with doubleJump Token
    void OnTriggerEnter2D(Collider2D other)
    {
        //player collides w/ doublejump
        if (other.CompareTag("DoubleJump"))
        {
            jumpTimer = true;
            jumpText.SetActive(true);
            JumpForce = 8;
            timer += 15;
            Timer.jumpTime += 15;
        }
        if (other.CompareTag("Pickaxe"))
        {
            hasPickaxe = true;
        }
        //player collides w/ enemy or trap
        if (other.gameObject.tag == "Trap" || other.gameObject.tag == "Enemy")
        {
            transform.position = respawnPoint;
        }
        if(other.CompareTag("Checkpoint"))
        {
            respawnPoint = transform.position;
            FindObjectOfType<AudioManager>().Play("CP"); // Play sound
        }
       
       

    }

   


}
