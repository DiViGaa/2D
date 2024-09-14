using UnityEngine;

public class NPCSound : MonoBehaviour
{
    [SerializeField] private AudioClip _reward;
    
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayerRewardSound()
    {
        _audioSource.PlayOneShot(_reward);
    }
}
