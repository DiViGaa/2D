public class PlayerParamaters : AbstractCharacterParameters
{
    private void Update()
    {
        CheckHP();
    }

    public override void CheckHP()
    {
        if (HP <= 0)
        {
            Events.gameOver?.Invoke();
        }
    }

    public override void TakeDamage(float damage)
    {
        HP -= damage;
        Events.playerTakeHit?.Invoke();
    }
}
