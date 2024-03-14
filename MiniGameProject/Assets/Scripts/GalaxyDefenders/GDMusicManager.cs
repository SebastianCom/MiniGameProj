using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;

public class GDMusicManager : MonoBehaviour
{
    public AudioClip MenuMusic;
    public AudioClip GameMusic;

    AudioSource Audio;

    GDLevelManager levelManager;

    bool MusicChanged = false;
    // Start is called before the first frame update
    void Start()
    {
        Audio = transform.AddComponent<AudioSource>();
        Audio.clip= MenuMusic;
        Audio.Play();
        Audio.loop = true;

        levelManager = GetComponent<GDLevelManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if(levelManager.CountDown == true && MusicChanged == false) 
        {
            MusicChanged = true;
            Audio.Stop();
            Audio.clip= GameMusic;
            Audio.Play();
            Audio.loop = true;
        }
        
    }
}
