using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using System;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{

    public AudioClip[] musicClips;
    private int currentTrack;
    private AudioSource source;
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void Update()
    {
        void OnCollisionEnter(Collision collision)
            {
                if (collision.collider.tag == "finger")
                {
                    PlayMusic();
                }
            }
    }


    public void PlayMusic()
    {
        if (!source.isPlaying)
        {
            source.Play();
            
        }
        currentTrack--;
        if (currentTrack < 0)
        {
            currentTrack = musicClips.Length - 1;
        }
        StartCoroutine(WaitForMusicEnd());
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
            currentTrack++;
            if (currentTrack > musicClips.Length - 1)
            {
                currentTrack = 0;
            }
            source.clip = musicClips[currentTrack];
            source.Play();
            //show title

            StartCoroutine(WaitForMusicEnd());

        }

        public void PreviousTitle()
        {
            source.Stop();
            currentTrack--;
            if (currentTrack < 0)

            {

                currentTrack = musicClips.Length - 1;
            }
            source.clip = musicClips[currentTrack];
            source.Play();


            //Title

            StartCorounine(WaitForMusicEnd());
            Debug.Log("PreviousSong");

        }

    private void StartCorounine(IEnumerator enumerator)
    {
        throw new NotImplementedException();
    }

    public void StopMusic()

        {
            StopCoroutine("WaitForMusicEnd");
            source.Stop();
            Debug.Log("Stop");

        }

    private new void StopCoroutine(string v)
    {
        throw new NotImplementedException();
    }

    public void MuteMusic()
        {
            source.mute = !source.mute;
            Debug.Log("Mute");
        }

    
}