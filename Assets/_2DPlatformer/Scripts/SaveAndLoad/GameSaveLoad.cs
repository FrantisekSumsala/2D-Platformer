using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSaveLoad : MonoBehaviour
{
    public static GameSaveLoad Instance { 
        get 
        {
            if (_instance == null)
                _instance = FindObjectOfType<GameSaveLoad>();
            if (_instance == null)
            {
                GameObject go = new GameObject();
                go.AddComponent(typeof(GameSaveLoad));
                Instantiate(go);
                _instance = go.GetComponent<GameSaveLoad>();
            }

            return _instance;
        } 
    }

    public GameSaveData GameData { 
        get
        {
            if (_gameData == null)
            {
                _gameData = gameLoad.LoadGameData();
            }

            return _gameData;
        }
        set
        {
            _gameData = value;
            gameSave.SaveGameData(_gameData);
        }
    }

    private static GameSaveLoad _instance = null;
    private GameSaveData _gameData = null;

    private IGameDataLoader gameLoad;
    private IGameDataSaver gameSave;

    private void Awake()
    {
        JSONGameSave gameSave = new JSONGameSave();
        gameLoad = gameSave;
        this.gameSave = gameSave;

        _gameData = gameLoad.LoadGameData();
    }

}
