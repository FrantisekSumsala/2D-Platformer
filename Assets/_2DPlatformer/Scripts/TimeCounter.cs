using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCounter : MonoBehaviour
{
    public float LevelTime { get; private set; } = 0f;

    private void Update()
    {
        LevelTime += Time.deltaTime;
    }

}
