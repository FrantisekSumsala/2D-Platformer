using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelTimeDisplay : MonoBehaviour
{
    [SerializeField]
    private LevelTimer levelTimer;

    [SerializeField]
    private TMP_Text clearTimeText;

    [SerializeField]
    private TMP_Text bestClearTimeText;

    private void OnEnable()
    {
        float clearTime = levelTimer.ClearTime / 1000;
        clearTimeText.text = $"{levelTimer.ClearTime.ToString("0.000")}s";
        bestClearTimeText.text = $"{levelTimer.BestClearTime.ToString("0.000")}s";
    }
}
