using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JSONGameSave : IGameDataLoader, IGameDataSaver
{
    private static readonly string savePath = Application.persistentDataPath + "\\GameSave.json";

    public GameSaveData LoadGameData()
    {
        if (!File.Exists(savePath))
        {
            GameSaveData saveData = GameSaveData.GetDefaultGameSaveData();
            SaveGameData(saveData);

            return saveData;
        }

        string saveText = File.ReadAllText(savePath);

        return JsonUtility.FromJson<GameSaveData>(saveText);
    }

    public void SaveGameData(GameSaveData gameData)
    {
        string saveText = JsonUtility.ToJson(gameData);

        File.WriteAllText(savePath, saveText);
    }

}
