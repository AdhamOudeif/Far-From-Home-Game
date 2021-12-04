using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickaxePickup : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Text PickaxeText;

    private void Start()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        //PickaxeText.text = PickaxeText.ToString();
        PickaxeText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If player collieds with coin
        if (collision.gameObject.tag == "Player")
        {
            PickaxeText.gameObject.SetActive(true);
            FindObjectOfType<AudioManager>().Play("PowerUP"); // Play sound
            //add score destroy coin
            Destroy(this.gameObject);
        }

    }
}
