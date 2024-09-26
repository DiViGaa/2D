using UnityEngine;

public class WithcTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _withc;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _withc.SetActive(true);
            Destroy(gameObject);
        }
            
    }
}
