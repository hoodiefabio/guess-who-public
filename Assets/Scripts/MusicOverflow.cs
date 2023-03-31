using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicOverflow : MonoBehaviour
{
    private AudioSource bgm;
    public bool muted = false;
    
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        bgm = GetComponent<AudioSource>();
    }

    public void PlayMusic()
    {
        if (bgm.isPlaying) return;
        bgm.Play();
    }
}
