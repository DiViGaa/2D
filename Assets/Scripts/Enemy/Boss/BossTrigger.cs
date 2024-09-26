using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _boss;
    [SerializeField] private UI _ui;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _boss.SetActive(true);
            _ui.BossHealthBar(true);
            Destroy(gameObject);
        }

    }
}
