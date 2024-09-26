using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private float _attackRange = 0.5f;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _damage = 15;

    private PlayerAnimator _playerAnimator;
    private PlayerMovement _playerMovement;
    private  Vector2 _attackPointPosition;
    private float _nextAttackTime = 0f;
    [SerializeField] private float _attackRate = 2f;

    public LayerMask _enemyLayer;
    
    void Start()
    {
        _playerMovement = GetComponentInChildren<PlayerMovement>();
        _playerAnimator = GetComponent<PlayerAnimator>();
        _attackPointPosition = _attackPoint.localPosition;
    }

    void Update()
    {
        if (!GameOver.gameOver)
        {
            Attack();
            ReflectionPointAttack();
        }
    }

    private void Attack()
    {
        if (CanAttack())
        {
            _playerAnimator.AttackAnimation();
        }
    }

    public void AttackEvent()
    {
        _nextAttackTime = Time.time + 1f / _attackRate;
        Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange, _enemyLayer);
        foreach (var enemy in hitEnemys)
        {
            enemy.GetComponent<AbstractCharacterParameters>().TakeDamage(_damage);
            if (enemy != null && enemy.isTrigger)
            {
                enemy.GetComponent<AbstractCharacterParameters>().TakeDamage(_damage);
            }
        }
    }

    private bool CanAttack()
    {
        return _inputManager.AttackButtonIsPressed() && _playerMovement.IsGrounded() && Time.time >= _nextAttackTime && !CharacterIsBusy.characterIsBusy;
    }


    private void ReflectionPointAttack()
    {
        if (_playerMovement.spriteRenderer.flipX) 
            _attackPoint.localPosition = -_attackPointPosition; 

        else if (!_playerMovement.spriteRenderer.flipX)
            _attackPoint.localPosition = _attackPointPosition;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_attackPoint.position, _attackRange);
    }
}
