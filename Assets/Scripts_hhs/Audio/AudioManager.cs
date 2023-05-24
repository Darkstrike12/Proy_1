using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Audio[] Music, PlayerSfx, EnvironmentSfx;
    public AudioSource MusicSource, PlayerSfxSource, EnvironmentSfxSource;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic("BGM");
    }

    public void PlayMusic(string name)
    {
        Audio aud = Array.Find(Music, x => x.Name == name);
        if (aud == null)
        {
            Debug.LogWarning("Musica " + name + " No Existe En AudioManager");
        }
        else
        {
            MusicSource.clip = aud.clip;
            MusicSource.volume = aud.volume;
            MusicSource.pitch = aud.pitch;
            MusicSource.loop= aud.loop;
            MusicSource.Play();
        }
    }

    public void PlayPlayerSfx(string name)
    {
        Audio aud = Array.Find(PlayerSfx, x => x.Name == name);
        if (aud == null)
        {
            Debug.LogWarning("Audio " + name + " No Existe En AudioManager");
        }
        else
        {
            PlayerSfxSource.clip = aud.clip;
            PlayerSfxSource.volume = aud.volume;
            PlayerSfxSource.pitch = aud.pitch;
            PlayerSfxSource.Play();
        }
    }

    public void PlayEnvironmentSfx(string name)
    {
        Audio aud = Array.Find(EnvironmentSfx, x => x.Name == name);
        if (aud == null)
        {
            Debug.LogWarning("Audio " + name + " No Existe En AudioManager");
        }
        else
        {
            EnvironmentSfxSource.clip = aud.clip;
            EnvironmentSfxSource.volume = aud.volume;
            EnvironmentSfxSource.pitch = aud.pitch;
            EnvironmentSfxSource.Play();
        }
    }

    public void ToggleMusic()
    {
        MusicSource.mute = !MusicSource.mute;
    }

    public void ToggleAllSfx()
    {
        PlayerSfxSource.mute = !PlayerSfxSource.mute;
        EnvironmentSfxSource.mute = !EnvironmentSfxSource.mute;
    }

    public void MusicVolume(float volume)
    {
        MusicSource.volume = volume;
    }

    public void AllSfxVolume(float volume)
    {
        PlayerSfxSource.volume = volume;
        EnvironmentSfxSource.volume = volume;
    }
}
