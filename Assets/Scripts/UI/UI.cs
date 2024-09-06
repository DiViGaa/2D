using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private PlayerParamaters _playerParamaters;
    [SerializeField] private Collectibles _playerCoins;
    [SerializeField] private Text _healingBottleText;
    [SerializeField] private Slider _slider;
    [SerializeField] private Text _coinsCounter;
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _gaveOverPanel;
    [SerializeField] private PlayerParamaters _playerArmor;
    [SerializeField] private Text _armorCounter;
    [SerializeField] private GameObject _diamond;
    [SerializeField] private GameObject _dialog;

    private void Start()
    {
        UpdateHealingBottleCounter();
        UpdateArmorCounter();
        UpdateCoinsCounter();
        UpdateHealthBar();
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

    public void UpdateArmorCounter()
    {
        _armorCounter.text = _playerArmor._armor.ToString();
    }

    public void PausePanel(bool panelVisibility)
    {
        _pausePanel.gameObject.SetActive(panelVisibility);
    }

    public void ShowDiamond()
    { 
        _diamond.SetActive(true); 
    }

    public void ShowDialog(bool visible) 
    {
        _dialog.SetActive(visible);
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
        PauseResume.CursorState(false, CursorLockMode.Locked);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
        PauseResume.TimeScale(1f);
    }

    public void GameOverPanel()
    {
        _gaveOverPanel.gameObject.SetActive(true);
        PauseResume.CursorState(true, CursorLockMode.Confined);
    }
}
