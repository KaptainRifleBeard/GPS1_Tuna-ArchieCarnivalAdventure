using System;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volumn; 
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
        
    }


    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        Debug.Log("Sound: " + name);
        s.source.Play();
    }

    void Start()
    {
        Play("BGM");
    }


}








//    public static AudioManager instance;

//DontDestroyOnLoad(gameObject);

//if (instance == null)
//{
//    instance = this;
//}
//else
//{
//    Destroy(gameObject);
//    return;
//}
