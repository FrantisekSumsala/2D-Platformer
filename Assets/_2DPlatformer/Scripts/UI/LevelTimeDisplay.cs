using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelTimeDisplay : MonoBehaviour
{
    [SerializeField]
    private TimeCounter timeCounter;

    [SerializeField]
    private TMP_Text timeDisplayText;


    private void LateUpdate()
    {
        float time = timeCounter.LevelTime / 1000;
        timeDisplayText.text = $"{timeCounter.LevelTime.ToString("0.000")}s";
    }
}
