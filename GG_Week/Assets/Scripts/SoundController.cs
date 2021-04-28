using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static SoundController Instance;


    public AudioClip footstep;
    public AudioClip death;
    public AudioClip coin;
    public AudioClip defeat;
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

    public void MakeDeathSound()
    {
        MakeSound(death);
    }

    public void MakeCoinSound()
    {
        MakeSound(coin);
    }
    
    public void MakeDefeatSound()
    {
        MakeSound(defeat);
    }

    private void MakeSound(AudioClip originalClip)
    {
        AudioSource.PlayClipAtPoint(originalClip, transform.position);
    }
}
