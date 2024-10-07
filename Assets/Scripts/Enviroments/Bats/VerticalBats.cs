using UnityEngine;
using UnityEngine.Serialization;

public class VerticalBats : MonoBehaviour
{
    [SerializeField] private GameObject _bat;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _bat.SetActive(true);
            Destroy(gameObject);
        }
    }
}