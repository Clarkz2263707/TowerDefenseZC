using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;

public class SoundMixerManager : MonoBehaviour
{
    //Summary
    //Handles the sliders on the options menu to actually raise and lower volume
    //Summary
    [SerializeField] private AudioMixer audioMixer;

    public void SetSoundFXVolume(float level)
    {
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(level) * 20f);
    }

    public void SetMusicVolume(float level)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(level) * 20f);
    }
}
