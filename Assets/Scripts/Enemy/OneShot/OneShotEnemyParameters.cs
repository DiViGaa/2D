using UnityEngine;

public class OneShotEnemyParameters : AbstractCharacterParameters
{
    private OneShotEnemyCombat _oneShotEnemyCompat;
    private OneShotEnemyAnimator _animator;
    private Enemy _enemy;


    private void Start()
    {
        _animator = GetComponent<OneShotEnemyAnimator>();
        _oneShotEnemyCompat = GetComponent<OneShotEnemyCombat>();
        _enemy = GetComponent<Enemy>();
    }

    public override void CheckHP()
    {
        if (HP <= 0)
        {
            _animator.DeathAnimation();
            _enemy.OnDeath();
        }
    }

    public override void TakeDamage(float damage)
    {
        HP -= damage;
        Destroy(_oneShotEnemyCompat);
        CheckHP();
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
