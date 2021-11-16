using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    //Number of coins
    public static int coins = 0;
    //coin text
    public Text coinScore;
    // Start is called before the first frame update
    void Start()
    {
        //convert int to text for display
        coinScore.text = coins.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        coinScore.text = coins.ToString();
    }
}
