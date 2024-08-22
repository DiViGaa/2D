using UnityEngine;

public class HealingBottle : IntaractableObjects
{
    private PlayerParamaters _playerParamaters;
    private UI _healingBottleCounter;
    private AudioSource _audioSource;

    private void Start()
    {
        _playerParamaters = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerParamaters>();
        _healingBottleCounter = GameObject.FindGameObjectWithTag("UI").GetComponent<UI>();
        _audioSource = GetComponent<AudioSource>();
    }

    public override void Interact()
    {
        _playerParamaters._healingBottle++;
        Destroy(gameObject);
        _healingBottleCounter.UpdateHealingBottleCounter();
        _audioSource.Play();

    }
}
