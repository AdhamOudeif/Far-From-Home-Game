using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossThemePlay : MonoBehaviour
{
  

    int looper = 0;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //if player runs into the portal
        if (collision.gameObject.tag == "Player" && looper == 0)
        {
            looper = 1;
            GetComponent<AudioSource>().Stop();
            FindObjectOfType<AudioManager3>().Play("bossTheme"); // Play sound
        }
    }
}
