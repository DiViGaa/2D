using UnityEngine;

public class DeathPanelSound : MonoBehaviour
{
    [SerializeField] private AudioClip _deathPanelSound;
    [SerializeField] private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayerDeathPanelSound()
    {
        _audioSource.PlayOneShot(_deathPanelSound);
    }
}
