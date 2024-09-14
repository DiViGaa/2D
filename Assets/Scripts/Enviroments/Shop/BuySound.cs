using UnityEngine;

public class BuySound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _buySound;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayBuySound()
    {
        _audioSource.PlayOneShot(_buySound);
    }
}
