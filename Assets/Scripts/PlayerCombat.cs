using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private float _attackRange = 0.5f;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private float _damage = 15;

    private PlayerAnimator _playerAnimator;
    private PlayerMovement _playerMovement;
    private  Vector2 _attackPointPosition;
    private float _nextAttackTime = 0f;
    private float _attackRate = 2f;

    void Start()
    {
        _playerMovement = GetComponentInChildren<PlayerMovement>();
        _playerAnimator = GetComponent<PlayerAnimator>();
        _attackPointPosition = _attackPoint.localPosition;
    }

    void Update()
    {
        Attack();
        ReflectionPointAttack();
    }

    private void Attack()
    {
        if (CanAttack())
        {
            _nextAttackTime = Time.time + 1f / _attackRate;
            _playerAnimator.AttackAnimation();
            Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange, enemyLayer);
            foreach (var enemy in hitEnemys)
            {
                enemy.GetComponent<EnemyParameters>().TakeDamage(_damage);
            }
        }
    }

    private bool CanAttack()
    {
        return Input.GetButtonDown("Fire1") && _playerMovement.IsGrounded() && Time.time >= _nextAttackTime;
    }


    private void ReflectionPointAttack()
    {
        if (_playerMovement._spriteRenderer.flipX) 
        {
            _attackPoint.localPosition = -_attackPointPosition; 
        }
        else if (!_playerMovement._spriteRenderer.flipX)
        {
            _attackPoint.localPosition = _attackPointPosition;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_attackPoint.position, _attackRange);
    }
}
