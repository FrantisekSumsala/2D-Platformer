using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUnlockCheck : MonoBehaviour
{
    [SerializeField]
    private GameSaveLoad saveLoad;

    [SerializeField]
    private int levelIndex;

    [SerializeField]
    private UnityEngine.UI.Button button;

    [SerializeField]
    private TMPro.TMP_Text buttonText;

    [SerializeField]
    private Color disabledButtonTextColor;

    private void OnEnable()
    {
        var gameData = saveLoad.GameData;
        var levelData = gameData.levelData[levelIndex];

        if (levelData.clearTime < 0f)
        {
            button.interactable = false;
            buttonText.color = disabledButtonTextColor;
        }

    }

}
