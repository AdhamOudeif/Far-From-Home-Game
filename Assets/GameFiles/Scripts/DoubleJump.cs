using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoubleJump : MonoBehaviour
{
    public static int DoubleJumpTimer =0;
    public Text doubleJumpText;
    // Start is called before the first frame update
    void Start()
    {
        doubleJumpText.text = DoubleJumpTimer.ToString();
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

