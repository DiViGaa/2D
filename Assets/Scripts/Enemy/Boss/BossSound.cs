using UnityEngine;

public class BossSound : MonoBehaviour
{
    [SerializeField] private AudioClip _step;
    [SerializeField] private AudioClip _damage;
    [SerializeField] private AudioClip _death;
    [SerializeField] private AudioClip _attackOneOne;
    [SerializeField] private AudioClip _attackOneTwo;
    [SerializeField] private AudioClip _attackTwo;

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

    public void PlayAttackOneSound()
    {
        _audioSource.pitch = RandomPithc(0.95f, 1.05f);
        _audioSource.PlayOneShot(_attackOneOne);
    }

    public void PlayAttackOneTwoSound()
    {
        _audioSource.pitch = RandomPithc(0.95f, 1.05f);
        _audioSource.PlayOneShot(_attackOneTwo);
    }

    public void PlayAttackTwoSound()
    {
        _audioSource.pitch = RandomPithc(0.95f, 1.05f);
        _audioSource.PlayOneShot(_attackTwo);
    }

    private float RandomPithc(float min, float max)
    {
        return Random.Range(min, max);
    }
}
