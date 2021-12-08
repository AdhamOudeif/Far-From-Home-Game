using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 5;
    public Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        FindObjectOfType<AudioManager>().Play("FireBall"); // Play sound
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
       if (hitInfo.name != "Player")
       {
            Destroy(gameObject);
       }
       //if it hits nothing
       else
       {
            Destroy(gameObject, 1);
       }
    }
}
