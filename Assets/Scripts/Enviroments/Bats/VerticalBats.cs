using UnityEngine;

public class VerticalBats : MonoBehaviour
{
    [SerializeField] private GameObject bat;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            bat.SetActive(true);
            Destroy(gameObject);
        }
    }
}