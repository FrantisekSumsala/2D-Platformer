using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioVolumeManager : SingletonMonoBehaviour<AudioVolumeManager>
{
    [SerializeField]
    private AudioMixer mixer;
    
    public void AdjustMasterVolume(float newVal)
    {
        mixer.SetFloat("MasterVolume", Mathf.Log10(newVal) * 20);
    }

    public void AdjustBGMVolume(float newVal)
    {
        mixer.SetFloat("BGMVolume", Mathf.Log10(newVal) * 20);
    }

    public void AdjustSFXVolume(float newVal)
    {
        mixer.SetFloat("VFXVolume", Mathf.Log10(newVal) * 20);
    }

}
