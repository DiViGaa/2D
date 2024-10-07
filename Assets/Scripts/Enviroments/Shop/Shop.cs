using UnityEngine;

public class Shop : IntaractableObjects
{
    [SerializeField] private float _distanceToCloseShop;
    [SerializeField] private UI _ui;
    [SerializeField] private InputManager _inputManager;

    private Transform _playerTransform;
    private bool _shopOpen = false;


    public override void Interact()
    {
        _shopOpen = true;
        _ui.DialogShop(true);
        CharacterIsBusy.characterIsBusy = true;
    }
    
    private void Start()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (_shopOpen)
        {
            CloseShop();
            SkipDialog();
        }
    }

    private void SkipDialog()
    {
        if (_inputManager.EIsPressed())
        {
            _ui.DialogShop(false);
            _ui.ShowShopCanvas();
        }
    }
    
    private void CloseShop()
    {
        if (DistanceToPlayer() > _distanceToCloseShop)
        {
            _ui.HideShopCanvas();
            _ui.DialogShop(false);
            _shopOpen = false;
            CharacterIsBusy.characterIsBusy = false;
        }
    }
    private float DistanceToPlayer()
    {
        return (gameObject.transform.position - _playerTransform.position).sqrMagnitude;
    }
}
