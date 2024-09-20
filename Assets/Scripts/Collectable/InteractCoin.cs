using UnityEngine;

public class InteractCoin : IntaractableObjects
{
    [SerializeField] private AudioClip _audioClip;
    private Collectibles _collectibles;
    private UI _coinsCounter;
    private AudioSource _audioSource;

    private void Start()
    {
        _collectibles = GameObject.FindGameObjectWithTag("Player").GetComponent<Collectibles>();
        _coinsCounter = GameObject.FindGameObjectWithTag("UI").GetComponent<UI>();
        _audioSource = GetComponentInParent<AudioSource>();
    }
    
    public override void Interact()
    {
        _collectibles.SetCoin(_collectibles._coins + 1);
        _coinsCounter.UpdateCoinsCounter();
        _audioSource.PlayOneShot(_audioClip);
        Destroy(gameObject);
    }
}
