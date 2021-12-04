using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] private string portalDestination; //STRING name of scene to load

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //if player runs into the portal
        if (collision.gameObject.tag == "Player")
        {
            //play a sound
            FindObjectOfType<AudioManager>().Play("Portal");
            //then load the new scene
            SceneManager.LoadScene(sceneName:portalDestination);
        }
    }
}
