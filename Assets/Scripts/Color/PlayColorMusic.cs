using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayColorMusic : MonoBehaviour
{
    [SerializeField]
    AudioClip neutral, angry, sad, happy, surprised;
    AudioSource source;

    private void Start()
    {
        ColorActions.neutral += PlayNeutral;
        ColorActions.blue += PlaySad;
        ColorActions.yellow += PlayHappy;
        ColorActions.gray += PlaySurprised;
        ColorActions.green += PlayAngry;

        source = GetComponent<AudioSource>();
        source.loop = true;

        PlayNeutral();
    }

    public void PlayNeutral() 
    {
        source.Stop();
        if (neutral !=null)
        {
            source.clip = neutral;
            source.Play();
        }
    }

    public void PlayAngry()
    {
        source.Stop();
        if (angry != null)
        {
            source.clip = angry;
            source.Play();
        }
    }

    public void PlaySad()
    {
        source.Stop();
        if (sad != null)
        {
            source.clip = sad;
            source.Play();
        }
    }

    public void PlaySurprised()
    {
        source.Stop();
        if (surprised != null)
        {
            source.clip = surprised;
            source.Play();
        }
    }

    public void PlayHappy()
    {
        source.Stop();
        if (happy != null)
        {
            source.clip = happy;
            source.Play();
        }
    }
}
