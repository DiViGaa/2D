using UnityEngine;

public class Collectibles : MonoBehaviour
{
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
    }
    public void SetHealingBottle(int amount)
    {
        _healingBottle = amount;
    }
    public void SetArmor(int amount)
    {
        _armor = amount;
    }
}
