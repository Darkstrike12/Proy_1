using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Audio
{
    public string Name;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    public float pitch;
    public bool loop;

    public AudioSource source;
}
