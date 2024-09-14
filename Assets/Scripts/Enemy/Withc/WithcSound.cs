using UnityEngine;

public class WithcSound : MonoBehaviour
{
    [SerializeField] private AudioClip _step;
    [SerializeField] private AudioClip _death;

    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayStepSound()
    {
        _audioSource.PlayOneShot(_step);
    }

    public void PlayDeathSound()
    {
        _audioSource.PlayOneShot(_death);
    }
}
