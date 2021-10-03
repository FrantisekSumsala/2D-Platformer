using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameSaveData
{
    [System.Serializable]
    public class GameAudioSettings
    {
        public float masterVolume;
        public float bgmVolume;
        public float sfxVolume;
    }

    [System.Serializable]
    public class LevelData
    {
        public string levelName;
        public float clearTime;
    }

    public GameAudioSettings gameAudioSettings;
    public LevelData[] levelData;

    public static GameSaveData GetDefaultGameSaveData()
    {
        GameSaveData saveData = new GameSaveData();

        // audio options
        GameAudioSettings audioSettings = new GameAudioSettings() { 
            masterVolume = 0.5f, 
            bgmVolume = 0.5f, 
            sfxVolume = 0.5f 
        };
        saveData.gameAudioSettings = audioSettings;

        // level data
        LevelData[] levelDatas = new LevelData[10];
        for (int i = 0; i < 10; i++)
        {
            LevelData levelData = new LevelData() { levelName = $"Level{i+1}", clearTime = -1f };
            levelDatas[i] = levelData;
        }
        saveData.levelData = levelDatas;

        return saveData;
    }
}
