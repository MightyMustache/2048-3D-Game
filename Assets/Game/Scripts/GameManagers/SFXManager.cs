using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SFXManager : MonoBehaviour
{
    [Inject]
    private DataLoader _dataLoader;
    private AudioSource _sfxSource;

    private AudioClip _MergeSFX;
    private AudioClip _CollideSFX;
    private AudioClip _ThrowSFX;



    private void Start()
    {
        _sfxSource = GetComponent<AudioSource>();

        _MergeSFX = _dataLoader.SFX[0];
        _ThrowSFX = _dataLoader.SFX[1];
        _CollideSFX = _dataLoader.SFX[2];

    }

    public void PlayMergeSFX()
    {
        _sfxSource.PlayOneShot(_MergeSFX);
    }

    public void PlayThrowSFX()
    {
        _sfxSource.PlayOneShot(_ThrowSFX);
    }

    public void PlayCollideSFX()
    {
        _sfxSource.PlayOneShot(_CollideSFX);
    }
}
