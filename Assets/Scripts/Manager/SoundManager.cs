using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour
{
    //Summary
    //Handles the playing of sound effects by spawning a sfx object on the location it is requested, sets volume, gathers the clip, plays the sound, plays the sound for the entire clip length, and then destroys the object after.
    //Summary
    public static SoundManager instance;
    [SerializeField] private AudioSource soundFXObject;
    
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PlaySoundFXClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.Play();
        float clipLength = audioSource.clip.length;
        Destroy(audioSource.gameObject, clipLength);
    }
}
