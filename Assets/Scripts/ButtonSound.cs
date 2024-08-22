using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    [SerializeField] private AudioClip _hover;
    [SerializeField] private AudioClip _pressed;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayHoverSound()
    {
        _audioSource.PlayOneShot(_hover);
    }

    public void PlayPressedSound() 
    {
        _audioSource.PlayOneShot(_pressed);
    }
}
