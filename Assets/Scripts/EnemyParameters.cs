using UnityEngine;

public class EnemyParameters : AbstractCharacterParameters
{
    private SkeletonAnimator _animator;

    private void Start()
    {
        _animator = GetComponent<SkeletonAnimator>();
    }

    private void Update()
    {
        CheckHP();
    }

    public override void CheckHP()
    {
        if (HP <= 0)
        {
            _animator.DeathAnimation();
            GetComponent<Rigidbody2D>().gravityScale = 0f;
            GetComponent<Collider2D>().enabled = false;
        }
    }

    public override void TakeDamage(float damage)
    {
        HP -= damage;
        _animator.TakeHitAnimation();
    } 
}
