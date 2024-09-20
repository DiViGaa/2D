using UnityEngine;

public class ShopButton : MonoBehaviour
{
    [SerializeField] private Collectibles _collectibles;
    [SerializeField] private BuySound _buySound;
    [SerializeField] private UI _ui;

    private void Start()
    {
        _buySound = GetComponent<BuySound>();
        _ui = GameObject.FindGameObjectWithTag("UI").GetComponent<UI>();
        _collectibles = GameObject.FindGameObjectWithTag("Player").GetComponent<Collectibles>();

    }

    public void BuyHealingBottle()
    {
        if (_collectibles._coins >= 1)
        {
            _collectibles.SetCoin(_collectibles._coins - 1);
            _ui.UpdateCoinsCounter();
            _collectibles.SetHealingBottle(_collectibles._healingBottle + 1);
            _ui.UpdateHealingBottleCounter();
            _buySound.PlayBuySound();
        }
    }

    public void BuyArmor()
    {
        if (_collectibles._coins >= 2)
        {
            _collectibles.SetCoin(_collectibles._coins - 2);
            _ui.UpdateCoinsCounter();
            _collectibles.SetArmor(_collectibles._armor + 1);
            _ui.UpdateArmorCounter();
            _buySound.PlayBuySound();
        }
    }
}
