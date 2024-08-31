using UnityEngine;

public class DamageFlyingHead : MonoBehaviour
{
    [SerializeField] private float _damage = 30f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            collision.gameObject.GetComponent<PlayerParamaters>().TakeDamage(_damage);
    }
}
