using UnityEngine;

public class SaveSound : MonoBehaviour
{
    [SerializeField] private AudioClip _saveSound;

    private AudioSource _soundSource;
    void Start()
    {
        _soundSource = GetComponent<AudioSource>();
    }

    public void PlaySaveSound()
    {
        _soundSource.PlayOneShot(_saveSound); 
    }

}
