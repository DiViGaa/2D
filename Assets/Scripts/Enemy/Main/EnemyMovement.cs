using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : StateMachineBehaviour
{
    //[SerializeField] private float _distanceToChase = 5f;
    [SerializeField] private float _movementSpeed = 1.5f;
    [SerializeField] private float _attackDistance = 2f;
    
    private List<Transform> points;
    private Rigidbody2D _rigidbody;
    private Transform _patrolPoint;
    private Transform _player;
    private Transform targetToMove;
    private SpriteRenderer _spriteRenderer;


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _rigidbody = animator.GetComponent<Rigidbody2D>();
        _spriteRenderer = animator.GetComponent<SpriteRenderer>();
        points = animator.GetComponent<EnemyPatrolPoints>().points;
        _patrolPoint = points[Random.Range(0, points.Count)];
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        MoveToTarget(_patrolPoint);
        targetToMove = _patrolPoint;
        
        var distanceToPlayer = DistanceToTarget(animator, _player);

        if (_patrolPoint.position.x == animator.gameObject.transform.position.x) 
        {
            animator.SetBool("MoveOrChase", false);
            animator.SetBool("Wait", true);
        }

        //if (distanceToPlayer <= _distanceToChase)
        //{
        //    MoveToTarget(_player);
        //    targetToMove = _player;
        //}

        if (distanceToPlayer <= _attackDistance)
        {
            animator.SetTrigger("Attack");
            targetToMove = _player;
        }

        Flip(animator, targetToMove);
    }


    private float DistanceToTarget(Animator animator, Transform target)
    {
        return (animator.transform.position - target.position).sqrMagnitude;
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
            _spriteRenderer.flipX = true;

        else if(animator.transform.position.x < target.position.x)
            _spriteRenderer.flipX = false;
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
