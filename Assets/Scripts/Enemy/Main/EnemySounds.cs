using UnityEngine;

public class EnemySounds : MonoBehaviour
{
    [SerializeField] private AudioClip _step;
    [SerializeField] private AudioClip _damage;
    [SerializeField] private AudioClip _death;
    [SerializeField] private AudioClip _attack;
    [SerializeField] private AudioClip _idle;

    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayStepSound()
    {
        _audioSource.pitch = RandomPithc(0.95f, 1.05f);
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
        _audioSource.pitch = RandomPithc(0.95f, 1.05f);
        _audioSource.PlayOneShot(_attack);
    }
    public void PlayIdleSound()
    {
        _audioSource.pitch = RandomPithc(0.95f, 1.05f);
        _audioSource.PlayOneShot(_idle);
    }

    private float RandomPithc(float min, float max)
    {
        return Random.Range(min, max);
    }
}
