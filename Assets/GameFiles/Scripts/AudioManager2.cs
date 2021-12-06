using UnityEngine.Audio;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
public class AudioManager2 : MonoBehaviour
{
    public Sound[] sounds; //Audio Array to act as DB for sounds
    public static AudioManager2 instance;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        if (scene.name == "Level2bbbb" || scene.name == "Menu")
        {
            Destroy(gameObject);
            Debug.Log("I am inside the if statement");
        }
    }


        public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound" + name + " not found!");
            return;
        }
        s.source.Play();
    }
}
