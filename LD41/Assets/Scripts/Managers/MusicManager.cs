// Date   : 22.04.2018 12:17
// Project: LD41
// Author : bradur

using UnityEngine;
using System.Collections;

public enum MusicState
{
    None,
    Menu,
    Driving,
    Shooting
}

public class MusicManager : MonoBehaviour
{

    [SerializeField]
    private AudioSource menuMusic;
    [SerializeField]
    private AudioSource driveMusic;
    [SerializeField]
    private AudioSource shootOutMusic;

    [SerializeField]
    private float volume = 0.568f;

    [SerializeField]
    private MusicState state = MusicState.Menu;

    [SerializeField]
    private bool musicOn = true;

    private float cachedVolume;
    private float cachedMenuVolume;

    void Start()
    {
        cachedVolume = volume;
        cachedMenuVolume = menuMusic.volume;
        if (!musicOn)
        {
            TurnOffMusic();
        }
        PlayMenuMusic();
    }

    public void TurnOnMusic()
    {
        volume = cachedVolume;
        menuMusic.volume = cachedMenuVolume;
    }

    public void TurnOffMusic()
    {
        volume = 0f;
        menuMusic.volume = 0f;
    }

    public void PlayMenuMusic()
    {
        StopMusic();
        menuMusic.Play();
    }

    public void PlayMusic(MusicState musicState)
    {
        state = musicState;
        menuMusic.Stop();
        driveMusic.volume = 0;
        shootOutMusic.volume = 0;
        if (musicState == MusicState.Driving)
        {
            driveMusic.volume = volume;
        }
        else if (musicState == MusicState.Shooting)
        {
            shootOutMusic.volume = volume;
        }

        shootOutMusic.Play();
        driveMusic.Play();
    }

    public void StopMusic()
    {
        menuMusic.Stop();
        shootOutMusic.Stop();
        driveMusic.Stop();
    }

    public void SwitchToState(MusicState musicState)
    {
        state = musicState;
        if (musicState == MusicState.Driving)
        {
            driveMusic.volume = volume;
            shootOutMusic.volume = 0;
        }
        else if (musicState == MusicState.Shooting)
        {
            shootOutMusic.volume = volume;
            driveMusic.volume = 0;
        }
        else if (musicState == MusicState.Menu)
        {
            shootOutMusic.Stop();
            driveMusic.Stop();
            PlayMenuMusic();
            shootOutMusic.volume = 0;
            driveMusic.volume = 0;
        }
    }

}
