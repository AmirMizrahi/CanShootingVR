using UnityEngine.Audio;
using UnityEngine;
using System;

[Serializable]
public class Sound
{
    public string m_Name;
    public AudioClip m_Clip;

    [Range(0f,1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

    [HideInInspector]
    public AudioSource m_Source;
}
