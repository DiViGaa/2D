using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingHeadParameters : AbstractCharacterParameters
{
    private FlyingHeadAnimator _flyingHeadAnimator;
    [SerializeField] private DamageFlyingHead _damageFlyingHead;

    private void Start()
    {
        _flyingHeadAnimator = GetComponent<FlyingHeadAnimator>();
        _damageFlyingHead = GetComponent<DamageFlyingHead>();
    }

    public override void CheckHP()
    {
        if (HP <= 0)
            _flyingHeadAnimator.DeathAnimation();
    }

    public override void TakeDamage(float damage)
    {
        HP -= damage;
        Destroy(_damageFlyingHead);
        CheckHP();
    }

    public void DestroyHead()
    {
        Destroy(gameObject);
    }
}
