using UnityEngine;

public class HealingBottle : IntaractableObjects
{
    [SerializeField] private AudioClip _audioClip;
    private PlayerParamaters _playerParamaters;
    private UI _healingBottleCounter;
    private AudioSource _audioSource;

    private void Start()
    {
        _playerParamaters = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerParamaters>();
        _healingBottleCounter = GameObject.FindGameObjectWithTag("UI").GetComponent<UI>();
        _audioSource = GetComponentInParent<AudioSource>();
    }

    public override void Interact()
    {
        _playerParamaters._healingBottle++;
        _healingBottleCounter.UpdateHealingBottleCounter();
        _audioSource.PlayOneShot(_audioClip);
        Destroy(gameObject);
    }
}
