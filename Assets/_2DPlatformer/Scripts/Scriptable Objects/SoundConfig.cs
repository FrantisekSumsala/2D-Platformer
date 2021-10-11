using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "/SoundConfig")]
public class SoundConfig : ScriptableObject
{
    public AudioClip sound;

    [Range(0, 1)]
    public float volume;

    public bool loop;
}
