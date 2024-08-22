using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private PlayerParamaters _playerParamaters;
    [SerializeField] private PlayerCoins _playerCoins;
    [SerializeField] private Text _healingBottleText;
    [SerializeField] private Slider _slider;
    [SerializeField] private Text _coinsCounter;

    private void Start()
    {
        UpdateHealthBar();
        UpdateHealingBottleCounter();
        UpdateCoinsCounter();
    }

    public void UpdateHealthBar()
    {
        _slider.value = _playerParamaters.HP;
    }

    public void UpdateHealingBottleCounter()
    {
        _healingBottleText.text = _playerParamaters._healingBottle.ToString();
    }

    public void UpdateCoinsCounter()
    {
        _coinsCounter.text = _playerCoins._coins.ToString();
    }
}
