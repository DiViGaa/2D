using UnityEngine;

public class InteractCoin : IntaractableObjects
{
    private PlayerCoins _playerCoins;
    private UI _coinsCounter;
    private AudioSource _audioSource;

    private void Start()
    {
        _playerCoins = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCoins>();
        _coinsCounter = GameObject.FindGameObjectWithTag("UI").GetComponent<UI>();
        _audioSource = GetComponent<AudioSource>();
    }

    public override void Interact()
    {
        _playerCoins._coins++;
        Destroy(gameObject);
        _coinsCounter.UpdateCoinsCounter();
        _audioSource.Play(); 
    }
}
