using UnityEngine;

public class EnemyParameters : AbstractCharacterParameters
{
    private SkeletonAnimator _animator;
    private Reward _reward;

    private void Start()
    {
        _animator = GetComponent<SkeletonAnimator>();
        _reward = GetComponent<Reward>();
    }
    public override void TakeDamage(float damage)
    {
        HP -= damage;
        _animator.TakeHitAnimation();
        CheckHP();
    } 

    public override void CheckHP()
    {
        if (HP <= 0)
        {
            _animator.DeathAnimation();
            GetComponent<Rigidbody2D>().gravityScale = 0f;
            GetComponent<Collider2D>().enabled = false;
            _reward.CreateReward();
        }
    }

}
