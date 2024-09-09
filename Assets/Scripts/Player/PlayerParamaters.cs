using UnityEngine;

public class PlayerParamaters : AbstractCharacterParameters
{
    [SerializeField] private UI _ui;
    [SerializeField] private MuteMusic _music;

    private PlayerAnimator playerAnimator;
    private PlayerSounds sounds;

    public int _healingBottle = 0;
    public int _armor = 0;

    private void Start()
    {
        playerAnimator = GetComponent<PlayerAnimator>();
        sounds = GetComponent<PlayerSounds>();
        CheckHP();
    }
    private void Update()
    {
        RestoreHP();
    }

    public override void CheckHP()
    {
        if (HP <= 0)
        {
            playerAnimator.DeathAnimation();
            GameOver.gameOver = true;
            _ui.GameOverPanel();
            _music.Mute();
        }
        else
        {
            GameOver.gameOver = false;
        }
    }

    public override void TakeDamage(float damage)
    {
        if (_armor > 0) 
        {
            _armor--;
            sounds.PlayArmorHitSound();
            _ui.UpdateArmorCounter();
        }
        else 
        {
            if(!GameOver.gameOver)
            {
                HP -= damage;
                playerAnimator.TakeHitAnimation();
                _ui.UpdateHealthBar();
                CheckHP();
            }
        }
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
            sounds.PlayHealingBottleSound();
        }
    }
}
