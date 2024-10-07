using System;
using UnityEngine;

public class ChangeMusic : MonoBehaviour
{
    [SerializeField] private AudioClip _bossTheme;
    private AudioClip _mainTheme;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        _mainTheme = audioSource.clip;
    }
    
    public void ChangeToMainTheme()
    {
        audioSource.clip = _mainTheme;
        audioSource.Play();
    }

    public void ChangeToBossTheme()
    {
        audioSource.clip = _bossTheme;
        audioSource.Play();
    }

    public void ChangeVolume()
    {
        audioSource.volume = Mathf.MoveTowards(0, 0.1f , Time.deltaTime * 2);
    }
}
