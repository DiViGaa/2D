using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [SerializeField] private float _attackRange = 0.5f;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private float _damage = 15;

    private SpriteRenderer _spriteRenderer;
    private Vector2 _attackPointPosition;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _attackPointPosition = _attackPoint.localPosition;
    }

    private void Update()
    {
        ReflectionPointAttack();
    }

    public void Attack()
    {
        Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange, _playerLayer);

        foreach (var enemy in hitEnemys)
            enemy.GetComponent<PlayerParamaters>().TakeDamage(_damage);
    }

    private void ReflectionPointAttack()
    {
        if (_spriteRenderer.flipX)
            _attackPoint.localPosition = new Vector2(-_attackPointPosition.x, _attackPointPosition.y);

        else if (!_spriteRenderer.flipX)
            _attackPoint.localPosition = new Vector2(_attackPointPosition.x, _attackPointPosition.y);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_attackPoint.position, _attackRange);
    }
}
