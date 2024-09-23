using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _boss;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            _boss.SetActive(true);

    }
}
