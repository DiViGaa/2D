using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractBossDiamond : IntaractableObjects
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
        if (_myData.collectablesItem.theBossDiamondWasRaised)
        {
            Destroy(gameObject);
        }
    }

    public override void Interact()
    {
        _collectibles.SetBossDiamond(_collectibles._bossDiamond + 1);
        _uiDiamond.ShowBossDiamond(true);
        _audioSource.PlayOneShot(_audioClip);
        Destroy(gameObject);
    }
}
