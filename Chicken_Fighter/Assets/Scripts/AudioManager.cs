using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource, sfxSource;
    [SerializeField] AudioClip musicClip, defeatMusic, coinSound, defeatSound;
    private void Start()
    {
        PlayMusic(musicSource);
    }

    public void PlayMusic(AudioSource musicSource)
    {
        musicSource.Stop();
        if (GameManager.IsPaused) { musicSource.clip = defeatMusic; }
        if (!GameManager.IsPaused) { musicSource.clip = musicClip; }
        musicSource.Play();
    }
    public void PlayCoinSFX(AudioSource sfxSource)
    {
        sfxSource.clip = coinSound;
        sfxSource.Play();
    }
    public void PlayGeneralSFX(AudioSource sfxSource, AudioClip clip)
    {
        sfxSource.clip = clip;
        sfxSource.Play();
    }
}
