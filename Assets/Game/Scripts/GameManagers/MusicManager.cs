using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MusicManager : MonoBehaviour
{
    [Inject]
    private DataLoader _dataLoader;
    private AudioSource _musicSource;

    private AudioClip _backGroudAudio;
    private AudioClip _booAudio;
    private AudioClip _hoorayAudio;



    private void Start()
    {
        _musicSource = GetComponent<AudioSource>();

        _backGroudAudio = _dataLoader.Music[0];
        _hoorayAudio = _dataLoader.Music[1];
        _booAudio = _dataLoader.Music[2];
        
    }

    public void PlayBackGroudMusic()
    {
        PlayClip(_backGroudAudio, loop: true);
    }

    public void PlayHoorayMusic()
    {
        PlayClip(_hoorayAudio, loop: false);
    }
    public void PlayBooMusic()
    {
        PlayClip(_booAudio, loop: false);
    }
    


    private void PlayClip(AudioClip clip, bool loop)
    {
        if (clip == null) return;

        _musicSource.clip = clip;
        _musicSource.loop = loop;
        _musicSource.Play();
    }
}
