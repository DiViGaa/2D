using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] private AudioClip _step;
    [SerializeField] private AudioClip _jump;
    [SerializeField] private AudioClip _landing;
    [SerializeField] private AudioClip _damage;
    [SerializeField] private AudioClip _death;
    [SerializeField] private AudioClip _attack;
    [SerializeField] private AudioClip _armorHit;
    [SerializeField] private AudioClip _healingBottle;
    [SerializeField] private AudioClip _ladder;
    [SerializeField] private AudioClip _dodge;

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

    public void PlayHealingBottleSound()
    {
        _audioSource.PlayOneShot(_healingBottle);
    }

    public void PlayDodgeSound()
    {
        _audioSource.PlayOneShot(_dodge);
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

    public void PlayArmorHitSound()
    {
        _audioSource.PlayOneShot(_armorHit);
    }

    public void PlayLadderSound()
    {
        _audioSource.PlayOneShot(_ladder);
    }

    public void PlayAttackSound()
    {
        _audioSource.pitch = Random.Range(0.95f, 1.05f);
        _audioSource.PlayOneShot(_attack);
    }
}
