using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            collision.gameObject.GetComponent<PlayerParamaters>().TakeDamage(5);
    }
}
