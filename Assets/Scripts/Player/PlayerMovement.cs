using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _ladderSpeed = 1.5f;
    [SerializeField] private Transform _checkLadder;
    [SerializeField] private Transform _bottonCheckLadder;
    [SerializeField] private float _jumpForce = 15f;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private PlayerSounds _sound;

    private PlayerAnimator _playerAnimator;
    private BoxCollider2D _boxCollider2D;
    private PlayerCombat _playerCombat;
    private float _nextDodgeTime = 0f;
    private bool isDodging = false;
    private Rigidbody2D _rigidbody;
    private float _DodgeRate = 1f;
    public bool _checkedLadder;
    public bool _bottonCheckedLadder;
    private bool wasGrounded;
    private bool _onLadder;

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
            Ladder();
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
        if (_onLadder)
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(_checkLadder.position, 0.05f);
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(_bottonCheckLadder.position, 0.05f);
    }

    private void CheckingLadder()
    {
        _checkedLadder = Physics2D.OverlapPoint(_checkLadder.position, ladderLayer);
        _bottonCheckedLadder = Physics2D.OverlapPoint(_bottonCheckLadder.position, ladderLayer);
    }


    private void Ladder()
    {
        if (_checkedLadder || _bottonCheckedLadder)
        {
            if (!_checkedLadder && _bottonCheckedLadder)
            {
                if (_VerticalAxis > 0)
                    _onLadder = false;

                else if (_VerticalAxis < 0)
                    _onLadder = true;
            }
            else if (_checkedLadder && _bottonCheckedLadder)
            {
                if (_VerticalAxis > 0)
                    _onLadder = true;

                else if (_VerticalAxis < 0)
                    _onLadder = true;
            }
            else if (_checkedLadder && !_bottonCheckedLadder)
            {
                if (_VerticalAxis > 0)
                    _onLadder = true;

                else if (_VerticalAxis < 0)
                    _onLadder = false;
            }
        }
        else
            _onLadder = false;

        MoveUpOnLadder();

        if (_VerticalAxis > 0 || _VerticalAxis < 0 || _VerticalAxis == 0)
            _playerAnimator.LadderAnimation(_onLadder);
    }

    public bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(_boxCollider2D.bounds.center, _boxCollider2D.bounds.size, 0, Vector2.down, 0.2f, groundLayer);
        return hit.collider != null;
    }
}
