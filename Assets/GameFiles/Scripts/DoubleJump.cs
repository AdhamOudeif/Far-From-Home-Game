using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoubleJump : MonoBehaviour
{
    public static float DoubleJumpTimer = 15;
    public Text doubleJumpText;
    public GameObject activeJump;
    public SpriteRenderer spriteRenderer;
    public bool startTimer = false;
    // Start is called before the first frame update
    void Start()
    {
        doubleJumpText.text = DoubleJumpTimer.ToString();
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        doubleJumpText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer == true)
        {
            //DoubleJumpTimer -= Time.deltaTime;
            doubleJumpText.text = DoubleJumpTimer.ToString("F2");
        }
        if (DoubleJumpTimer < 0)
        {
            doubleJumpText.gameObject.SetActive(false);
            activeJump.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If player collides with coin
        if (collision.gameObject.tag == "Player")
        {
            DoubleJumpTimer += 15;
            activeJump.gameObject.SetActive(true);
            startTimer = true;
            FindObjectOfType<AudioManager>().Play("PowerUP"); // Play sound
            //add score destroy coin
            Destroy(this.gameObject);
            doubleJumpText.gameObject.SetActive(true);
            //this.spriteRenderer.enabled = false;
        }

    }
}

