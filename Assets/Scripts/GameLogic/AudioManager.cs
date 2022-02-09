using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[]      m_Sounds;

    void Awake()
    {
        foreach (Sound s in m_Sounds)
        {
            s.m_Source = gameObject.AddComponent<AudioSource>();
            s.m_Source.clip = s.m_Clip;
            s.m_Source.volume = s.volume;
            s.m_Source.pitch = s.pitch;
        }
    }

    public void Play(string name)
    {
        Sound       s = Array.Find(m_Sounds, sound => sound.m_Name == name);
        s.m_Source.Play();
    }
}
