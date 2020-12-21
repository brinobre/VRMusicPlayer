using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using System;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public AudioClip click;
    public AudioClip[] musicClips;
    private int currentTrack;
    private AudioSource source;
    bool isPlaying;
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void Update()
    {
    }

    public void PlayPause()
    {
        source.PlayOneShot(click, 0.7F);

        if (!isPlaying)
        {
            isPlaying = true;
            source.Play();
            return;
        }
        if (isPlaying)
        {
            isPlaying = false;
            source.Pause();
            return;
        }
        currentTrack--;
        if (currentTrack < 0)
        {
            currentTrack = musicClips.Length - 1;
        }
    }

    IEnumerator WaitForMusicEnd()

    {
        while (source.isPlaying)
        {
            yield return null;

        }
        NextTitle();

    }
    public void NextTitle()
    {       
        source.Stop();
        source.PlayOneShot(click, 0.7F);
        currentTrack++;
        if (currentTrack > musicClips.Length - 1)
        {
            currentTrack = 0;
        }
        source.clip = musicClips[currentTrack];
        source.Play();
    }

    public void PreviousTitle()
    {
        source.Stop();
        source.PlayOneShot(click, 0.7F);
        currentTrack--;
        if (currentTrack < 0)

        {

            currentTrack = musicClips.Length - 1;
        }
        source.clip = musicClips[currentTrack];
        source.Play();

    }

    public void volumeUp()
    {
        source.PlayOneShot(click, 0.7F);
        source.volume++;
    }
    public void volumeDown()
    {
        source.PlayOneShot(click, 0.7F);
        source.volume--;
    }

}