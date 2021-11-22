using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Patrol : MonoBehaviour
{
    public float speed;
    public float distance;
    public int Respawn;
    private bool movingRight = true;

    public Transform groundDetection;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if (groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }

    }
    void OnTriggerEnter2D(Collider2D killer)
    {
        if (killer.CompareTag("Player"))
        {

            Player_Health.playerHealth -= 1;
            FindObjectOfType<AudioManager>().Play("Death"); // Play sound

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}