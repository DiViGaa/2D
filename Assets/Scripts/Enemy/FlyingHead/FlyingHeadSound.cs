using UnityEngine;

public class FlyingHeadSound : MonoBehaviour
{
    [SerializeField] private AudioClip _laughter;
    [SerializeField] private AudioClip _death;

    [SerializeField] private AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayLaughterSound()
    {
        _audioSource.PlayOneShot(_laughter);
    }

    public void PlayDeathSound()
    {
        _audioSource.PlayOneShot(_death);
    }
}
