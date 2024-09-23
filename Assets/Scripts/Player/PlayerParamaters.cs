using UnityEngine;

public class PlayerParamaters : AbstractCharacterParameters
{
    [SerializeField] private UI _ui;
    [SerializeField] private MuteMusic _music;
    
    private PlayerAnimator _playerAnimator;
    private PlayerSounds _sounds;
    private Collectibles _collectibles;
    private ISaveSystem _saveSystem;
    private SaveData _myData;
  

    private void Start()
    {
        Init();
        _playerAnimator = GetComponent<PlayerAnimator>();
        _sounds = GetComponent<PlayerSounds>();
        _collectibles = GetComponent<Collectibles>();
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
            _playerAnimator.DeathAnimation();
            GameOver.gameOver = true;
            _music.Mute();
        }
        else
        {
            GameOver.gameOver = false;
        }
    }

    public override void TakeDamage(float damage)
    {
        if (_collectibles._armor > 0) 
        {
            _collectibles.SetArmor(_collectibles._armor - 1);
            _sounds.PlayArmorHitSound();
            _ui.UpdateArmorCounter();
        }
        else 
        {
            if(!GameOver.gameOver)
            {
                HP -= damage;
                _playerAnimator.TakeHitAnimation();
                _ui.UpdateHealthBar();
                CheckHP();
            }
        }
    }

    public void RestoreHP()
    {
        if (_collectibles._healingBottle > 0 && Input.GetKeyDown(KeyCode.F))
        {
            HP += 15;
            HP = Mathf.Clamp(HP, 0, 100);
            _ui.UpdateHealthBar();
            _collectibles.SetHealingBottle(_collectibles._healingBottle - 1);
            _ui.UpdateHealingBottleCounter();
            _sounds.PlayHealingBottleSound();
        }
    }

    private void Init()
    {
        _saveSystem = new JsonSaveSystem();
        _myData = _saveSystem.Load();
        HP = _myData.player.hp;
        _ui.UpdateHealthBar();
        transform.position = _myData.player.playerPosition;
    }
}
