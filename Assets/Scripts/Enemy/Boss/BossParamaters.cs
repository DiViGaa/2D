using UnityEngine;

public class BossParamaters : AbstractCharacterParameters
{
    [SerializeField] private UI _ui;
    private EnemyAnimator _animator;
    private Reward _reward;

    private void Start()
    {
        _animator = GetComponent<EnemyAnimator>();
        _reward = GetComponent<Reward>();
    }
    public override void TakeDamage(float damage)
    {
        _animator.TakeHitAnimation();
        HP -= damage;
        _ui.UpdateBossHealthBar();
        CheckHP();
    }

    public override void CheckHP()
    {
        if (HP <= 0)
        {
            GetComponent<Rigidbody2D>().gravityScale = 0f;
            GetComponent<Collider2D>().enabled = false;
            _animator.DeathAnimation();
            _reward.CreateReward();
            _ui.BossHealthBar(false);
        }
    }

    public void DestoyBoss()
    {
        Destroy(gameObject);
    }
        
}
