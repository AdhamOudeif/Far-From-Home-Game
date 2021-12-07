using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{
    public static float currentTime = 300f;
    public static float jumpTime = 0;
    public Text jumpTimeText;
    public Text levelTimer;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = 300;
    }

    // Update is called once per frame
    void Update()
    {
        TimerFormat();
        currentTime -= Time.deltaTime;

        TimeRanOut();
        doubleJumpTime();
    }
    private void TimerFormat()
    {
        if(currentTime >= 100f)
        {
            levelTimer.text = currentTime.ToString("#");
        }
        if (currentTime >= 10f && currentTime <= 100f)
        {
            levelTimer.text = currentTime.ToString("#.#");
        }
        if (currentTime <= 10f)
        {
            levelTimer.text = currentTime.ToString("#.##");
        }
    }

    private void TimeRanOut()
    {
        if(currentTime <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    private void doubleJumpTime()
    {
        if(Player.jumpTimer == true)
        {
            jumpTime -= Time.deltaTime;
            jumpTimeText.text = jumpTime.ToString("#.#");
        }
    }
}
