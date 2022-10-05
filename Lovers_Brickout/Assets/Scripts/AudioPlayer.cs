using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource musicAudio;
    [SerializeField] private AudioSource sfxAudio;

    public static AudioPlayer instance;

    private void Awake()
    {
        instance = this;
    }

    public void TocarMusica(AudioClip _musica)
    {
        musicAudio.clip = _musica;
        musicAudio.Play();
    }

    public void PararMusica()
    {
        musicAudio.Stop();
    }

    public void TocarSFX(AudioClip _efeitoSonoro)
    {
        sfxAudio.PlayOneShot(_efeitoSonoro);
    }

    public void PararSFX()
    {
        sfxAudio.Stop();
    }
}
