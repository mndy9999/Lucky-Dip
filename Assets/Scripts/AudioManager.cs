using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound [] sounds;

    private static AudioManager mInstance;
    public static AudioManager Instance
    {
        get
        {
            if(mInstance == null)
                mInstance = (AudioManager)FindObjectOfType(typeof(AudioManager));
            return mInstance;
        }
    }

    public void PlayPopSound()
    {
        var sound = Array.Find(sounds, s => s.name == "Pop");
        sound.source.Play();
    }


    // Start is called before the first frame update
    void Awake()
    {
        foreach(var s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
        
    }

    private void Start()
    {
        sounds[0].source.loop = true;
        sounds[0].source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
