using UnityEngine;

public class EnemySounds : MonoBehaviour
{
    [SerializeField] private AudioClip _step;
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
