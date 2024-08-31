using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] private AudioClip _step;
    [SerializeField] private AudioClip _jump;
    [SerializeField] private AudioClip _landing;
    [SerializeField] private AudioClip _damage;
    [SerializeField] private AudioClip _death;
    [SerializeField] private AudioClip _attack;

    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayStepSound()
    {
        _audioSource.pitch = Random.Range(0.95f, 1.05f);
        _audioSource.PlayOneShot(_step);
    }

    public void PlayJumpSound()
    {
        _audioSource.PlayOneShot(_jump);
    }

    public void PlayLandingSound()
    {
        _audioSource.PlayOneShot(_landing);
    }

    public void PlayDamageSound()
    {
        _audioSource.PlayOneShot(_damage);
    }

    public void PlayDeathSound()
    {
        _audioSource.PlayOneShot(_death);
    }

    public void PlayAttackSound()
    {
        _audioSource.pitch = Random.Range(0.95f, 1.05f);
        _audioSource.PlayOneShot(_attack);
    }
}
