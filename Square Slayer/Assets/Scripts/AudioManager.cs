using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    public Sound[] sounds;

    // Start is called before the first frame update
    void Awake()
    {

        if (instance == null)
            instance = this;
        else
        {

            Destroy(gameObject);
            return;

        }
            
            

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {

            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

        }

    }

    public void Play (string name)

    {

        Sound s = Array.Find(sounds, sounds => sounds.name == name);

        if (s == null)
        {

            Debug.LogWarning("SOUND: " + name + " NOT FOUND");
            return;

        }
            

        s.source.Play();

    }
}
