using UnityEngine;

abstract public class AbstractCharacterParameters : MonoBehaviour
{
    public float HP;

    abstract public void TakeDamage(float damage);

    abstract public void CheckHP();
}
