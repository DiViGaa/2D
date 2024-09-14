using UnityEngine;

public class OneShotEnemyAnimator : MonoBehaviour
{
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void DeathAnimation()
    {
        _animator.SetTrigger("Death");
    }
}
