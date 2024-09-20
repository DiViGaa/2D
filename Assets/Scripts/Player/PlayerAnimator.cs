using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private UI _ui;

    private PlayerMovement _playerMovement;
    private Animator _animator;

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        UpdateVerticalAxis();
        IsGrounded();
        Move();
    }

    private void Move()
    {
        if (_playerMovement.HorizontalAxis != 0) 
        {
            _animator.SetBool("Move", true);
        }
        else
        {
            _animator.SetBool("Move", false);

        }
    }

    public void Dodge()
    {
        _animator.SetTrigger("Dodge");
    }

    private void UpdateVerticalAxis()
    {
        _animator.SetFloat("Y",_playerMovement.VerticalAxis);
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
        _animator.SetBool("Death", true);
    }

    public void TakeHitAnimation()
    {
        _animator.SetTrigger("Hit");
    }

    public void LadderAnimation(bool onLadder)
    {
        _animator.SetBool("OnLadder", onLadder);
    }

    private void IsGrounded()
    {
        _animator.SetBool("isGrounded", _playerMovement.IsGrounded());
    }

    public void ShopGameOver()
    {
        _ui.GameOverPanel();
    }
}
