using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static SoundController Instance;


    public AudioClip footstep;
    public AudioClip tombeau;
    public AudioClip platform;
    public AudioClip death;
    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of SoundEffectsHelper!");
        }
        Instance = this;
    }

    public void MakeFootStepSound()
    {
        MakeSound(footstep);
    }

    public void MakeTombeauSound()
    {
        MakeSound(tombeau);
    }

    public void MakePlatformSound()
    {
        MakeSound(platform);
    }

    public void MakeDeathSound()
    {
        MakeSound(death);
    }

    private void MakeSound(AudioClip originalClip)
    {
        AudioSource.PlayClipAtPoint(originalClip, transform.position);
    }
}
