using UnityEngine;

public class Collectibles : MonoBehaviour
{
    [SerializeField] private UI _uI;
    private ISaveSystem _saveSystem;
    private SaveData _myData;
    public bool theDiamondWasRaised = false;

    private void Start()
    {
        Init();
    }

    public int _coins {  get; private set; }
    public int _diamond { get; private set; }

    public int _healingBottle {  get; private set; }

    public int _armor {  get; private set; }

    public void SetCoin(int amount)
    {
        _coins = amount;
    }
    public void SetDiamond(int amount)
    {
        _diamond = amount;
        theDiamondWasRaised = true;
    }
    public void SetHealingBottle(int amount)
    {
        _healingBottle = amount;
    }
    public void SetArmor(int amount)
    {
        _armor = amount;
    }

    private void Init()
    {
        _saveSystem = new JsonSaveSystem();
        _myData = _saveSystem.Load();
        theDiamondWasRaised = _myData.collectablesItem.theDiamondWasRaised;
        _coins = _myData.collectablesItem.coins;
        _healingBottle = _myData.collectablesItem.healingBottle;
        _armor = _myData.collectablesItem.armor;
        _diamond = _myData.collectablesItem.diamond;
        _uI.UpdateArmorCounter();
        _uI.UpdateCoinsCounter();
        _uI.UpdateHealingBottleCounter();
        _uI.ShowDiamond(_myData.collectablesItem.diamond > 0);
    }
}
