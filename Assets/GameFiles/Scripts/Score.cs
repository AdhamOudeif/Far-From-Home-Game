using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    //Number of coins
    public static int coins = 0;
    public float time = 300;
    //coin text
    public Text coinScore;
    public Text timeText;
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
        time -= 1 * Time.deltaTime;
        timeText.text = time.ToString();
        if(time<=0)
        {
            SceneManager.LoadScene("GameOver");
        }
        
    }
        
}
