using System;
using UnityEngine;

public class ChangeMusic : MonoBehaviour
{
    [SerializeField] private AudioClip _bossTheme;
    private AudioClip _mainTheme;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _mainTheme = _audioSource.clip;
    }
    
    public void ChangeToMainTheme()
    {
        _audioSource.clip = _mainTheme;
        _audioSource.Play();
    }

    public void ChangeToBossTheme()
    {
        _audioSource.clip = _bossTheme;
        _audioSource.Play();
    }

    public void ChangeVolume()
    {
        _audioSource.volume = Mathf.MoveTowards(0, 0.1f , Time.deltaTime * 2);
    }
}
