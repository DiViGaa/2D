using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerMovement _playerMovement;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        Move();
        isGrounded();
    }

    private void Move()
    {
        if (_playerMovement._HorizontalAxis != 0) 
        {
            _animator.SetBool("Move", true);
        }
        else
        {
            _animator.SetBool("Move", false);

        }
    }

    public void JumpAnimation()
    { 
        _animator.SetTrigger("Jump");
    }

    public void AttackAnimation()
    {
        _animator.SetTrigger("Attack");
    }

    public void DeathAnimation()
    {
        _animator.SetTrigger("Death");
    }

    public void TakeHitAnimation()
    {
        _animator.SetTrigger("Hit");
    }
    private void isGrounded()
    {
        _animator.SetBool("isGrounded", _playerMovement.IsGrounded());
    }
}
