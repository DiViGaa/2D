using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _ladderSpeed = 1.5f;
    [SerializeField] private Transform _checkLadder;
    [SerializeField] private float _jumpForce = 15f;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private PlayerSounds _sound;

    private PlayerAnimator _playerAnimator;
    private BoxCollider2D _boxCollider2D;
    private float _nextDodgeTime = 0f;
    private bool isDodging = false;
    private Rigidbody2D _rigidbody;
    private PlayerCombat _playerCombat;
    private float _DodgeRate = 1f;
    private bool checkedLadder;
    private bool wasGrounded;

    public SpriteRenderer _spriteRenderer;
    public float _HorizontalAxis;
    public float _VerticalAxis;
    public LayerMask ladderLayer;
    public LayerMask groundLayer;
    

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _playerAnimator = GetComponent<PlayerAnimator>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _playerCombat = GetComponent<PlayerCombat>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _sound = GetComponent<PlayerSounds>();
    }

    private void Update()
    {
        if (!GameOver.gameOver)
        {
            GetAxis();
            Dodge();
            Flip();
            Jump();
            MoveUpOnLadder();
            CheckingLadder();
            PlayLandingSound();
        }
    }

    private void FixedUpdate()
    {
        if (!GameOver.gameOver)
        {
            Movement();
        }
    }

    private void GetAxis()
    {
        _HorizontalAxis = Input.GetAxis("Horizontal");
        _VerticalAxis = Input.GetAxis("Vertical");
    }

    private void Dodge()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDodging && Time.time >= _nextDodgeTime)
        {
            _nextDodgeTime = Time.time + 1f / _DodgeRate;
            StartCoroutine(DodgeRoutine());
        }
    }

    private IEnumerator DodgeRoutine()
    {
        Collider2D[] enemyColliders = Physics2D.OverlapCircleAll(transform.position, 5f, _playerCombat._enemyLayer);
        foreach (var enemyCollider in enemyColliders)
            Physics2D.IgnoreCollision(_boxCollider2D, enemyCollider, true);
        
        _playerAnimator.Dodge();
        Vector2 dodgeDirection = _spriteRenderer.flipX ? Vector2.left : Vector2.right;
        _rigidbody.AddForce(dodgeDirection * 15000, ForceMode2D.Force);
        yield return new WaitForSeconds(0.5f);

        foreach (var enemyCollider in enemyColliders)
            Physics2D.IgnoreCollision(_boxCollider2D, enemyCollider, false);
    }

    private void Movement()
    {
        _rigidbody.velocity = new Vector2(_HorizontalAxis * _moveSpeed, _rigidbody.velocity.y);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            _sound.PlayJumpSound();
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
            _playerAnimator.JumpAnimation();
        }
    }

    private void Flip()
    {
        if (_HorizontalAxis != 0)
            _spriteRenderer.flipX = _HorizontalAxis < 0;
    }

    private void PlayLandingSound()
    {
        if (IsGrounded() && !wasGrounded)
            _sound.PlayLandingSound();

        wasGrounded = IsGrounded();
    }

    private void MoveUpOnLadder()
    {
        if (checkedLadder)
        {
            _rigidbody.bodyType = RigidbodyType2D.Kinematic;
            UpDownLadder();
        }
        else
        {
            _rigidbody.bodyType = RigidbodyType2D.Dynamic;

        }
    }

    private void UpDownLadder()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _VerticalAxis * _ladderSpeed);
    }

    private void CheckingLadder()
    {
        checkedLadder = Physics2D.OverlapPoint(_checkLadder.position, ladderLayer);
        if (_VerticalAxis > 0 || _VerticalAxis < 0)
            _playerAnimator.LadderAnimation(checkedLadder);
    }

    public bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(_boxCollider2D.bounds.center,_boxCollider2D.bounds.size,0,Vector2.down, 0.2f, groundLayer);
        return hit.collider != null;
    }
}
