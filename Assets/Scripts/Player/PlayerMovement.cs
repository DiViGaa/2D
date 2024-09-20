using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform _bottonCheckLadder;
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private float _ladderSpeed = 1.5f;
    [SerializeField] private float _dodgeForse = 15000;
    [SerializeField] private Transform _checkLadder;
    [SerializeField] private float _jumpForce = 15f;
    [SerializeField] private LayerMask ladderLayer;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float _moveSpeed = 5f;
    
    private PlayerAnimator _playerAnimator;
    private BoxCollider2D _boxCollider2D;
    private PlayerCombat _playerCombat;
    private float _nextDodgeTime = 0f;
    private bool _bottonCheckedLadder;
    private bool isDodging = false;
    private Rigidbody2D _rigidbody;
    private float _DodgeRate = 1f;
    private float _ladderCenter;
    private PlayerSounds _sound;
    private bool _checkedLadder;
    private bool wasGrounded;
    private bool _corrected;
    private bool _onLadder;
    
    public SpriteRenderer spriteRenderer { get; private set; }
    public float HorizontalAxis { get; private set; }
    public float VerticalAxis { get; private set; }


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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
            LadderCorrected();
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
        HorizontalAxis = _inputManager.HorizontalAxis();
        VerticalAxis = _inputManager.VerticalAxis();
    }

    private void Dodge()
    {
        if (_inputManager.LShiftIsPressed() && !isDodging && Time.time >= _nextDodgeTime)
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
        Vector2 dodgeDirection = spriteRenderer.flipX ? Vector2.left : Vector2.right;
        _rigidbody.AddForce(dodgeDirection * _dodgeForse, ForceMode2D.Force);
        yield return new WaitForSeconds(0.5f);

        foreach (var enemyCollider in enemyColliders)
            Physics2D.IgnoreCollision(_boxCollider2D, enemyCollider, false);
    }

    private void Movement()
    {
        if (!_onLadder)
            _rigidbody.velocity = new Vector2(HorizontalAxis * _moveSpeed, _rigidbody.velocity.y);
    }

    private void Jump()
    {
        if (_inputManager.SpaceIsPressed() && IsGrounded())
        {
            _sound.PlayJumpSound();
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
            _playerAnimator.JumpAnimation();
        }
    }

    private void Flip()
    {
        if (HorizontalAxis != 0)
            spriteRenderer.flipX = HorizontalAxis < 0;
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
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, VerticalAxis * _ladderSpeed);
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
                if (VerticalAxis > 0)
                    _onLadder = false;

                else if (VerticalAxis < 0)
                    _onLadder = true;
            }
            else if (_checkedLadder && _bottonCheckedLadder)
            {
                if (VerticalAxis > 0)
                    _onLadder = true;

                else if (VerticalAxis < 0)
                    _onLadder = true;
            }
            else if (_checkedLadder && !_bottonCheckedLadder)
            {
                if (VerticalAxis > 0)
                    _onLadder = true;

                else if (VerticalAxis < 0)
                    _onLadder = false;
            }
        }
        else
            _onLadder = false;

        MoveUpOnLadder();

        if (VerticalAxis > 0 || VerticalAxis < 0 || VerticalAxis == 0)
            _playerAnimator.LadderAnimation(_onLadder);
    }

    private void LadderCorrected()
    {
        if(_onLadder && _corrected)
        {
            _corrected = !_corrected;
            _rigidbody.velocity = Vector2.zero;
            CenterLadder();
        }

        else if (!_onLadder && !_corrected)
            _corrected = true;
    }

    public bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(_boxCollider2D.bounds.center, _boxCollider2D.bounds.size, 0, Vector2.down, 0.2f, groundLayer);
        return hit.collider != null;
    }

    private void CenterLadder()
    {
        if (_checkedLadder)
            _ladderCenter = Physics2D.OverlapPoint(_checkLadder.position, ladderLayer).GetComponent<BoxCollider2D>().bounds.center.x;

        else if(_bottonCheckedLadder)
            _ladderCenter = Physics2D.OverlapPoint(_bottonCheckLadder.position, ladderLayer).GetComponent<BoxCollider2D>().bounds.center.x;

        transform.position = new Vector2(_ladderCenter, transform.position.y);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(_checkLadder.position, 0.05f);
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(_bottonCheckLadder.position, 0.05f);
    }
}
