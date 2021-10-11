using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSlidersEventLinker : MonoBehaviour
{
    [SerializeField]
    private Slider masterVolumeSlider;

    [SerializeField]
    private Slider bgmVolumeSlider;

    [SerializeField]
    private Slider sfxVolumeSlider;

    private void OnEnable()
    {
        var audioManager = AudioVolumeManager.Instance;
        masterVolumeSlider.onValueChanged.AddListener((newVal) => { audioManager.AdjustMasterVolume(newVal); });
        bgmVolumeSlider.onValueChanged.AddListener((newVal) => { audioManager.AdjustBGMVolume(newVal); });
        sfxVolumeSlider.onValueChanged.AddListener((newVal) => { audioManager.AdjustSFXVolume(newVal); });
    }

}
