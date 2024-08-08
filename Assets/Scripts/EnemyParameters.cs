using UnityEngine;

public class EnemyParameters : AbstractCharacterParameters
{
    private void Update()
    {
        CheckHP();
    }

    public override void CheckHP()
    {
        if (HP <= 0)
        {
            Events.SkeletonDeath?.Invoke();
        }
    }

    public override void TakeDamage(float damage)
    {
        HP -= damage;
        Events.SkeletonTakeHit?.Invoke();
    }
}
