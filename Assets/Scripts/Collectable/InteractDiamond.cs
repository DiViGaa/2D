using UnityEngine;

public class InteractDiamond : IntaractableObjects
{
    [SerializeField] private AudioClip _audioClip;
    private ISaveSystem _saveSystem;
    private SaveData _myData;
    private Collectibles _collectibles;
    private UI _uiDiamond;
    private AudioSource _audioSource;

    private void Start()
    {
        Init();
        _collectibles = GameObject.FindGameObjectWithTag("Player").GetComponent<Collectibles>();
        _uiDiamond = GameObject.FindGameObjectWithTag("UI").GetComponent<UI>();
        _audioSource = GetComponentInParent<AudioSource>();
    }

    private void Init()
    {
        _saveSystem = new JsonSaveSystem();
        _myData = _saveSystem.Load();
        if (_myData.collectablesItem.theDiamondWasRaised)
        {
            Destroy(gameObject);
        }
    }

    public override void Interact()
    {
        _collectibles.SetDiamond(_collectibles._diamond + 1);
        _uiDiamond.ShowDiamond(true);
        _audioSource.PlayOneShot(_audioClip);
        Destroy(gameObject);
    }
}
