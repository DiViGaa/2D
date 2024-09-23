using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private PlayerParamaters _playerParamaters;
    [SerializeField] private Collectibles _collectibles;
    [SerializeField] private GameObject _gaveOverPanel;
    [SerializeField] private Text _healingBottleText;
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _interactLabel;
    [SerializeField] private GameObject _diamond;
    [SerializeField] private Text _coinsCounter;
    [SerializeField] private GameObject _dialog;
    [SerializeField] private Text _armorCounter;
    [SerializeField] private GameObject _shop;
    [SerializeField] private Slider _slider;

    private ISaveSystem _saveSystem;
    private SaveData _myData;

    private void Start()
    {
        _saveSystem = new JsonSaveSystem();
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
        _healingBottleText.text = _collectibles._healingBottle.ToString();
    }

    public void UpdateCoinsCounter()
    {
        _coinsCounter.text = _collectibles._coins.ToString();
    }

    public void UpdateArmorCounter()
    {
        _armorCounter.text = _collectibles._armor.ToString();
    }

    public void PausePanel(bool panelVisibility)
    {
        _pausePanel.SetActive(panelVisibility);
    }

    public void ShowDiamond(bool visible)
    { 
        _diamond.SetActive(visible); 
    }

    public void ShowShop()
    {
        _shop.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public void CloseShopCanvas()
    {
        _shop.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ShowDialog(bool visible) 
    {
        _dialog.SetActive(visible);
    }

    public void InteractLabel(bool visible)
    {
        _interactLabel.SetActive(visible);
    }

    public void Restart()
    {
        if (File.Exists(Application.persistentDataPath + "/Save.json"))
        {
            _myData = _saveSystem.Load();
            SceneManager.LoadScene(_myData.sceneName.sceneName);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
        PauseResume.TimeScale(1f);
    }

    public void GameOverPanel()
    {
        _gaveOverPanel.SetActive(true);
        PauseResume.CursorState(true, CursorLockMode.Confined);
    }
}
