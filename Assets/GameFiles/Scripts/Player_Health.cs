using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Health : MonoBehaviour
{

    public static int playerHealth = 3;
    public Text healthText;
    void Start()
    {
        healthText.text = playerHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = playerHealth.ToString();
        if(playerHealth <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
   
}
