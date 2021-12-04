using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBlock : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //if the pickaxe hits an ice block
        if (collision.gameObject.tag == "Pickaxe")
        {
            //play a sound
            FindObjectOfType<AudioManager>().Play("Break");
            //then break the block
            Destroy(this.gameObject);
        }
    }
}
