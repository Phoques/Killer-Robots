using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{

    public AudioSource caught;
    public AudioSource found;
    public AudioSource music;



    public void PlayCaught()
    {
        caught.Play();
    }

    public void PlayFound()
    {
        found.Play();
    }

    public void StartChaseMusic()
    {
        music.Play();
    }
    public void StopChaseMusic()
    {
        if (music.isPlaying)
        {
            music.Stop();
        }
        else return;
    }
}
