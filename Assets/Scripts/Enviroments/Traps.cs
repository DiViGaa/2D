using UnityEngine;

public class Traps : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<AbstractCharacterParameters>().TakeDamage(collision.gameObject.GetComponent<AbstractCharacterParameters>().HP);
    }
}
