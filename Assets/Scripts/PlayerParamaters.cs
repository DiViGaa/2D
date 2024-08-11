using UnityEngine;

public class PlayerParamaters : AbstractCharacterParameters
{
    private PlayerAnimator playerAnimator;

    private void Start()
    {
        playerAnimator = GetComponent<PlayerAnimator>();
    }
    private void Update()
    {
        CheckHP();
    }

    public override void CheckHP()
    {
        if (HP <= 0)
        {
            playerAnimator.DeathAnimation();
        }
    }

    public override void TakeDamage(float damage)
    {
        HP -= damage;
        playerAnimator.TakeHitAnimation();
    }
}
