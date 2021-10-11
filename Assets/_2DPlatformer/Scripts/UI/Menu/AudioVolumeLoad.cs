using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioVolumeLoad : MonoBehaviour
{
    [SerializeField]
    private Slider masterVolumeSlider;

    [SerializeField]
    private Slider BGMVolumeSlider;

    [SerializeField]
    private Slider SFXVolumeSlider;

    private void Start()
    {
        GameSaveData gameData = GameSaveLoad.Instance.GameData;
        masterVolumeSlider.value = gameData.gameAudioSettings.masterVolume;
        BGMVolumeSlider.value = gameData.gameAudioSettings.bgmVolume;
        SFXVolumeSlider.value = gameData.gameAudioSettings.sfxVolume;

        masterVolumeSlider.onValueChanged.AddListener((newVal) =>
        {
            GameSaveData gameData = GameSaveLoad.Instance.GameData;
            gameData.gameAudioSettings.masterVolume = newVal;
            GameSaveLoad.Instance.GameData = gameData;
        });

        BGMVolumeSlider.onValueChanged.AddListener((newVal) =>
        {
            GameSaveData gameData = GameSaveLoad.Instance.GameData;
            gameData.gameAudioSettings.bgmVolume = newVal;
            GameSaveLoad.Instance.GameData = gameData;
        });

        SFXVolumeSlider.onValueChanged.AddListener((newVal) =>
        {
            GameSaveData gameData = GameSaveLoad.Instance.GameData;
            gameData.gameAudioSettings.sfxVolume = newVal;
            GameSaveLoad.Instance.GameData = gameData;
        });
    }

}
