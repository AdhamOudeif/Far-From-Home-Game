using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float JumpForce = 5f;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private LayerMask WhatIsGround;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        //left and right
        var movement = Input.GetAxis("Horizontal");
        //deltaTime stuff to smooth out movement
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * moveSpeed;

        //jumping
        //checks to see, firstly, if player is pressing space, AND that the player isn't already moving thru the air.
        if(Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.0001)
        {
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
    }
}
