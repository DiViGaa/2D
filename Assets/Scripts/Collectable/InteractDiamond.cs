using UnityEngine;

public class InteractDiamond : IntaractableObjects
{
    [SerializeField] private AudioClip _audioClip;
    private Collectibles _collectibles;
    private UI _uiDiamond;
    private AudioSource _audioSource;

    private void Start()
    {
        _collectibles = GameObject.FindGameObjectWithTag("Player").GetComponent<Collectibles>();
        _uiDiamond = GameObject.FindGameObjectWithTag("UI").GetComponent<UI>();
        _audioSource = GetComponentInParent<AudioSource>();
    }

    public override void Interact()
    {
        _collectibles.SetDiamond(_collectibles._diamond + 1);
        _uiDiamond.ShowDiamond(true);
        _audioSource.PlayOneShot(_audioClip);
        Destroy(gameObject);
    }
}
