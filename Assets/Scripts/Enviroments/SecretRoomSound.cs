using UnityEngine;

public class SecretRoomSound : MonoBehaviour
{
    [SerializeField] private AudioClip _hit;
    [SerializeField] private AudioClip _destroy;

    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayHitSound()
    {
        _audioSource.PlayOneShot(_hit);
    }

    public void PlayDestroySound()
    {
        _audioSource.PlayOneShot(_destroy);
    }
}
