/*
 * This script kills and respawns player of object attached with this script interacts with Player tag
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    public int Respawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnTriggerEnter2D(Collider2D other)
    {
        //if equal to player tag collides 
        if (other.CompareTag("Player")) {
            SceneManager.LoadScene(Respawn);
            
        }
    }
    
}
