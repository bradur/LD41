
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum SoundType
{
    None
}

public class SoundManager : MonoBehaviour
{

    public static SoundManager main;

    [SerializeField]
    private List<GameSound> sounds = new List<GameSound>();

    private bool sfxMuted = false;


    void Awake()
    {
        main = this;
    }

    private void Update()
    {

    }

    private void Start()
    {

    }

    public void PlaySound(SoundType soundType)
    {
        if (!sfxMuted)
        {
            foreach (GameSound gameSound in sounds)
            {
                if (gameSound.soundType == soundType)
                {
                    if (gameSound.sound.isPlaying)
                    {
                        gameSound.sound.Stop();
                    }
                    gameSound.sound.Play();
                }
            }
        }
    }

    public void StopSound(SoundType soundType)
    {
        if (!sfxMuted)
        {
            foreach (GameSound gameSound in sounds)
            {
                if (gameSound.soundType == soundType && gameSound.sound.isPlaying)
                {
                    gameSound.sound.Stop();
                }
            }
        }
    }

    public void ToggleSfx()
    {
        sfxMuted = !sfxMuted;
    }

}

[System.Serializable]
public class GameSound : System.Object
{
    public SoundType soundType;
    //public Action actionType;
    public AudioSource sound;
    public List<AudioSource> sounds;
}
