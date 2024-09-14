using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void DeathAnimation()
    {
        _animator.SetTrigger("Death");
    }

    public void TakeHitAnimation()
    {
        _animator.SetTrigger("Hit");
    }
}
