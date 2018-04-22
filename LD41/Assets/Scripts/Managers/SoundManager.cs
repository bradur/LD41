
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum SoundType
{
    None,
    EnemyShoot,
    PlayerShoot,
    Car
}

public class SoundManager : MonoBehaviour
{

    public static SoundManager main;

    [SerializeField]
    private AudioSource carSound;

    [SerializeField]
    private List<GameSound> sounds = new List<GameSound>();

    private bool sfxMuted = false;


    void Awake()
    {
        main = this;
    }

    [SerializeField]
    private float maxCarPitch = 1f;
    [SerializeField]
    private float minCarPitch = 0.5f;

    public void SetCarSpeed(float percentage)
    {
        float pitchMid = maxCarPitch - minCarPitch;
        float pitch = Mathf.Clamp(minCarPitch + pitchMid * percentage, minCarPitch, maxCarPitch);
        carSound.pitch = pitch;
    }

    private void Update()
    {

    }

    private void Start()
    {

    }

    private AudioSource GetGameSound(GameSound gameSound)
    {
        if (gameSound.sound == null)
        {
            return gameSound.sounds[Random.Range(0, gameSound.sounds.Count - 1)];
        }
        return gameSound.sound;
    }

    public void PlaySound(SoundType soundType)
    {
        if (!sfxMuted)
        {
            foreach (GameSound gameSound in sounds)
            {
                if (gameSound.soundType == soundType)
                {
                    AudioSource audio = GetGameSound(gameSound);
                    if (audio.isPlaying)
                    {
                        audio.Stop();
                    }
                    audio.Play();
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
                if (gameSound.soundType == soundType)
                {
                    AudioSource audio = GetGameSound(gameSound);
                    if (audio.isPlaying)
                    {
                        audio.Stop();
                    }
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
