using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 15f;

    private PlayerAnimator _playerAnimator;
    private BoxCollider2D _boxCollider2D;
    private Rigidbody2D _rigidbody;
    public SpriteRenderer _spriteRenderer;
    public float _HorizontalAxis;
    public LayerMask groundLayer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _playerAnimator = GetComponent<PlayerAnimator>();
    }

    private void Update()
    {
        GetAxis();
        Flip();
        Jump();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void GetAxis()
    {
        _HorizontalAxis = Input.GetAxis("Horizontal");
    }

    private void Movement()
    {
        _rigidbody.velocity = new Vector2(_HorizontalAxis * _moveSpeed, _rigidbody.velocity.y);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
            _playerAnimator.JumpAnimation();
        }
    }

    private void Flip()
    {
        if (_HorizontalAxis != 0)
            _spriteRenderer.flipX = _HorizontalAxis < 0;
    }

    public bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(_boxCollider2D.bounds.center,_boxCollider2D.bounds.size,0,Vector2.down, 0.2f, groundLayer);
        return hit.collider != null;
    }
}
