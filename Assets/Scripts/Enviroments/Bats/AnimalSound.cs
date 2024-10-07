using System;
using UnityEngine;
using UnityEngine.Serialization;

public class AnimalSound : MonoBehaviour
{
    [SerializeField] private AudioClip _animalSound;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayAnimalSound()
    {
        _audioSource.PlayOneShot(_animalSound);
    }
}
