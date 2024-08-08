using UnityEngine;

public class SkeletonAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        Events.SkeletonTakeHit += TakeHit;
        Events.SkeletonDeath += DeathAnimation;
    }

    private void OnDisable()
    {
        Events.SkeletonTakeHit -= TakeHit;
        Events.SkeletonDeath -= DeathAnimation;

    }

    private void DeathAnimation()
    {
        _animator.SetTrigger("Death");
    }

    private void TakeHit()
    {
        _animator.SetTrigger("Hit");
    }
}
