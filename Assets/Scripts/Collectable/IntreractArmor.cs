using UnityEngine;

public class IntreractArmor : IntaractableObjects
{
    [SerializeField] private int _armorIndex = 1;
    [SerializeField] private AudioClip _audioClip;
    private PlayerParamaters _playerArmor;
    private UI _armorCounter;
    private AudioSource _audioSource;

    private void Start()
    {
        _playerArmor = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerParamaters>();
        _armorCounter = GameObject.FindGameObjectWithTag("UI").GetComponent<UI>();
        _audioSource = GetComponentInParent<AudioSource>();
    }

    public override void Interact()
    {
        _playerArmor._armor += _armorIndex;
        _armorCounter.UpdateArmorCounter();
        _audioSource.PlayOneShot(_audioClip);
        Destroy(gameObject);
    }

}
