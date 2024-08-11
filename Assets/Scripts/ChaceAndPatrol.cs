using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class ChaceAndPatrol : StateMachineBehaviour
{
    [SerializeField] private float _distanceToChase = 5f;
    [SerializeField] private float _movementSpeed = 1.5f;
    [SerializeField] private float _attackDistance = 2f;
    
    private List<Transform> points = new List<Transform>();
    private Rigidbody2D _rigidbody;
    private Transform targetPoint;
    private Transform _player;

    public SpriteRenderer _spriteRenderer;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _rigidbody = animator.GetComponent<Rigidbody2D>();
        _spriteRenderer = animator.GetComponent<SpriteRenderer>();
        points = animator.GetComponent<EnemyPatrolPoints>().points;
        targetPoint = points[Random.Range(0, points.Count)];
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Transform targetToMove;

        MoveToTarget(targetPoint);

        targetToMove = targetPoint;

        if (DistanceToTarget(animator, targetPoint) <= 1) 
        {
            animator.SetBool("MoveOrChase", false);
            animator.SetBool("Wait", true);
        }

        var distanceToPlayer = DistanceToTarget(animator, _player);

        if (distanceToPlayer <= _distanceToChase)
        {
            MoveToTarget(_player);
            targetToMove = _player;
        }

        if (distanceToPlayer <= _attackDistance)
        {
            animator.SetTrigger("Attack");
        }

        Flip(animator, targetToMove);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    private float DistanceToTarget(Animator animator, Transform target)
    {
        return Vector2.Distance(animator.transform.position, target.position);
    }

    private void MoveToTarget(Transform target)
    {
        Vector2 newTarget = new Vector2(target.position.x, _rigidbody.position.y);
        Vector2 newPosition = Vector2.MoveTowards(_rigidbody.position, newTarget, _movementSpeed * Time.fixedDeltaTime);
        _rigidbody.MovePosition(newPosition);
    }

    private void Flip(Animator animator, Transform target) 
    {
        if (animator.transform.position.x > target.position.x) 
        {
            _spriteRenderer.flipX = true;
        }
        else if(animator.transform.position.x < target.position.x)
        {
            _spriteRenderer.flipX = false;
        }
    }
}