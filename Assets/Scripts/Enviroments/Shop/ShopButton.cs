using UnityEngine;

public class ShopButton : MonoBehaviour
{
    [SerializeField] private PlayerParamaters _playerParamaters;
    [SerializeField] private Collectibles _collectibles;
    [SerializeField] private BuySound _buySound;
    [SerializeField] private UI _ui;

    private void Start()
    {
        _buySound = GetComponent<BuySound>();
        _ui = GameObject.FindGameObjectWithTag("UI").GetComponent<UI>();
        _playerParamaters = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerParamaters>();
        _collectibles = GameObject.FindGameObjectWithTag("Player").GetComponent<Collectibles>();

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
