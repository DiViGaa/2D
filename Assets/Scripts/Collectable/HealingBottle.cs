using UnityEngine;

public class HealingBottle : IntaractableObjects
{
    [SerializeField] private AudioClip _audioClip;
    private Collectibles _collectibles;
    private UI _healingBottleCounter;
    private AudioSource _audioSource;

    private void Start()
    {
        _collectibles = GameObject.FindGameObjectWithTag("Player").GetComponent<Collectibles>();
        _healingBottleCounter = GameObject.FindGameObjectWithTag("UI").GetComponent<UI>();
        _audioSource = GetComponentInParent<AudioSource>();
    }

    public override void Interact()
    {
        _collectibles.SetHealingBottle(_collectibles._healingBottle + 1);
        _healingBottleCounter.UpdateHealingBottleCounter();
        _audioSource.PlayOneShot(_audioClip);
        Destroy(gameObject);
    }
}
