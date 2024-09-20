using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    private BoxCollider2D _boxCollider2D;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (IsGrounded())
            _rigidbody.bodyType = RigidbodyType2D.Kinematic;

        else
            _rigidbody.bodyType = RigidbodyType2D.Dynamic;

    }

    public bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(_boxCollider2D.bounds.center, _boxCollider2D.bounds.size, 0, Vector2.down, 0.2f, groundLayer);
        return hit.collider != null;
    }
}
