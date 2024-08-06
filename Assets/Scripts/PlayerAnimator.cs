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
        Jump();
        isGrounded();
        Attack();
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

    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _animator.SetTrigger("Jump");
        }
    }

    private void isGrounded()
    {
        _animator.SetBool("isGrounded", _playerMovement.IsGrounded());
    }

    private void Attack()
    {
        if (Input.GetButtonDown("Fire1") && _playerMovement.IsGrounded())
        {
            _animator.SetTrigger("Attack");
        }
    }
}
