using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public Audio[] audios;

    // Start is called before the first frame update
    void Awake()
    {
        foreach(Audio a in audios)
        {
            a.source = gameObject.AddComponent<AudioSource>();
            a.source.clip = a.clip;

            a.source.volume = a.volume;
            a.source.pitch = a.pitch;
        }
    }

    public void Play (string name)
    {
        Audio a = Array.Find(audios, Audio => Audio.name == name);
        a.source.Play();
    }
}
