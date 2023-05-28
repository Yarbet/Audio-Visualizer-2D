using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicRandom : MonoBehaviour
{
    public AudioClip[] clips;
    private AudioSource audioSource;
    private int currentSong = 0;
    
    void Start()
    {
  
        audioSource = FindObjectOfType<AudioSource>();
        audioSource.loop = false;
    }

    public void CambiarClip()
    {
        currentSong++;

        
        if (currentSong >= clips.Length)
        { 
            currentSong = 0;
        }
        audioSource.clip = clips[currentSong];
        audioSource.Play();

        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    /*public void adelantar()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = GetRandomClip();
            audioSource.Play();
        }


    }
    */
}
