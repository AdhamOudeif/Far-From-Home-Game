using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If player collieds with coin
        if(collision.gameObject.tag =="Player")
        {
            FindObjectOfType<AudioManager>().Play("CoinSFX"); // Play sound
            //add score destroy coin
            Score.coins += 1;
            Destroy(this.gameObject);
            
        }
    }
}
