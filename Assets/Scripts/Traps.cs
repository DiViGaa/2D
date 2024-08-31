using UnityEngine;

public class Traps : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            collision.gameObject.GetComponent<PlayerParamaters>().TakeDamage(collision.gameObject.GetComponent<PlayerParamaters>().HP);
    }
}
