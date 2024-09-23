using UnityEngine;

public class BossMov : StateMachineBehaviour
{
    [SerializeField] private float _movementSpeed = 1f;
    [SerializeField] private float _attackDistance = 2f;

    private Rigidbody2D _rigidbody;
    private Transform _player;
    private SpriteRenderer _spriteRenderer;
    private string[] _nameOfAttacks = new string[] {"Attack", "Attack_2"};
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _rigidbody = animator.GetComponent<Rigidbody2D>();
        _spriteRenderer = animator.GetComponent<SpriteRenderer>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (DistanceToPlayer(animator) >= _attackDistance) 
            MoveToPlayer();

        if (DistanceToPlayer(animator) <= _attackDistance)
        {
            animator.SetTrigger(_nameOfAttacks[Random.Range(0, _nameOfAttacks.Length)]);
        }

        Flip(animator);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    private void MoveToPlayer()
    {
        Vector2 newTarget = new Vector2(_player.position.x, _rigidbody.position.y);
        Vector2 newPosition = Vector2.MoveTowards(_rigidbody.position, newTarget, _movementSpeed * Time.fixedDeltaTime);
        _rigidbody.MovePosition(newPosition);
    }

    private void Flip(Animator animator)
    {
        if (animator.transform.position.x > _player.position.x)
            _spriteRenderer.flipX = true;

        else if (animator.transform.position.x < _player.position.x)
            _spriteRenderer.flipX = false;
    }

    private float DistanceToPlayer(Animator animator)
    {
        return (animator.transform.position - _player.position).sqrMagnitude;
    }
}
