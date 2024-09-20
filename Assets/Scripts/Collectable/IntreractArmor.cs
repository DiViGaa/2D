using UnityEngine;

public class IntreractArmor : IntaractableObjects
{
    [SerializeField] private int _amountOfArmor = 1;
    [SerializeField] private AudioClip _audioClip;
    private Collectibles _collectibles;
    private UI _armorCounter;
    private AudioSource _audioSource;

    private void Start()
    {
        _collectibles = GameObject.FindGameObjectWithTag("Player").GetComponent<Collectibles>();
        _armorCounter = GameObject.FindGameObjectWithTag("UI").GetComponent<UI>();
        _audioSource = GetComponentInParent<AudioSource>();
    }

    public override void Interact()
    {
        _collectibles.SetArmor(_collectibles._armor + _amountOfArmor);
        _armorCounter.UpdateArmorCounter();
        _audioSource.PlayOneShot(_audioClip);
        Destroy(gameObject);
    }

}
