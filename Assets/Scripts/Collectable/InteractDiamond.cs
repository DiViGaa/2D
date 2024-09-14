using UnityEngine;

public class InteractDiamond : IntaractableObjects
{
    [SerializeField] private AudioClip _audioClip;
    private Collectibles _diamonds;
    private UI _uiDiamond;
    private AudioSource _audioSource;

    private void Start()
    {
        _diamonds = GameObject.FindGameObjectWithTag("Player").GetComponent<Collectibles>();
        _uiDiamond = GameObject.FindGameObjectWithTag("UI").GetComponent<UI>();
        _audioSource = GetComponentInParent<AudioSource>();
    }

    public override void Interact()
    {
        _diamonds._diamond++;
        _uiDiamond.ShowDiamond(true);
        _audioSource.PlayOneShot(_audioClip);
        Destroy(gameObject);
    }
}
