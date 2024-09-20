using UnityEngine;

public class Shop : IntaractableObjects
{
    [SerializeField] private float _distanceToCloseShop;
    [SerializeField] private UI _ui;

    private Transform _playerTransform;
    private bool _shopOpen = false;

    public override void Interact()
    {
        _shopOpen = true;
        CharacterIsBusy.characterIsBusy = true;
        _ui.ShowShop();
    }
    
    private void Start()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (_shopOpen)
            CloseShop();
    }

    private void CloseShop()
    {
        if (DistanceToPlayer() > _distanceToCloseShop)
        {
            _ui.CloseShopCanvas();
            _shopOpen = false;
            CharacterIsBusy.characterIsBusy = false;
        }
    }
    private float DistanceToPlayer()
    {
        return (gameObject.transform.position - _playerTransform.position).sqrMagnitude;
    }
}
