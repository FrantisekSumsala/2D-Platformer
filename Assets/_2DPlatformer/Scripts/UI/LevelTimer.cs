using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTimer : MonoBehaviour
{
    [SerializeField]
    private TimeCounter timeCounter;

    [SerializeField]
    private GameSaveLoad saveLoad;

    public float ClearTime { get; private set; }

    public float BestClearTime { get; private set; }

    public void GetClearTimes()
    {
        ClearTime = timeCounter.LevelTime;
        var sceneName = SceneManager.GetActiveScene().name;
        var levelNumberString = Regex.Match(sceneName, @"\d+").Value;
        //var levelNumber = int.Parse(sceneName.Substring(4, sceneName.Length - 1));
        var levelNumber = int.Parse(levelNumberString);
        var gameData = saveLoad.GameData;
        var levelData = gameData.levelData[levelNumber - 1];
        var bestTime = levelData.clearTime;

        if (bestTime < 0f || ClearTime < bestTime)
        {
            BestClearTime = ClearTime;
            levelData.clearTime = BestClearTime;
            saveLoad.GameData = gameData;
        }
        else
        {
            BestClearTime = bestTime;
        }

    }
}
