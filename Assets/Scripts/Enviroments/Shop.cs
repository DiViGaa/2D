using UnityEngine;

public class Shop : IntaractableObjects
{
    [SerializeField] private UI _ui;
    [SerializeField] private Collectibles _collectibles;
    [SerializeField] private PlayerParamaters _playerParamaters;
    [SerializeField] private BuySound _buySound;
    private Transform _playerTransform;
    private bool _shopOpen = false;

    public override void Interact()
    {
        _shopOpen = true;
        _ui.ShowShop();
    }
    
    private void Start()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        _buySound = GetComponent<BuySound>();
    }

    private void Update()
    {
        if (_shopOpen)
            CloseShop();
    }

    private void CloseShop()
    {
        if (DistanceToPlayer() > 5)
        {
            _ui.CloseShopCanvas();
            _shopOpen = false;
        }
    }
    private float DistanceToPlayer()
    {
        return Vector2.Distance(gameObject.transform.position, _playerTransform.position);
    }

    public void BuyHealingBottle()
    {
        if (_collectibles._coins >= 1)
        {
            _collectibles._coins--;
            _ui.UpdateCoinsCounter();
            _playerParamaters._healingBottle++;
            _ui.UpdateHealingBottleCounter();
            _buySound.PlayBuySound();
        }
    }

    public void BuyArmor()
    {
        if (_collectibles._coins >= 2)
        {
            _collectibles._coins -= 2;
            _ui.UpdateCoinsCounter();
            _playerParamaters._armor++;
            _ui.UpdateArmorCounter();
            _buySound.PlayBuySound();
        }
    }
}
