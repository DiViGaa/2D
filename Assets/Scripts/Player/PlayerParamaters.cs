using UnityEngine;

public class PlayerParamaters : AbstractCharacterParameters
{
    [SerializeField] private UI _ui;

    private PlayerAnimator playerAnimator;

    public int _healingBottle = 0;

    private void Start()
    {
        playerAnimator = GetComponent<PlayerAnimator>();
    }
    private void Update()
    {
        CheckHP();
        RestoreHP();
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
        _ui.UpdateHealthBar();
    }

    public void RestoreHP()
    {
        if (_healingBottle > 0 && Input.GetKeyDown(KeyCode.F))
        {
            HP += 15;
            HP = Mathf.Clamp(HP, 0, 100);
            _ui.UpdateHealthBar();
            _healingBottle--;
            _ui.UpdateHealingBottleCounter();
        }
    }
}
