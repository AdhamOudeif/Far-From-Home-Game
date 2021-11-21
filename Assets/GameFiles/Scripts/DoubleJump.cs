using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If player collieds with coin
        if (collision.gameObject.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("CoinSFX"); // Play sound
            //add score destroy coin
            Destroy(this.gameObject);


        }

    }
}

