using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    //Number of coins
    public static int coins = 0;
    
    public static int coinCount = 0;
    
    //coin text
    public Text coinScore;
    //public Text timeText; TODO: Fix this
    // Start is called before the first frame update
    void Start()
    {
        //convert int to text for display
        coinScore.text = coins.ToString();
      //  timeText.text = time.ToString();
    }

    // Update is called once per frame
    void Update()
    {
  
        coinScore.text = coins.ToString();
   
    }
        
}
